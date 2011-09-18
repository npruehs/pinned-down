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
    /// A Pinned Down starship, used by a specific affiliation for fighting
    /// and carrying a limited amount of characters and equipment.
    /// </summary>
    public class Starship : Card
    {
        /// <summary>
        /// Gets or sets the affiliation using this starship.
        /// </summary>
        public Affiliation Affiliation { get; set; }

        /// <summary>
        /// Gets or sets the threat this starship generates when it enters
        /// play.
        /// </summary>
        public int Threat { get; set; }

        /// <summary>
        /// Gets or sets the power of this starship when facing enemies.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Gets or sets the number of characters and equipment this starship
        /// may carry.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the name of the class of this ship which can be
        /// referred to by effects and abilities of others cards.
        /// </summary>
        public string ShipClass { get; set; }

        /// <summary>
        /// Gets or sets whether a player may start the game with this ship
        /// in play, or not.
        /// </summary>
        public bool Flagship { get; set; }


        /// <summary>
        /// Constructs a new starship causing no threat and having no power and
        /// capacity.
        /// </summary>
        public Starship()
            : base()
        {
            Type = CardType.Starship;
        }

        /// <summary>
        /// Constructs a new starship used by the specified affiliation with
        /// the given power and capacity,  causing the specified threat when it
        /// enters play.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation using the new starship.
        /// </param>
        /// <param name="threat">
        /// The threat the new starship generates when it enters play.
        /// </param>
        /// <param name="power">
        /// The power of the new starship when facing enemies.
        /// </param>
        /// <param name="capacity">
        /// The number of characters and equipment the new starship may carry.
        /// </param>
        /// <param name="shipClass">
        /// The name of the class of the new ship which can be referred to by
        /// effects and abilities of others cards.
        /// </param>
        /// <param name="flagship">
        /// Whether a player may start the game with the new ship in play, or
        /// not.
        /// </param>
        public Starship(Affiliation affiliation, int threat, int power, int capacity, string shipClass, bool flagship)
            : this()
        {
            Affiliation = affiliation;
            Threat = threat;
            Power = power;
            Capacity = capacity;
            ShipClass = shipClass;
            Flagship = flagship;
        }
    }
}
