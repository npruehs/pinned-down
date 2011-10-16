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
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using PinnedDownDeckEditor.View;
using PinnedDownModel;
using PinnedDownModel.Cards;

namespace PinnedDownDeckEditor.Control
{
    public class Controller
    {
        #region Constants
        /// <summary>
        /// The caption of all message boxes that show error messages.
        /// </summary>
        private const string CAPTION_ERROR_MESSAGE = "Error!";

        /// <summary>
        /// The subdirectory to look search for card lists.
        /// </summary>
        private const string CARD_LIST_DIRECTORY = "Card Lists";

        /// <summary>
        /// The error message that is shown when no card lists could be found.
        /// </summary>
        private const string ERROR_NO_CARD_LISTS =
            "Cannot find any card lists. Please get a new copy of the applicaton!";

        /// <summary>
        /// The error message that is shown when a deck has no flagship.
        /// </summary>
        private const string ERROR_NO_FLAGSHIP =
            "You must choose a flagship for your deck.";

        /// <summary>
        /// The error message that is shown when a deck has not enough cards.
        /// </summary>
        private const string ERROR_MINIMUM_DECK_SIZE =
            "Your deck must contain at least 31 cards.";

        /// <summary>
        /// The caption of the warning dialog that is shown when trying to save
        /// an invalid deck.
        /// </summary>
        private const string WARNING_INVALID_DECK_CAPTION = "Invalid Deck";

        /// <summary>
        /// The first part of the warning message that is shown when trying to
        /// save an invalid deck.
        /// </summary>
        private const string WARNING_INVALID_DECK_PREFIX =
            "Your deck still contains the following errors:";

        /// <summary>
        /// The second part of the warning message that is shown when trying to
        /// save an invalid deck.
        /// </summary>
        private const string WARNING_INVALID_DECK_SUFFIX =
            "Do you want to save it anyway?";

        /// <summary>
        /// The minimum size required for a deck to be valid.
        /// </summary>
        public const int MINIMUM_DECK_SIZE = 31;

        /// <summary>
        /// The maximum number of occurrences per card for a deck to be valid.
        /// </summary>
        public const int MAXIMUM_CARD_COUNT = 4;
        #endregion

        #region Fields
        /// <summary>
        /// The main window of the Pinned Down Deck Editor.
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// The form used for picking cards for the deck.
        /// </summary>
        private PickCardForm pickCardForm;

        /// <summary>
        /// The box showing copyright and version information of this Pinned
        /// Down Deck Editor.
        /// </summary>
        private AboutBox aboutBox;

        /// <summary>
        /// The characters in the current deck.
        /// </summary>
        private Dictionary<Character, int> deckCharacters;

        /// <summary>
        /// The effects in the current deck.
        /// </summary>
        private Dictionary<Effect, int> deckEffects;

        /// <summary>
        /// The equipment in the current deck.
        /// </summary>
        private Dictionary<Equipment, int> deckEquipments;

        /// <summary>
        /// The starships in the current deck.
        /// </summary>
        private Dictionary<Starship, int> deckStarships;

        /// <summary>
        /// The known Pinned Down characters.
        /// </summary>
        private Dictionary<string, Character> characters;

        /// <summary>
        /// The known Pinned Down effects.
        /// </summary>
        private Dictionary<string, Effect> effects;

        /// <summary>
        /// The known Pinned Down equipment cards.
        /// </summary>
        private Dictionary<string, Equipment> equipments;

        /// <summary>
        /// The known Pinned Down starships.
        /// </summary>
        private Dictionary<string, Starship> starships;

        /// <summary>
        /// The name of the flagship of the current deck.
        /// </summary>
        private string flagship;

        /// <summary>
        /// The number of character cards in the current deck.
        /// </summary>
        private int characterCount;

        /// <summary>
        /// The number of effect cards in the current deck.
        /// </summary>
        private int effectCount;

        /// <summary>
        /// The number of equipment cards in the current deck.
        /// </summary>
        private int equipmentCount;

        /// <summary>
        /// The number of starship cards in the current deck.
        /// </summary>
        private int starshipCount;

        /// <summary>
        /// The total number of cards in the current deck.
        /// </summary>
        private int totalCardCount;

        /// <summary>
        /// The number of cards per given threat value in the current deck.
        /// </summary>
        private Dictionary<int, int> cardsPerCost;

        /// <summary>
        /// The average threat value of the cards in the current deck.
        /// </summary>
        private float averageCardCost;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the main window of the Pinned Down Deck Editor.
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
        /// deck list.
        /// </summary>
        public Controller()
        {
            deckCharacters = new Dictionary<Character, int>();
            deckEffects = new Dictionary<Effect, int>();
            deckEquipments = new Dictionary<Equipment, int>();
            deckStarships = new Dictionary<Starship, int>();

            characters = new Dictionary<string, Character>();
            effects = new Dictionary<string, Effect>();
            equipments = new Dictionary<string, Equipment>();
            starships = new Dictionary<string, Starship>();

            cardsPerCost = new Dictionary<int, int>();

            mainForm = new MainForm(this);
            pickCardForm = new PickCardForm(this);
            aboutBox = new AboutBox();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clears the current deck and updates the view after.
        /// </summary>
        internal void NewDeck()
        {
            // clear all deck parts
            ClearDeck();

            // update the view
            mainForm.ResetMainForm();

            // show deck requirements
            ValidateDeck();
        }

        /// <summary>
        /// Prompts the user to specify a deck list file to open and shows that
        /// deck.
        /// </summary>
        internal void OpenDeck()
        {
            // make the user choose a deck list file to read
            if (mainForm.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = mainForm.OpenFileDialog.OpenFile();
                XmlSerializer serializer = new XmlSerializer(typeof(Deck));

                try
                {
                    // read deck list from the file
                    Deck deck = (Deck)serializer.Deserialize(stream);

                    ClearDeck();

                    foreach (Deck.CountCardPair ccPair in deck.cards)
                    {
                        switch (ccPair.cardType)
                        {
                            case Card.CardType.Character:
                                deckCharacters.Add(characters[ccPair.card], ccPair.count);
                                break;

                            case Card.CardType.Effect:
                                deckEffects.Add(effects[ccPair.card], ccPair.count);
                                break;

                            case Card.CardType.Equipment:
                                deckEquipments.Add(equipments[ccPair.card], ccPair.count);
                                break;

                            case Card.CardType.Starship:
                                deckStarships.Add(starships[ccPair.card], ccPair.count);
                                break;

                            default:
                                break;
                        }
                    }

                    flagship = deck.flagship;

                    // update card counts
                    CountCards();

                    // update view
                    mainForm.ShowDeckInformation(deck.deckName, deck.author, deck.affiliation);
                    mainForm.ShowDeckList(deckCharacters, deckEffects, deckEquipments, deckStarships);
                    mainForm.ShowCardCounts(characterCount, effectCount, equipmentCount, starshipCount, totalCardCount, cardsPerCost, averageCardCost);
                    mainForm.ShowFlagship(flagship);
                }
                catch (InvalidOperationException)
                {
                    ShowErrorMessage(mainForm.OpenFileDialog.FileName + " is no valid Pinned Down Deck!");
                }
                finally
                {
                    stream.Close();

                    // check deck requirements
                    ValidateDeck();
                }
            }
        }

        /// <summary>
        /// Checks whether the current deck is valid, and shows a warning if
        /// not. Prompts the user to choose a file to save the current deck to.
        /// </summary>
        internal void SaveDeck(string deckName, string deckAuthor, string affiliaton)
        {
            string[] deckErrors;
            string warningMessage;

            // validate deck before saving
            deckErrors = ValidateDeck();

            if (deckErrors.Length > 0)
            {
                // show deck requirement warning
                warningMessage = WARNING_INVALID_DECK_PREFIX + "\n\n";

                foreach (string errorMessage in deckErrors)
                {
                    warningMessage += errorMessage + "\n";
                }

                warningMessage += "\n" + WARNING_INVALID_DECK_SUFFIX;

                if (MessageBox.Show
                    (warningMessage,
                     WARNING_INVALID_DECK_CAPTION,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // allow the user to save anyway if he or she wants to
                    ShowSaveFileDialog(deckName, deckAuthor, affiliaton);
                }
            }
            else
            {
                // allow the user pick a file to save the deck to
                ShowSaveFileDialog(deckName, deckAuthor, affiliaton);
            }
        }

        /// <summary>
        /// Shows the About Box of this application.
        /// </summary>
        internal void About()
        {
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Disposes all forms and quits the application.
        /// </summary>
        internal void Exit()
        {
            mainForm.Dispose();
            pickCardForm.Dispose();
            aboutBox.Dispose();

            Application.Exit();
        }

        /// <summary>
        /// Shows a form for adding a character of the passed affiliation to
        /// the current deck.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation of the character to add.
        /// </param>
        internal void AddCharacter(string affiliation)
        {
            ShowAddCardFormWithItems<Character>
                (characters, deckCharacters.Keys, affiliation, Card.CardType.Character);
        }

        /// <summary>
        /// Shows a form for adding an effect of the passed affiliation to
        /// the current deck.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation of the effect to add.
        /// </param>
        internal void AddEffect(string affiliation)
        {
            ShowAddCardFormWithItems<Effect>
                (effects, deckEffects.Keys, affiliation, Card.CardType.Effect);
        }

        /// <summary>
        /// Shows a form for adding an equipment of the passed affiliation to
        /// the current deck.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation of the equipment to add.
        /// </param>
        internal void AddEquipment(string affiliation)
        {
            ShowAddCardFormWithItems<Equipment>
                (equipments, deckEquipments.Keys, affiliation, Card.CardType.Equipment);
        }

        /// <summary>
        /// Shows a form for adding a starship of the passed affiliation to
        /// the current deck.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation of the starship to add.
        /// </param>
        internal void AddStarship(string affiliation)
        {
            ShowAddCardFormWithItems<Starship>
                (starships, deckStarships.Keys, affiliation, Card.CardType.Starship);
        }

        /// <summary>
        /// Shows a form for picking a flagship for the current deck.
        /// </summary>
        internal void PickFlagship()
        {
            List<string> flagshipNames = new List<string>();

            foreach (Starship starship in deckStarships.Keys)
            {
                if (starship.Flagship)
                {
                    flagshipNames.Add(starship.Name);
                }
            }

            pickCardForm.ShowWithItems(flagshipNames.ToArray(), true, Card.CardType.Starship);
        }

        /// <summary>
        /// Adds the passed card to the deck, or remembers the passed flagship.
        /// Validates the deck and updates the view afterwards.
        /// </summary>
        /// <param name="cardName">
        /// The name of the picked card.
        /// </param>
        /// <param name="pickingFlagship">
        /// Whether the picked card is the new flagship of the current deck, or
        /// should be added to the deck list.
        /// </param>
        /// <param name="cardType">
        /// The type of the picked card.
        /// </param>
        internal void PickCardFormAccept(string cardName, bool pickingFlagship, Card.CardType cardType)
        {
            // hide form
            pickCardForm.Hide();

            if (pickingFlagship)
            {
                // remember picked flagship and update view
                flagship = cardName;
                mainForm.ShowFlagship(flagship);
            }
            else
            {
                if (cardName != null)
                {
                    // add card to the deck
                    switch (cardType)
                    {
                        case Card.CardType.Character:
                            deckCharacters.Add(characters[cardName], 1);
                            break;

                        case Card.CardType.Effect:
                            deckEffects.Add(effects[cardName], 1);
                            break;

                        case Card.CardType.Equipment:
                            deckEquipments.Add(equipments[cardName], 1);
                            break;

                        case Card.CardType.Starship:
                            deckStarships.Add(starships[cardName], 1);
                            break;

                        default:
                            break;
                    }

                    // update card counts
                    CountCards();

                    // update view
                    mainForm.ShowDeckList(deckCharacters, deckEffects, deckEquipments, deckStarships);
                    mainForm.ShowCardCounts(characterCount, effectCount, equipmentCount, starshipCount, totalCardCount, cardsPerCost, averageCardCost);
                }
            }

            // check whether the deck is valid now
            ValidateDeck();
        }

        /// <summary>
        /// Hides the form for adding a card or picking a flagship.
        /// </summary>
        internal void PickCardFormCancel()
        {
            pickCardForm.Hide();
        }

        /// <summary>
        /// Removes the passed card from the current deck.
        /// Validates the deck and updates the view afterwards.
        /// </summary>
        /// <param name="card">
        /// The card to be removed.
        /// </param>
        internal void RemoveCard(Card card)
        {
            // remove card from the deck
            switch (card.Type)
            {
                case Card.CardType.Character:
                    deckCharacters.Remove((Character)card);
                    break;

                case Card.CardType.Effect:
                    deckEffects.Remove((Effect)card);
                    break;

                case Card.CardType.Equipment:
                    deckEquipments.Remove((Equipment)card);
                    break;

                case Card.CardType.Starship:
                    deckStarships.Remove((Starship)card);
                    break;

                default:
                    break;
            }

            // update card counts
            CountCards();

            // update view
            mainForm.ShowDeckList(deckCharacters, deckEffects, deckEquipments, deckStarships);
            mainForm.ShowCardCounts(characterCount, effectCount, equipmentCount, starshipCount, totalCardCount, cardsPerCost, averageCardCost);

            // check whether the deck is still valid
            ValidateDeck();
        }

        /// <summary>
        /// Sets the number of occurrences of the specified card to the
        /// passed value. Validates the deck and updates the view afterwards.
        /// </summary>
        /// <param name="card">
        /// The card to change the number of occurrences of.
        /// </param>
        /// <param name="value">
        /// The new number of occurrences of the specified card in the deck.
        /// </param>
        internal void CardCountChanged(Card card, int value)
        {
            // update number of occurrences of the specified card
            switch (card.Type)
            {
                case Card.CardType.Character:
                    deckCharacters[(Character)card] = value;
                    break;

                case Card.CardType.Effect:
                    deckEffects[(Effect)card] = value;
                    break;

                case Card.CardType.Equipment:
                    deckEquipments[(Equipment)card] = value;
                    break;

                case Card.CardType.Starship:
                    deckStarships[(Starship)card] = value;
                    break;

                default:
                    break;
            }

            // update card counts
            CountCards();

            // update view
            mainForm.ShowCardCounts(characterCount, effectCount, equipmentCount, starshipCount, totalCardCount, cardsPerCost, averageCardCost);

            // check whether the deck is still valid
            ValidateDeck();
        }

        /// <summary>
        /// Clears the current deck and resets all card counts. Note that this
        /// method does not reset the deck flagship or update the view.
        /// </summary>
        private void ClearDeck()
        {
            deckCharacters.Clear();
            deckEffects.Clear();
            deckEquipments.Clear();
            deckStarships.Clear();

            CountCards();
        }

        /// <summary>
        /// Shows a form for adding a new card of the specified type and
        /// affiliation to the current deck.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the card to add.
        /// </typeparam>
        /// <param name="cards">
        /// The set of possible cards to add.
        /// </param>
        /// <param name="removedCards">
        /// The list of cards that are already part of the current deck.
        /// </param>
        /// <param name="affiliation">
        /// The affiliation of the card to add.
        /// </param>
        /// <param name="cardType">
        /// The type of the card to add.
        /// </param>
        private void ShowAddCardFormWithItems<T>
            (Dictionary<string, T> cards, IEnumerable<T> removedCards,
            string affiliation, Card.CardType cardType)

            where T : Card
        {
            List<string> passedNames = new List<string>();

            // filter cards by affiliation
            foreach (string cardName in cards.Keys)
            {
                if (cards[cardName].GetAffiliation().Equals(affiliation))
                {
                    passedNames.Add(cardName);
                }
            }

            // remove cards already in the deck
            foreach (Card c in removedCards)
            {
                passedNames.Remove(c.Name);
            }

            // show form for adding a new card
            pickCardForm.ShowWithItems(passedNames.ToArray(), false, cardType);
        }

        /// <summary>
        /// Prompts the user to choose a file to save the current card list to
        /// and writes the list to that file.
        /// </summary>
        /// <param name="deckName">
        /// The title of the deck to save.
        /// </param>
        /// <param name="deckAuthor">
        /// The name of the author of the deck to save.
        /// </param>
        /// <param name="affiliation">
        /// The affiliation of the deck to save.
        /// </param>
        private void ShowSaveFileDialog(string deckName, string deckAuthor, string affiliation)
        {
            // make the user choose a file to save his or her deck to
            if (mainForm.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // prepare file stream to write to
                Stream stream = mainForm.SaveFileDialog.OpenFile();
                XmlSerializer serializer = new XmlSerializer(typeof(Deck));

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("pdcl", "http://pinneddown.org/decklist");

                // package the current deck into a serializable object
                Deck deck = new Deck();

                deck.deckName = deckName;
                deck.author = deckAuthor;
                deck.affiliation = affiliation;
                deck.flagship = flagship;

                List<Deck.CountCardPair> cards = new List<Deck.CountCardPair>();

                foreach (Character c in deckCharacters.Keys)
                {
                    Deck.CountCardPair ccPair = new Deck.CountCardPair();
                    ccPair.card = c.Name;
                    ccPair.count = deckCharacters[c];
                    ccPair.cardType = Card.CardType.Character;

                    cards.Add(ccPair);
                }

                foreach (Effect e in deckEffects.Keys)
                {
                    Deck.CountCardPair ccPair = new Deck.CountCardPair();
                    ccPair.card = e.Name;
                    ccPair.count = deckEffects[e];
                    ccPair.cardType = Card.CardType.Effect;

                    cards.Add(ccPair);
                }

                foreach (Equipment e in deckEquipments.Keys)
                {
                    Deck.CountCardPair ccPair = new Deck.CountCardPair();
                    ccPair.card = e.Name;
                    ccPair.count = deckEquipments[e];
                    ccPair.cardType = Card.CardType.Equipment;

                    cards.Add(ccPair);
                }

                foreach (Starship s in deckStarships.Keys)
                {
                    Deck.CountCardPair ccPair = new Deck.CountCardPair();
                    ccPair.card = s.Name;
                    ccPair.count = deckStarships[s];
                    ccPair.cardType = Card.CardType.Starship;

                    cards.Add(ccPair);
                }

                deck.cards = cards.ToArray();

                // write the deck to the chosen file
                serializer.Serialize(stream, deck, ns);

                stream.Close();
            }
        }

        /// <summary>
        /// Counts the number of occurrences per card type in the current deck
        /// and computes the average card cost.
        /// </summary>
        private void CountCards()
        {
            // reset all counters
            characterCount = 0;
            effectCount = 0;
            equipmentCount = 0;
            starshipCount = 0;

            totalCardCount = 0;

            cardsPerCost.Clear();

            averageCardCost = 0;

            // count characters
            foreach (Character c in deckCharacters.Keys)
            {
                characterCount += deckCharacters[c];
                totalCardCount += deckCharacters[c];

                if (cardsPerCost.ContainsKey(c.Threat))
                {
                    cardsPerCost[c.Threat] += deckCharacters[c];
                }
                else
                {
                    cardsPerCost[c.Threat] = deckCharacters[c];
                }

                averageCardCost += c.Threat * deckCharacters[c];
            }

            // count effects
            foreach (Effect e in deckEffects.Keys)
            {
                effectCount += deckEffects[e];
                totalCardCount += deckEffects[e];

                if (cardsPerCost.ContainsKey(e.Threat))
                {
                    cardsPerCost[e.Threat] += deckEffects[e];
                }
                else
                {
                    cardsPerCost[e.Threat] = deckEffects[e];
                }

                averageCardCost += e.Threat * deckEffects[e];
            }

            // count equipment cards
            foreach (Equipment e in deckEquipments.Keys)
            {
                equipmentCount += deckEquipments[e];
                totalCardCount += deckEquipments[e];

                if (cardsPerCost.ContainsKey(e.Threat))
                {
                    cardsPerCost[e.Threat] += deckEquipments[e];
                }
                else
                {
                    cardsPerCost[e.Threat] = deckEquipments[e];
                }

                averageCardCost += e.Threat * deckEquipments[e];
            }

            // count starships
            foreach (Starship s in deckStarships.Keys)
            {
                starshipCount += deckStarships[s];
                totalCardCount += deckStarships[s];

                if (cardsPerCost.ContainsKey(s.Threat))
                {
                    cardsPerCost[s.Threat] += deckStarships[s];
                }
                else
                {
                    cardsPerCost[s.Threat] = deckStarships[s];
                }

                averageCardCost += s.Threat * deckStarships[s];
            }

            // compute average card cost
            averageCardCost /= totalCardCount;
        }

        /// <summary>
        /// Checks if the current deck meets the flagship and size requirements
        /// and returns an error of error messages, if any.
        /// </summary>
        /// <returns>
        /// The list of validation errors that occurred.
        /// </returns>
        private string[] ValidateDeck()
        {
            List<string> errors = new List<string>();

            // look for a flagship
            if (flagship == null)
            {
                errors.Add(ERROR_NO_FLAGSHIP);
            }
            else if (!(deckStarships.Keys.Contains(starships[flagship])))
            {
                flagship = null;
                mainForm.ShowFlagship(null);

                errors.Add(ERROR_NO_FLAGSHIP);
            }

            // check deck size
            if (totalCardCount < MINIMUM_DECK_SIZE)
            {
                errors.Add(ERROR_MINIMUM_DECK_SIZE);
            }

            // update view
            if (errors.Count > 0)
            {
                mainForm.ShowStatusMessage(errors[0]);
            }
            else
            {
                mainForm.ClearStatusMessage();
            }

            return errors.ToArray();
        }

        /// <summary>
        /// Loads all card lists that can be found for building a list of known
        /// Pinned Down cards that can be added to the decks.
        /// </summary>
        /// <returns>
        /// <c>true</c>, if any Pinned Down card list could be found, and
        /// <c>false</c> otherwise
        /// </returns>
        private bool LoadCardLists()
        {
            List<CardList> cardLists = new List<CardList>();

            // try to open card list directory
            if (Directory.Exists(CARD_LIST_DIRECTORY))
            {
                // enumerate all card list files found
                foreach (string fileName in Directory.EnumerateFiles(CARD_LIST_DIRECTORY, "*.pdcl"))
                {
                    Stream stream = File.OpenRead(fileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(CardList));

                    try
                    {
                        // read card list from the file
                        cardLists.Add((CardList)serializer.Deserialize(stream));
                    }
                    catch (InvalidOperationException)
                    {
                        ShowErrorMessage(fileName + " is no valid Pinned Down Card List!");
                    }
                    finally
                    {
                        stream.Close();
                    }
                }

                // rebuild the list of known cards
                characters.Clear();
                effects.Clear();
                equipments.Clear();
                starships.Clear();

                foreach (CardList cardList in cardLists)
                {
                    foreach (Card card in cardList.cards)
                    {
                        switch (card.Type)
                        {
                            case Card.CardType.Character:
                                characters.Add(card.Name, (Character)card);
                                break;

                            case Card.CardType.Effect:
                                effects.Add(card.Name, (Effect)card);
                                break;

                            case Card.CardType.Equipment:
                                equipments.Add(card.Name, (Equipment)card);
                                break;

                            case Card.CardType.Starship:
                                starships.Add(card.Name, (Starship)card);
                                break;

                            default:
                                break;
                        }
                    }
                }

                return cardLists.Count > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Shows the specified error message.
        /// </summary>
        /// <param name="message">
        /// The error message to show.
        /// </param>
        private static void ShowErrorMessage(string message)
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

            Controller controller = new Controller();

            if (controller.LoadCardLists())
            {
                controller.NewDeck();

                Application.Run(controller.MainForm);
            }
            else
            {
                ShowErrorMessage(ERROR_NO_CARD_LISTS);
            }
        }
        #endregion
    }
}
