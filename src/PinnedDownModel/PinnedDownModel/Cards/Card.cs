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

namespace PinnedDownModel.Cards
{
    /// <summary>
    /// Base class for Pinned Down cards of all types. Provides basic card
    /// attributes like its index, name and game text.
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// The list of valid affiliations of a Pinned Down card.
        /// </summary>
        public static readonly string[] Affiliations =
            { "Ac'arr", "Blue Wing", "Enemy", "Purple Wing", "Red Wing" };

        /// <summary>
        /// The type of a Pinned Down card, describing how it is used in the
        /// game and which rules apply to it.
        /// </summary>
        public enum CardType
        {
            Character,
            Damage,
            Effect,
            Equipment,
            Location,
            Starship
        }


        /// <summary>
        /// Gets or sets the card list-wide unique index of this card.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets of sets the name of this card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of this card, describing how it is used in
        /// the game and which rules apply to it.
        /// </summary>
        public CardType Type { get; set; }

        /// <summary>
        /// Gets or sets whether a player may have more than one copy of this
        /// card in play, or not.
        /// </summary>
        public bool Unique { get; set; }

        /// <summary>
        /// Gets or sets the game text of this card, describing its abilities
        /// and which effect it has on the game.
        /// </summary>
        public string GameText { get; set; }
    }
}
