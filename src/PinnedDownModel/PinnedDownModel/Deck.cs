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

using System.Xml.Serialization;
using PinnedDownModel.Cards;

namespace PinnedDownModel
{
    /// <summary>
    /// A serializable Pinned Down deck list.
    /// </summary>
    [XmlRootAttribute("DeckList", Namespace = "http://pinneddown.org/decklist", IsNullable = false)]
    public class Deck
    {
        /// <summary>
        /// A Pinned Down card along with its type and number of occurrences in
        /// the deck.
        /// </summary>
        public struct CountCardPair
        {
            /// <summary>
            /// The number of occurrences of the card in the deck.
            /// </summary>
            public int count;

            /// <summary>
            /// The name of the card.
            /// </summary>
            public string card;

            /// <summary>
            /// The type of the card.
            /// </summary>
            public Card.CardType cardType;
        }

        /// <summary>
        /// The title of this deck.
        /// </summary>
        public string deckName;

        /// <summary>
        /// The name of the author of this deck.
        /// </summary>
        public string author;

        /// <summary>
        /// The main affiliation of this deck.
        /// </summary>
        public string affiliation;

        /// <summary>
        /// The name of the flagship of this deck.
        /// </summary>
        public string flagship;

        /// <summary>
        /// The list of cards that make up this deck.
        /// </summary>
        public CountCardPair[] cards;
    }
}
