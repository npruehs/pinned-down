/*
 * Copyright 2011 Nick Pruehs.
 * 
 * This file is part of Pinned Down.
 *
 * Pinned Down is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * Pinned Down is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Pinned Down.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using PinnedDownCardListEditor.View;
using PinnedDownModel;
using PinnedDownModel.Cards;
using System.ComponentModel;

namespace PinnedDownCardListEditor.Control
{
    /// <summary>
    /// The controller of the Pinned Down Card List Editor processing all user
    /// input.
    /// </summary>
    public class Controller
    {
        #region Constants
        /// <summary>
        /// The caption of all message boxes that show error messages.
        /// </summary>
        public const string CAPTION_ERROR_MESSAGE = "Error!";

        /// <summary>
        /// The status message to be shown while the card table is being
        /// updated.
        /// </summary>
        public const string PROGRESS_STATUS_UPDATING_CARD_TABLE =
            "Updating card table...";
        #endregion

        #region Fields
        /// <summary>
        /// The main window of the Pinned Down Card List Editor.
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// The form used for adding and editing cards.
        /// </summary>
        private CardForm cardForm;

        /// <summary>
        /// The form used for indicating progress of heavy tasks.
        /// </summary>
        private ProgressForm progressForm;

        /// <summary>
        /// The box showing the copyright and version information of this
        /// editor.
        /// </summary>
        private AboutBox aboutBox;

        /// <summary>
        /// The card list the user is currently working on.
        /// </summary>
        private List<Card> cards;

        /// <summary>
        /// The index of the card the user is currently editing.
        /// </summary>
        private int cardBeingEdited;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the main window of the Pinned Down Card List Editor.
        /// </summary>
        public MainForm MainForm
        {
            get { return mainForm; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new controller for processing all user input.
        /// Creates and sets up all forms and a new, empty Pinned Down
        /// card list.
        /// </summary>
        public Controller()
        {
            mainForm = new MainForm(this);
            cardForm = new CardForm(this);
            progressForm = new ProgressForm(this);
            aboutBox = new AboutBox();

            cards = new List<Card>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Shows the form for adding a new card to the list.
        /// </summary>
        public void MenuFileNewCard()
        {
            cardForm.ShowAsNewCardForm();
        }

        /// <summary>
        /// Prompts the user to specify a card list file to open and shows that
        /// card list.
        /// </summary>
        internal void MenuFileLoad()
        {
            // make the user choose a card list file to read
            if (mainForm.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = mainForm.OpenFileDialog.OpenFile();
                XmlSerializer serializer = new XmlSerializer(typeof(CardList));

                try
                {
                    // read card list from the file
                    CardList cardList = (CardList)serializer.Deserialize(stream);

                    cards.Clear();

                    foreach (Card card in cardList.cards)
                    {
                        cards.Add(card);
                    }

                    // update view
                    UpdateCardTable();
                }
                catch (InvalidOperationException)
                {
                    ShowErrorMessage(mainForm.OpenFileDialog.FileName + " is no valid Pinned Down Card List!");
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Prompts the user to choose a file to save the current card list to
        /// and writes the list to that file.
        /// </summary>
        public void MenuFileSave()
        {
            // make the user choose a file to save the current card list to
            if (mainForm.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // prepare file stream to write to
                Stream stream = mainForm.SaveFileDialog.OpenFile();
                XmlSerializer serializer = new XmlSerializer(typeof(CardList));

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("pdcl", "http://pinneddown.org/cardlist");

                // package the current card list into a serializable object
                CardList cardList = new CardList();

                cardList.cards = cards.ToArray();

                // write the card list to the chosen file
                serializer.Serialize(stream, cardList, ns);

                stream.Close();
            }
        }

        /// <summary>
        /// Disposes all forms and quits the application.
        /// </summary>
        public void MenuFileExit()
        {
            mainForm.Dispose();
            cardForm.Dispose();
            progressForm.Dispose();
            aboutBox.Dispose();

            Application.Exit();
        }

        /// <summary>
        /// Sorts the card list for name, card type and affiliation and assigns
        /// new indices to them.
        /// </summary>
        public void MenuEditSortAndRebuildIndices()
        {
            // List.Sort is unstable - have to use MergeSort instead...
            MergeSortCardList.Sort(cards, MergeSortCardList.SortMode.Name);
            MergeSortCardList.Sort(cards, MergeSortCardList.SortMode.CardType);
            MergeSortCardList.Sort(cards, MergeSortCardList.SortMode.Affiliation);

            // assign new card indices
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].Index = i;
            }

            // update view
            UpdateCardTable();
        }

        /// <summary>
        /// Shows the About Box of this application.
        /// </summary>
        public void MenuHelpAbout()
        {
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Updates the card table to show the current card list.
        /// </summary>
        public void UpdateCardTable()
        {
            // show progress form
            ShowProgressForm(PROGRESS_STATUS_UPDATING_CARD_TABLE);

            // clear card table
            mainForm.ClearCardTable();

            // use different thread for updating the card table
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += new DoWorkEventHandler(BackgroundUpdateCardTable);
            worker.ProgressChanged += new ProgressChangedEventHandler(BackgroundUpdateCardTableProgress);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundUpdateCardTableComplete);

            worker.WorkerReportsProgress = true;

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Updates the card table of the main form in a different thread.
        /// </summary>
        /// <param name="sender">
        /// The background worker thread updating to report progress.
        /// </param>
        /// <param name="e">
        /// Ignored.
        /// </param>
        void BackgroundUpdateCardTable(object sender, DoWorkEventArgs e)
        {
            int cardCount = cards.Count;

            for (int i = 0; i < cardCount; i++)
            {
                mainForm.AddNewCardToTableSync(cards[i]);

                ((BackgroundWorker)sender).ReportProgress(i * 100 / cardCount, i);
            }
        }

        /// <summary>
        /// Notifies the user of the progress updating the card table.
        /// </summary>
        /// <param name="sender">
        /// Ignored.
        /// </param>
        /// <param name="e">
        /// The progress made updating the card table.
        /// </param>
        void BackgroundUpdateCardTableProgress(object sender, ProgressChangedEventArgs e)
        {
            progressForm.UpdateProgressForm
                (PROGRESS_STATUS_UPDATING_CARD_TABLE + " (" + e.UserState.ToString() + "/" + cards.Count + ")",
                 e.ProgressPercentage);
        }

        /// <summary>
        /// Hides the progress form indicating the progress updating the table.
        /// </summary>
        /// <param name="sender">
        /// Ignored.
        /// </param>
        /// <param name="e">
        /// Ignored.
        /// </param>
        void BackgroundUpdateCardTableComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            HideProgressForm();
        }

        /// <summary>
        /// Grabs all data the user entered into the card form and edits the
        /// card chosen by him or her or adds a new one.
        /// </summary>
        /// <param name="editCard">
        /// Whether to edit a card, or add a new one.
        /// </param>
        public void CardFormAccept(bool editCard)
        {
            Card card = null;
            int rowIndex;

            try
            {
                // grab the data entered by the user
                switch (cardForm.CardType)
                {
                    case Card.CardType.Character:
                        card = new Character
                            (cardForm.Affiliation,
                             cardForm.Threat,
                             cardForm.Power,
                             cardForm.Capacity);
                        break;

                    case Card.CardType.Damage:
                        card = new Damage
                            (cardForm.Power,
                             cardForm.Capacity,
                             cardForm.StructureMalus);
                        break;

                    case Card.CardType.Effect:
                        card = new Effect
                            (cardForm.Affiliation,
                             cardForm.Threat);
                        break;

                    case Card.CardType.Equipment:
                        card = new Equipment
                            (cardForm.Affiliation,
                             cardForm.Threat,
                             cardForm.Power,
                             cardForm.Capacity);
                        break;

                    case Card.CardType.Location:
                        card = new Location
                            (cardForm.LocationType,
                            cardForm.Distance);
                        break;

                    case Card.CardType.Starship:
                        card = new Starship
                            (cardForm.Affiliation,
                             cardForm.Threat,
                             cardForm.Power,
                             cardForm.Capacity,
                             cardForm.ShipClass,
                             cardForm.Flagship);
                        break;
                }

                card.Name = cardForm.CardName;
                card.Unique = cardForm.Unique;
                card.GameText = cardForm.GameText;

                // either edit the card or add a new one
                if (editCard)
                {
                    cards[cardBeingEdited] = card;

                    // update view
                    mainForm.EditCardTableEntry(cardBeingEdited, card);
                }
                else
                {
                    card.Index = cards.Count;

                    cards.Add(card);

                    // update view
                    rowIndex = mainForm.AddNewCardToTable(card);
                    mainForm.CardTable.CurrentCell = mainForm.CardTable[0, rowIndex];
                }

                // hide card form
                cardForm.Hide();
            }
            catch (InvalidOperationException e)
            {
                ShowErrorMessage(e.Message);
            }
        }

        /// <summary>
        /// Hides the card form without applying any changes.
        /// </summary>
        public void CardFormCancel()
        {
            cardForm.Hide();
        }

        /// <summary>
        /// Prepares the card form for editing the card with the specified
        /// index and shows it.
        /// </summary>
        /// <param name="Index">
        /// The card list-wide unique index of the card to edit.
        /// </param>
        public void CardListDoubleClick(int Index)
        {
            cardBeingEdited = Index;
            cardForm.ShowAsEditCardFrom(cards[Index]);
        }

        /// <summary>
        /// Shows the progress form with the passed status message and
        /// indicating 0% progress.
        /// </summary>
        /// <param name="statusMessage">
        /// The status message to show.
        /// </param>
        public void ShowProgressForm(string statusMessage)
        {
            progressForm.UpdateProgressForm(statusMessage, 0);

            progressForm.Show();
            progressForm.BringToFront();
            progressForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Hides the progress form.
        /// </summary>
        public void HideProgressForm()
        {
            progressForm.Hide();
        }

        /// <summary>
        /// Shows the specified error message.
        /// </summary>
        /// <param name="message">
        /// The error message to show.
        /// </param>
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, CAPTION_ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Controller().MainForm);
        }
        #endregion
    }
}
