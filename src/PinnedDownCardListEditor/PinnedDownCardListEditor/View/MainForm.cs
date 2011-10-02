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
using PinnedDownCardListEditor.Control;
using PinnedDownModel.Cards;

namespace PinnedDownCardListEditor.View
{
    /// <summary>
    /// The main window of the Pinned Down Card List Editor. Shows a table
    /// containing all data of the card list currently being edited and
    /// allows the user to add new cards and edit existing ones.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        /// <summary>
        /// The controller to be notified whenever the user hits a menu button
        /// or clicks a card list item.
        /// </summary>
        private Controller controller;
        #endregion

        #region Properties
        /// <summary>
        /// The table showing all cards of the current Pinned Down card list.
        /// </summary>
        public DataGridView CardTable
        {
            get { return dataGridView; }
        }

        /// <summary>
        /// The dialog to be shown when the user wants to save the current card list.
        /// </summary>
        public SaveFileDialog SaveFileDialog
        {
            get { return saveFileDialog; }
        }

        /// <summary>
        /// The dialog to be shown when the user wants to open another card list.
        /// </summary>
        public OpenFileDialog OpenFileDialog
        {
            get { return openFileDialog; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a main window for the Pinned Down Card List Editor
        /// application, setting up the table for showing the card lists.
        /// </summary>
        /// <param name="controller">
        /// The controller to be notified whenever the user hits a menu button
        /// or clicks a card list item.
        /// </param>
        public MainForm(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;

            dataGridView.Columns.Add("index", "Index");
            dataGridView.Columns.Add("name", "Card Name");
            dataGridView.Columns.Add("type", "Card Type");
            dataGridView.Columns.Add("affiliation", "Affiliation");
            dataGridView.Columns.Add("threat", "Threat");
            dataGridView.Columns.Add("power", "Power");
            dataGridView.Columns.Add("capacity", "Capacity");
            dataGridView.Columns.Add("distance", "Distance");
            dataGridView.Columns.Add("text", "Game Text");

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clears the table showing the current card list and shows the
        /// passed one instead.
        /// </summary>
        /// <param name="cards">
        /// The list of cards to show.
        /// </param>
        public void UpdateCardTable(List<Card> cards)
        {
            dataGridView.Rows.Clear();

            foreach (Card card in cards)
            {
                AddNewCardToTable(card);
            }
        }

        /// <summary>
        /// Adds the passed card to the card table.
        /// </summary>
        /// <param name="card">
        /// The card to add.
        /// </param>
        /// <returns>
        /// The row index of the card within the table.
        /// </returns>
        public int AddNewCardToTable(Card card)
        {
            int i = dataGridView.Rows.Add();

            EditCardTableEntry(i, card);

            return i;
        }

        /// <summary>
        /// Updates the card table row with the specified index by filling it
        /// with the data of the passed card.
        /// </summary>
        /// <param name="index">
        /// The index of the card table row to edit.
        /// </param>
        /// <param name="card">
        /// The card to be shown in the specified row.
        /// </param>
        public void EditCardTableEntry(int index, Card card)
        {
            dataGridView.Rows[index].Cells["index"].Value = card.Index;
            dataGridView.Rows[index].Cells["name"].Value = (card.Unique ? "*" : "") + card.Name;
            dataGridView.Rows[index].Cells["type"].Value = card.Type;
            dataGridView.Rows[index].Cells["text"].Value = card.GameText;

            switch (card.Type)
            {
                case Card.CardType.Character:
                    Character c = (Character)card;

                    dataGridView.Rows[index].Cells["affiliation"].Value = c.Affiliation;
                    dataGridView.Rows[index].Cells["threat"].Value = c.Threat;
                    dataGridView.Rows[index].Cells["power"].Value = c.PowerBonus;
                    dataGridView.Rows[index].Cells["capacity"].Value = c.CapacityBonus;
                    dataGridView.Rows[index].Cells["distance"].Value = "-";
                    break;

                case Card.CardType.Damage:
                    Damage d = (Damage)card;

                    dataGridView.Rows[index].Cells["affiliation"].Value = "-";
                    dataGridView.Rows[index].Cells["threat"].Value = "-";
                    dataGridView.Rows[index].Cells["power"].Value = d.PowerMalus;
                    dataGridView.Rows[index].Cells["capacity"].Value = d.CapacityMalus;
                    dataGridView.Rows[index].Cells["distance"].Value = "-";
                    dataGridView.Rows[index].Cells["text"].Value = "STRUCTURE -" + d.StructureMalus + "%. " + d.GameText;
                    break;

                case Card.CardType.Effect:
                    Effect e = (Effect)card;

                    dataGridView.Rows[index].Cells["affiliation"].Value = e.Affiliation;
                    dataGridView.Rows[index].Cells["threat"].Value = e.Threat;
                    dataGridView.Rows[index].Cells["power"].Value = "-"; ;
                    dataGridView.Rows[index].Cells["capacity"].Value = "-";
                    dataGridView.Rows[index].Cells["distance"].Value = "-";
                    break;

                case Card.CardType.Equipment:
                    Equipment eq = (Equipment)card;

                    dataGridView.Rows[index].Cells["affiliation"].Value = eq.Affiliation;
                    dataGridView.Rows[index].Cells["threat"].Value = eq.Threat;
                    dataGridView.Rows[index].Cells["power"].Value = eq.PowerBonus;
                    dataGridView.Rows[index].Cells["capacity"].Value = eq.CapacityBonus;
                    dataGridView.Rows[index].Cells["distance"].Value = "-";
                    break;

                case Card.CardType.Location:
                    Location l = (Location)card;

                    dataGridView.Rows[index].Cells["affiliation"].Value = "-";
                    dataGridView.Rows[index].Cells["threat"].Value = "-";
                    dataGridView.Rows[index].Cells["power"].Value = "-";
                    dataGridView.Rows[index].Cells["capacity"].Value = "-";
                    dataGridView.Rows[index].Cells["distance"].Value = l.Distance;
                    dataGridView.Rows[index].Cells["text"].Value = l.LocationType.ToString().ToUpper() + ". " + l.GameText;
                    break;

                case Card.CardType.Starship:
                    Starship s = (Starship)card;

                    dataGridView.Rows[index].Cells["affiliation"].Value = s.Affiliation;
                    dataGridView.Rows[index].Cells["threat"].Value = s.Threat;
                    dataGridView.Rows[index].Cells["power"].Value = s.Power;
                    dataGridView.Rows[index].Cells["capacity"].Value = s.Capacity;
                    dataGridView.Rows[index].Cells["distance"].Value = "-";
                    dataGridView.Rows[index].Cells["type"].Value = s.Type + " - " + s.ShipClass;
                    dataGridView.Rows[index].Cells["text"].Value = (s.Flagship ? "FLAGSHIP. " : "") + s.GameText;
                    break;
            }
        }

        /// <summary>
        /// Notifies the controller that the user wants to add a new card.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void newCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.MenuFileNewCard();
        }

        /// <summary>
        /// Notifies the controller that the user wants to open another card
        /// list.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void openCardListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.MenuFileLoad();
        }

        /// <summary>
        /// Notifies the controller that the user wants to save the current card list.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void saveCardListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.MenuFileSave();
        }

        /// <summary>
        /// Notifies the controller that the user wants to quit the application.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.MenuFileExit();
        }

        /// <summary>
        /// Notifies the controller that the user wants to see the About Box.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void aboutPinnedDownCardListEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.MenuHelpAbout();
        }

        /// <summary>
        /// Notifies the controller that the user wants to add a new card.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void toolStripButtonNewCard_Click(object sender, EventArgs e)
        {
            controller.MenuFileNewCard();
        }

        /// <summary>
        /// Notifies the controller that the user wants to open another card
        /// list.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void toolStripButtonOpenCardList_Click(object sender, EventArgs e)
        {
            controller.MenuFileLoad();
        }

        /// <summary>
        /// Notifies the controller that the user wants to save the current card list.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void toolStripButtonSaveCardList_Click(object sender, EventArgs e)
        {
            controller.MenuFileSave();
        }

        /// <summary>
        /// Notifies the controller that the user wants to edit a card.
        /// </summary>
        /// <param name="sender">
        /// Ignored.
        /// </param>
        /// <param name="e">
        /// A table cell showing information on the card the user wants to
        /// edit.
        /// </param>
        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            controller.CardListDoubleClick(e.RowIndex);
        }

        /// <summary>
        /// Notifies the controller that the user wants to edit a card.
        /// </summary>
        /// <param name="sender">
        /// Ignored.
        /// </param>
        /// <param name="e">
        /// A table cell showing information on the card the user wants to
        /// edit.
        /// </param>
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            controller.CardListDoubleClick(e.RowIndex);
        }
        #endregion
    }
}
