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
using PinnedDownDeckEditor.Control;
using PinnedDownModel.Cards;

namespace PinnedDownDeckEditor.View
{
    /// <summary>
    /// The form used for picking cards for the deck.
    /// </summary>
    public partial class PickCardForm : Form
    {
        #region Constants
        /// <summary>
        /// The title of this form while it's used to pick a card to add to
        /// the deck.
        /// </summary>
        private const string CAPTION_ADD_CARD = "Add Card";

        /// <summary>
        /// The description of this form while it's used to pick a card to add
        /// to the deck.
        /// </summary>
        private const string CAPTION_PICK_FLAGSHIP = "Choose A Flagship";

        /// <summary>
        /// The title of this form while it's used to pick the flagship of the
        /// deck.
        /// </summary>
        private const string LABEL_ADD_CARD = "Pick a card to add:";

        /// <summary>
        /// The description of this form while it's used to pick the flagship
        /// of the deck.
        /// </summary>
        private const string LABEL_PICK_FLAGSHIP = "Choose a flagship for the deck:";
        #endregion

        #region Fields
        /// <summary>
        /// The controller to be notified when the user picked a card.
        /// </summary>
        private Controller controller;

        /// <summary>
        /// The base set of all cards that can be shown by this form.
        /// </summary>
        private List<string> cardNameList;

        /// <summary>
        /// Whether this form is used for picking a flagship, or adding a card.
        /// </summary>
        private bool pickingFlagship;

        /// <summary>
        /// The type of the card being picked.
        /// </summary>
        private Card.CardType cardType;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new form for picking cards for the deck.
        /// </summary>
        /// <param name="controller">
        /// The controller to be notified when the user picked a card.
        /// </param>
        public PickCardForm(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;

            cardNameList = new List<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Shows this form along with the passed card list.
        /// </summary>
        /// <param name="items">
        /// The cards to show.
        /// </param>
        /// <param name="pickingFlagship">
        /// Whether this form should be used for picking a flagship,
        /// or adding a card.
        /// </param>
        /// <param name="cardType">
        /// The type of the card to be picked.
        /// </param>
        public void ShowWithItems(string[] items, bool pickingFlagship, Card.CardType cardType)
        {
            // remember base item set
            cardNameList.Clear();
            cardNameList.AddRange(items);

            // show passed items
            UpdateCardList();

            // remember what this form is displayed for
            this.pickingFlagship = pickingFlagship;
            this.cardType = cardType;

            // change caption and description accordingly
            if (pickingFlagship)
            {
                Text = CAPTION_PICK_FLAGSHIP;
                label.Text = LABEL_PICK_FLAGSHIP;
            }
            else
            {
                Text = CAPTION_ADD_CARD;
                label.Text = LABEL_ADD_CARD;
            }

            // show this form
            Show();
            BringToFront();
            WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Notifies the controller that the user has picked a card.
        /// </summary>
        /// <param name="sender">
        /// The <c>ListBox</c> the user picked a card from.
        /// </param>
        /// <param name="e">
        /// Ignored.
        /// </param>
        private void buttonAddCard_Click(object sender, EventArgs e)
        {
            controller.PickCardFormAccept((string)listBox.SelectedItem, pickingFlagship, cardType);
        }

        /// <summary>
        /// Notifies the controller that the user wants to cancel picking a card.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            controller.PickCardFormCancel();
        }

        /// <summary>
        /// Notifies the controller that the user closed this form by clicking
        /// the red cross icon to the top-right of the window. Hides this form
        /// instead of disposing it.
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void AddCardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.PickCardFormCancel();

            e.Cancel = true;
        }

        /// <summary>
        /// Notifies the controller that the user has picked a card.
        /// </summary>
        /// <param name="sender">
        /// The <c>ListBox</c> the user picked a card from.
        /// </param>
        /// <param name="e">
        /// Ignored.
        /// </param>
        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            controller.PickCardFormAccept((string)listBox.SelectedItem, pickingFlagship, cardType);
        }

        /// <summary>
        /// Updates the list of displayed cards based on the filter the user
        /// entered.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCardList();
        }

        /// <summary>
        /// Updates the list of displayed cards based on the filter the user
        /// entered. If no filter has been specified, all cards are shown.
        /// </summary>
        private void UpdateCardList()
        {
            listBox.Items.Clear();

            if (textBox.Text.Length > 0)
            {
                // show cards that match the filter specified by the user
                foreach (string cardName in cardNameList)
                {
                    if (cardName.ToLower().Contains(textBox.Text.ToLower()))
                    {
                        listBox.Items.Add(cardName);
                    }
                }
            }
            else
            {
                // show all cards
                listBox.Items.AddRange(cardNameList.ToArray());
            }
        }
        #endregion
    }
}
