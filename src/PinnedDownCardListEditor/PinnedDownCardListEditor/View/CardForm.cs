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
using System.Linq;
using System.Windows.Forms;
using PinnedDownCardListEditor.Control;
using PinnedDownModel.Cards;

namespace PinnedDownCardListEditor.View
{
    /// <summary>
    /// The form used for adding and editing Pinned Down cards.
    /// </summary>
    public partial class CardForm : Form
    {
        #region Fields
        /// <summary>
        /// The controller to be notified when the user finishes adding or
        /// editing a card.
        /// </summary>
        private Controller controller;

        /// <summary>
        /// Whether this form is currently used for adding a new card or
        /// editing an existing one.
        /// </summary>
        private bool usedAsEditCardForm;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of the card currently being added or edited.
        /// </summary>
        public string CardName
        {
            get { return textBoxCardName.Text; }
        }

        /// <summary>
        /// Gets the type of the card currently being added or edited.
        /// </summary>
        public Card.CardType CardType
        {
            get
            {
                if (comboBoxCardType.SelectedItem != null)
                {
                    return (Card.CardType)comboBoxCardType.SelectedItem;
                }
                else
                {
                    throw new InvalidOperationException("Please specify a valid card type!");
                }
            }
        }

        /// <summary>
        /// Gets the game text of the card currently being added or edited.
        /// </summary>
        public string GameText
        {
            get { return textBoxGameText.Text; }
        }

        /// <summary>
        /// Gets whether the card currently being added or edited is unique, or not.
        /// </summary>
        public bool Unique
        {
            get { return checkBoxUnique.Checked; }
        }

        /// <summary>
        /// Gets the affiliation the card currently being added or edited belongs to.
        /// </summary>
        public string Affiliation
        {
            get
            {
                if (comboBoxAffiliation.SelectedItem != null)
                {
                    return (string)comboBoxAffiliation.SelectedItem;
                }
                else
                {
                    throw new InvalidOperationException("Please specify a valid affiliation!");
                }
            }
        }

        /// <summary>
        /// Gets the threat value of the card currently being added or edited.
        /// </summary>
        public int Threat
        {
            get { return (int)numericUpDownThreat.Value; }
        }

        /// <summary>
        /// Gets the power (bonus) of the card currently being added or edited.
        /// </summary>
        public int Power
        {
            get { return (int)numericUpDownPower.Value; }
        }

        /// <summary>
        /// Gets the capactiy (bonus) of the card currently being added or edited.
        /// </summary>
        public int Capacity
        {
            get { return (int)numericUpDownCapacity.Value; }
        }

        /// <summary>
        /// Gets the class of the starship card currently being added or edited.
        /// </summary>
        public string ShipClass
        {
            get { return textBoxShipClass.Text; }
        }

        /// <summary>
        /// Gets whether the starship card currently being added or edited is a flagship, or not.
        /// </summary>
        public bool Flagship
        {
            get { return checkBoxFlagship.Checked; }
        }

        /// <summary>
        /// Gets the type of the location card currently being added or edited.
        /// </summary>
        public LocationType LocationType
        {
            get
            {
                if (comboBoxLocationType.SelectedItem != null)
                {
                    return (LocationType)comboBoxLocationType.SelectedItem;
                }
                else
                {
                    throw new InvalidOperationException("Please specify a valid location type!");
                }
            }
        }

        /// <summary>
        /// Gets the distance covered by the location card currently being added or edited.
        /// </summary>
        public int Distance
        {
            get { return (int)numericUpDownDistance.Value; }
        }

        /// <summary>
        /// Gets the structure malus caused by the damage card currently being added or edited.
        /// </summary>
        public int StructureMalus
        {
            get { return (int)numericUpDownStructureMalus.Value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new form for adding or editing Pinned Down cards, and
        /// properly sets up all controls.
        /// </summary>
        /// <param name="controller">
        /// The controller to be notified when the user finishes adding or
        /// editing a card using the new form.
        /// </param>
        public CardForm(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;

            SetupControls();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Prepares this form for adding a new Pinned Down card and shows it.
        /// </summary>
        public void ShowAsNewCardForm()
        {
            Text = "Add New Card";
            buttonAccept.Text = "Add Card";

            usedAsEditCardForm = false;

            comboBoxCardType.Enabled = true;

            Show();
        }

        /// <summary>
        /// Prepares this form for editing the specified Pinned Card and shows
        /// it.
        /// </summary>
        /// <param name="card">The Pinned Down card to edit.</param>
        public void ShowAsEditCardFrom(Card card)
        {
            Text = "Edit Card";
            buttonAccept.Text = "Edit Card";

            usedAsEditCardForm = true;

            // show the current values of the card to be edited
            textBoxCardName.Text = card.Name;

            comboBoxCardType.SelectedIndex = (int)card.Type;
            comboBoxCardType.Enabled = false;

            textBoxGameText.Text = card.GameText;

            checkBoxUnique.Checked = card.Unique;

            switch (card.Type)
            {
                case Card.CardType.Character:
                    Character c = (Character)card;

                    comboBoxAffiliation.SelectedIndex = comboBoxAffiliation.FindString(c.Affiliation);
                    numericUpDownThreat.Value = c.Threat;
                    numericUpDownPower.Value = c.PowerBonus;
                    numericUpDownCapacity.Value = c.CapacityBonus;
                    break;

                case Card.CardType.Damage:
                    Damage d = (Damage)card;

                    numericUpDownPower.Value = d.PowerMalus;
                    numericUpDownCapacity.Value = d.CapacityMalus;
                    numericUpDownStructureMalus.Value = d.StructureMalus;
                    break;

                case Card.CardType.Effect:
                    Effect e = (Effect)card;

                    comboBoxAffiliation.SelectedIndex = comboBoxAffiliation.FindString(e.Affiliation);
                    numericUpDownThreat.Value = e.Threat;
                    break;

                case Card.CardType.Equipment:
                    Equipment eq = (Equipment)card;

                    comboBoxAffiliation.SelectedIndex = comboBoxAffiliation.FindString(eq.Affiliation);
                    numericUpDownThreat.Value = eq.Threat;
                    numericUpDownPower.Value = eq.PowerBonus;
                    numericUpDownCapacity.Value = eq.CapacityBonus;
                    break;

                case Card.CardType.Location:
                    Location l = (Location)card;

                    numericUpDownDistance.Value = l.Distance;
                    comboBoxLocationType.SelectedIndex = (int)l.LocationType;

                    break;

                case Card.CardType.Starship:
                    Starship s = (Starship)card;

                    comboBoxAffiliation.SelectedIndex = comboBoxAffiliation.FindString(s.Affiliation);
                    numericUpDownThreat.Value = s.Threat;
                    numericUpDownPower.Value = s.Power;
                    numericUpDownCapacity.Value = s.Capacity;
                    textBoxShipClass.Text = s.ShipClass;
                    checkBoxFlagship.Checked = s.Flagship;
                    break;
            }

            Show();
        }

        /// <summary>
        /// Sets up all controls of this form, filling all combo boxes with
        /// the appropriate values, and setting the minimum and maximum values
        /// of all <c>NumericUpDown</c> controls.
        /// </summary>
        private void SetupControls()
        {
            textBoxCardName.Text = "Another Pinned Down Card";

            IEnumerable<Card.CardType> cardTypes = Enum.GetValues(typeof(Card.CardType)).Cast<Card.CardType>();

            foreach (Card.CardType type in cardTypes)
            {
                comboBoxCardType.Items.Add(type);
            }

            comboBoxCardType.SelectedIndex = 0;

            foreach (string aff in Card.Affiliations)
            {
                comboBoxAffiliation.Items.Add(aff);
            }

            comboBoxAffiliation.SelectedIndex = 0;

            numericUpDownThreat.Maximum = 20;
            numericUpDownPower.Maximum = 20;
            numericUpDownCapacity.Maximum = 20;

            IEnumerable<LocationType> locationTypes = Enum.GetValues(typeof(LocationType)).Cast<LocationType>();

            foreach (LocationType locType in locationTypes)
            {
                comboBoxLocationType.Items.Add(locType);
            }

            comboBoxLocationType.SelectedIndex = 0;

            numericUpDownDistance.Maximum = 10;
        }

        /// <summary>
        /// Called whenever the user changes the type of the card he or she
        /// wants to add. Enables or disables all controls of this form as
        /// appropriate for the new type.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void comboBoxCardType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch ((Card.CardType)comboBoxCardType.SelectedItem)
            {
                case Card.CardType.Character:
                    checkBoxUnique.Enabled = true;
                    checkBoxUnique.Checked = true;

                    comboBoxAffiliation.Enabled = true;
                    numericUpDownThreat.Enabled = true;

                    labelPower.Text = "Power Bonus:";
                    numericUpDownPower.Enabled = true;

                    labelCapacity.Text = "Capacity Bonus:";
                    numericUpDownCapacity.Enabled = true;

                    textBoxShipClass.Enabled = false;
                    checkBoxFlagship.Enabled = false;
                    comboBoxLocationType.Enabled = false;
                    numericUpDownDistance.Enabled = false;
                    numericUpDownStructureMalus.Enabled = false;
                    break;

                case Card.CardType.Damage:
                    checkBoxUnique.Enabled = false;

                    comboBoxAffiliation.Enabled = false;
                    numericUpDownThreat.Enabled = false;

                    labelPower.Text = "Power Malus:";
                    numericUpDownPower.Enabled = true;

                    labelCapacity.Text = "Capacity Malus:";
                    numericUpDownCapacity.Enabled = true;

                    textBoxShipClass.Enabled = false;
                    checkBoxFlagship.Enabled = false;
                    comboBoxLocationType.Enabled = false;
                    numericUpDownDistance.Enabled = false;
                    numericUpDownStructureMalus.Enabled = true;
                    break;

                case Card.CardType.Effect:
                    checkBoxUnique.Enabled = true;
                    checkBoxUnique.Checked = true;

                    comboBoxAffiliation.Enabled = true;
                    numericUpDownThreat.Enabled = true;

                    numericUpDownPower.Enabled = false;
                    numericUpDownCapacity.Enabled = false;

                    textBoxShipClass.Enabled = false;
                    checkBoxFlagship.Enabled = false;
                    comboBoxLocationType.Enabled = false;
                    numericUpDownDistance.Enabled = false;
                    numericUpDownStructureMalus.Enabled = false;
                    break;

                case Card.CardType.Equipment:
                    checkBoxUnique.Enabled = true;
                    checkBoxUnique.Checked = false;

                    comboBoxAffiliation.Enabled = true;
                    numericUpDownThreat.Enabled = true;

                    labelPower.Text = "Power Bonus:";
                    numericUpDownPower.Enabled = true;

                    labelCapacity.Text = "Capacity Bonus:";
                    numericUpDownCapacity.Enabled = true;

                    textBoxShipClass.Enabled = false;
                    checkBoxFlagship.Enabled = false;
                    comboBoxLocationType.Enabled = false;
                    numericUpDownDistance.Enabled = false;
                    numericUpDownStructureMalus.Enabled = false;
                    break;

                case Card.CardType.Location:
                    checkBoxUnique.Enabled = false;

                    comboBoxAffiliation.Enabled = false;
                    numericUpDownThreat.Enabled = false;

                    numericUpDownPower.Enabled = false;
                    numericUpDownCapacity.Enabled = false;

                    textBoxShipClass.Enabled = false;
                    checkBoxFlagship.Enabled = false;
                    comboBoxLocationType.Enabled = true;
                    numericUpDownDistance.Enabled = true;
                    numericUpDownStructureMalus.Enabled = false;
                    break;

                case Card.CardType.Starship:
                    checkBoxUnique.Enabled = true;
                    checkBoxUnique.Checked = true;

                    comboBoxAffiliation.Enabled = true;
                    numericUpDownThreat.Enabled = true;

                    labelPower.Text = "Power:";
                    numericUpDownPower.Enabled = true;

                    labelCapacity.Text = "Capacity:";
                    numericUpDownCapacity.Enabled = true;

                    textBoxShipClass.Enabled = true;
                    checkBoxFlagship.Enabled = true;
                    comboBoxLocationType.Enabled = false;
                    numericUpDownDistance.Enabled = false;
                    numericUpDownStructureMalus.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Notifies the controller that the user closed this form by clicking
        /// the red cross icon to the top.right of the window. Hides this form
        /// instead of disposing it.
        /// </summary>
        /// <param name="sender">
        /// Ignored.
        /// </param>
        /// <param name="e">
        /// The event args used for preventing the application from disposing
        /// this form.
        /// </param>
        private void NewCardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.CardFormCancel();

            e.Cancel = true;
        }

        /// <summary>
        /// Notifies the controller that the user finished adding or editing
        /// the card.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            controller.CardFormAccept(usedAsEditCardForm);
        }

        /// <summary>
        /// Notifies the controller that user wants to cancel adding or editing
        /// the card.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            controller.CardFormCancel();
        }
        #endregion
    }
}
