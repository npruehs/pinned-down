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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PinnedDownDeckEditor.Control;
using PinnedDownModel.Cards;

namespace PinnedDownDeckEditor.View
{
    /// <summary>
    /// The main window of the Pinned Down Deck Editor. Shows a grid
    /// containing all cards currently being part of the deck, as well
    /// as detailed information on these cards, and allows the user to add new
    /// cards, change their counts or remove them.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constants
        /// <summary>
        /// The flagship name to show while none has been specified.
        /// </summary>
        private const string DEFAULT_FLAGSHIP_NAME = "(none)";

        /// <summary>
        /// The height of each deck list row, in pixels.
        /// </summary>
        private const int ROW_HEIGHT = 25;
        #endregion

        #region Fields
        /// <summary>
        /// The controller to be notified whenever the user hits a menu button
        /// or wants to change the deck.
        /// </summary>
        private Controller controller;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the dialog to be shown when the user wants to open another
        /// deck.
        /// </summary>
        public OpenFileDialog OpenFileDialog
        {
            get { return openFileDialog; }
        }

        /// <summary>
        /// Gets the dialog to be shown when the user wants to save the current
        /// deck.
        /// </summary>
        public SaveFileDialog SaveFileDialog
        {
            get { return saveFileDialog; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a main window for the Pinned Down Deck Editor
        /// application, setting up all controls.
        /// </summary>
        /// <param name="controller">
        /// The controller to be notified whenever the user hits a menu button
        /// or wants to change the deck.
        /// </param>
        public MainForm(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;

            // setup controls
            foreach (string aff in Card.Affiliations)
            {
                comboBoxAffiliation.Items.Add(aff);
            }

            foreach (ColumnStyle colStyle in tableLayoutPanel.ColumnStyles)
            {
                colStyle.SizeType = SizeType.AutoSize;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets this form, clearing all deck information and the deck
        /// card table.
        /// </summary>
        public void ResetMainForm()
        {
            textBoxDeckName.Text = "";
            textBoxDeckAuthor.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().Split(new char[] { '\\' })[1];
            comboBoxAffiliation.SelectedIndex = 0;

            ShowEmptyDeckList();
            ShowCardCounts(0, 0, 0, 0, 0, null, 0);
            ShowFlagship(null);
        }

        /// <summary>
        /// Shows the passed deck information.
        /// </summary>
        /// <param name="deckName">
        /// The deck title to show.
        /// </param>
        /// <param name="deckAuthor">
        /// The name of the deck author to show.
        /// </param>
        /// <param name="affiliation">
        /// The deck affiliation to show.
        /// </param>
        public void ShowDeckInformation(string deckName, string deckAuthor, string affiliation)
        {
            textBoxDeckName.Text = deckName;
            textBoxDeckAuthor.Text = deckAuthor;
            comboBoxAffiliation.SelectedItem = affiliation;
        }

        /// <summary>
        /// Clears the shown deck list, emptying the card table.
        /// </summary>
        public void ShowEmptyDeckList()
        {
            ShowDeckList(null, null, null, null);
        }

        /// <summary>
        /// Shows the passed deck in a table, along with <c>NumericUpDown</c>s
        /// for changing their counts and buttons for removing them.
        /// </summary>
        /// <param name="deckCharacters">
        /// The character cards to show.
        /// </param>
        /// <param name="deckEffects">
        /// The effect cards to show.
        /// </param>
        /// <param name="deckEquipments">
        /// The equipment cards to show.
        /// </param>
        /// <param name="deckStarships">
        /// The starship cards to show.
        /// </param>
        public void ShowDeckList
            (Dictionary<Character, int> deckCharacters,
             Dictionary<Effect, int> deckEffects,
             Dictionary<Equipment, int> deckEquipments,
             Dictionary<Starship, int> deckStarships)
        {
            int rowIndex = 0;

            // clear the deck list
            tableLayoutPanel.Controls.Clear();

            // show all passed cards along with their counts
            ShowDeckCards<Character>(labelCharacters, deckCharacters, ref rowIndex);
            ShowDeckCards<Effect>(labelEffects, deckEffects, ref rowIndex);
            ShowDeckCards<Equipment>(labelEquipments, deckEquipments, ref rowIndex);
            ShowDeckCards<Starship>(labelStarships, deckStarships, ref rowIndex);

            // resize all rows
            for (rowIndex = 0; rowIndex < tableLayoutPanel.RowStyles.Count; rowIndex++)
            {
                tableLayoutPanel.RowStyles[rowIndex].Height = ROW_HEIGHT;
                tableLayoutPanel.RowStyles[rowIndex].SizeType = SizeType.Absolute;
            }

            tableLayoutPanel.ResumeLayout();
            tableLayoutPanel.PerformLayout();
        }

        /// <summary>
        /// Shows the passed card count data, updating all labels and the
        /// Cards per Cost chart.
        /// </summary>
        /// <param name="characterCount">
        /// The number of characters in the deck.
        /// </param>
        /// <param name="effectCount">
        /// The number of effects in the deck.
        /// </param>
        /// <param name="equipmentCount">
        /// The number of equipment cards in the deck.
        /// </param>
        /// <param name="starshipCount">
        /// The number of starships in the deck.
        /// </param>
        /// <param name="totalCardCount">
        /// The total number of cards in the deck.
        /// </param>
        /// <param name="cardsPerCost">
        /// The number of cards per given cost in the deck.
        /// </param>
        /// <param name="averageCardCost">
        /// The average cost of all cards in the deck.
        /// </param>
        public void ShowCardCounts
            (int characterCount, int effectCount,
             int equipmentCount, int starshipCount, int totalCardCount,
             Dictionary<int, int> cardsPerCost, float averageCardCost)
        {
            Series series;

            // update deck card table labels
            labelCharacters.Text = "Characters (" + characterCount + "):";
            labelEffects.Text = "Effects (" + effectCount + "):";
            labelEquipments.Text = "Equipment (" + equipmentCount + "):";
            labelStarships.Text = "Starships (" + starshipCount + "):";

            labelCardCountValue.Text = totalCardCount.ToString();

            // update cost chart
            chart.Series.Clear();

            series = chart.Series.Add("Cards Per Cost");

            if (cardsPerCost != null)
            {
                foreach (int cost in cardsPerCost.Keys)
                {
                    series.Points.Add(new DataPoint(cost, cardsPerCost[cost]));
                }
            }

            labelAvgCardCostValue.Text = averageCardCost.ToString();
        }

        /// <summary>
        /// Shows the passed flagship name, or a default name if the passed
        /// one is <c>null</c>.
        /// </summary>
        /// <param name="flagship">
        /// The flagship name to show.
        /// </param>
        public void ShowFlagship(string flagship)
        {
            linkLabelFlagship.Text = (flagship != null && flagship.Length > 0)
                ? flagship
                : DEFAULT_FLAGSHIP_NAME;
        }

        /// <summary>
        /// Clears the status message shown at the bottom of this form.
        /// </summary>
        public void ClearStatusMessage()
        {
            ShowStatusMessage("");
        }

        /// <summary>
        /// Sets the status message shown at the bottom of this form.
        /// </summary>
        /// <param name="message">
        /// The status message to show.
        /// </param>
        public void ShowStatusMessage(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        /// <summary>
        /// Notifies the controller that the user wants to construct a new
        /// deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void newDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.NewDeck();
        }

        /// <summary>
        /// Notifies the controller that the user wants to open another deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void openDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.OpenDeck();
        }

        /// <summary>
        /// Notifies the controller that the user wants to save the current
        /// deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void saveDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.SaveDeck(textBoxDeckName.Text, textBoxDeckAuthor.Text, (string)comboBoxAffiliation.SelectedItem);
        }

        /// <summary>
        /// Notifies the controller that the user wants to see the About Box.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void aboutPinnedDownDeckEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.About();
        }

        /// <summary>
        /// Notifies the controller that the user wants to quit the application.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Exit();
        }

        /// <summary>
        /// Notifies the controller that the user wants to construct a new
        /// deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void toolStripButtonNewDeck_Click(object sender, EventArgs e)
        {
            controller.NewDeck();
        }

        /// <summary>
        /// Notifies the controller that the user wants to open another deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void toolStripButtonOpenDeck_Click(object sender, EventArgs e)
        {
            controller.OpenDeck();
        }

        /// <summary>
        /// Notifies the controller that the user wants to save the current
        /// deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void toolStripButtonSaveDeck_Click(object sender, EventArgs e)
        {
            controller.SaveDeck(textBoxDeckName.Text, textBoxDeckAuthor.Text, (string)comboBoxAffiliation.SelectedItem);
        }

        /// <summary>
        /// Notifies the controller that the user wants to add a character
        /// to the deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonAddCharacter_Click(object sender, EventArgs e)
        {
            controller.AddCharacter((string)comboBoxAffiliation.SelectedItem);
        }

        /// <summary>
        /// Notifies the controller that the user wants to add an effect
        /// to the deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonAddEffect_Click(object sender, EventArgs e)
        {
            controller.AddEffect((string)comboBoxAffiliation.SelectedItem);
        }

        /// <summary>
        /// Notifies the controller that the user wants to add an equipment
        /// card to the deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonAddEquipment_Click(object sender, EventArgs e)
        {
            controller.AddEquipment((string)comboBoxAffiliation.SelectedItem);
        }

        /// <summary>
        /// Notifies the controller that the user wants to add a starship
        /// to the deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonAddStarship_Click(object sender, EventArgs e)
        {
            controller.AddStarship((string)comboBoxAffiliation.SelectedItem);
        }

        /// <summary>
        /// Notifies the controller that the user wants to remove a card from
        /// the deck.
        /// </summary>
        /// <param name="sender">
        /// The button next to the card the user wants to remove.
        /// </param>
        /// <param name="e">
        /// Ignored.
        /// </param>
        private void buttonRemoveCard_Click(object sender, EventArgs e)
        {
            controller.RemoveCard((Card)((Button)sender).Tag);
        }

        /// <summary>
        /// Notifies the controller that the user wants to change the number of
        /// occurrences of a card in the deck.
        /// </summary>
        /// <param name="sender">
        /// The <c>NumericUpDown</c> next to the card the user wants to change
        /// the number of occurrences of.
        /// </param>
        /// <param name="e">
        /// Ignored.
        /// </param>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            controller.CardCountChanged((Card)numericUpDown.Tag, (int)numericUpDown.Value);
        }

        /// <summary>
        /// Notifies the controller that the user wants to choose a flagship
        /// for the deck.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void linkLabelFlagship_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.PickFlagship();
        }

        /// <summary>
        /// Shows all cards a similar type in an own category in the deck card
        /// table, along with <c>NumericUpDown</c>s for changing the number of
        /// occurrences of each cards and buttons for removing these cards.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the cards to show.
        /// </typeparam>
        /// <param name="typeLabel">
        /// The label marking the beginning of the card type section in the
        /// table.
        /// </param>
        /// <param name="cards">
        /// The cards to show.
        /// </param>
        /// <param name="rowIndex">
        /// The table row index to start displaying the cards at.
        /// </param>
        private void ShowDeckCards<T>(Label typeLabel, Dictionary<T, int> cards, ref int rowIndex)
            where T : Card
        {
            NumericUpDown numericUpDown;
            Label cardLabel;
            Button button;

            // show the card type label
            tableLayoutPanel.Controls.Add(typeLabel);
            tableLayoutPanel.SetCellPosition(typeLabel, new TableLayoutPanelCellPosition(0, rowIndex));

            if (cards != null)
            {
                // sort all cards of the specified type by name
                List<Card> sortedCards = new List<Card>(cards.Keys);
                sortedCards.Sort(new CardComparer());

                foreach (Card c in sortedCards)
                {
                    // allow user the change the number of occurrences
                    numericUpDown = new NumericUpDown();
                    numericUpDown.Name = "numericUpDown" + rowIndex;
                    numericUpDown.Size = new System.Drawing.Size(40, 20);
                    numericUpDown.Value = cards[(T)c];
                    numericUpDown.Minimum = 1;
                    numericUpDown.Maximum = Controller.MAXIMUM_CARD_COUNT;
                    numericUpDown.Tag = c;
                    numericUpDown.ValueChanged += new System.EventHandler(numericUpDown_ValueChanged);

                    tableLayoutPanel.Controls.Add(numericUpDown);
                    tableLayoutPanel.SetCellPosition(numericUpDown, new TableLayoutPanelCellPosition(1, rowIndex));

                    // show card name
                    cardLabel = new Label();
                    cardLabel.AutoSize = true;
                    cardLabel.Name = "label" + rowIndex;
                    cardLabel.Text = c.Name;

                    tableLayoutPanel.Controls.Add(cardLabel);
                    tableLayoutPanel.SetCellPosition(cardLabel, new TableLayoutPanelCellPosition(2, rowIndex));

                    // allow user to remove the card from the deck again
                    button = new Button();
                    button.Name = "button" + rowIndex;
                    button.Size = new System.Drawing.Size(20, 23);
                    button.Text = "-";
                    button.UseVisualStyleBackColor = true;
                    button.Tag = c;
                    button.Click += new System.EventHandler(buttonRemoveCard_Click);

                    tableLayoutPanel.Controls.Add(button);
                    tableLayoutPanel.SetCellPosition(button, new TableLayoutPanelCellPosition(3, rowIndex));

                    // go on in next row
                    rowIndex++;
                }
            }

            if (cards == null || cards.Count == 0)
            {
                // go on in next row if the deck doesn't contain any cards of this type
                rowIndex++;
            }
        }
        #endregion

        /// <summary>
        /// Card comparer that imposes a total ordering on Pinned Down cards
        /// by using the one defined on the card names.
        /// </summary>
        private class CardComparer : Comparer<Card>
        {
            public override int Compare(Card x, Card y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
