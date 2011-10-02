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
    /// A Pinned Down equipment, used a specific affiliation providing
    /// abilities and bonuses.
    /// </summary>
    public class Equipment : Card
    {
        /// <summary>
        /// Gets or sets the affiliation using this equipment.
        /// </summary>
        public string Affiliation { get; set; }

        /// <summary>
        /// Gets or sets the threat this equipment generates when it enters
        /// play.
        /// </summary>
        public int Threat { get; set; }

        /// <summary>
        /// Gets or sets the power bonus this equipment provides for its
        /// equipped ship.
        /// </summary>
        public int PowerBonus { get; set; }

        /// <summary>
        /// Gets or sets the capacity bonus this equipment provides for its
        /// equipped ship.
        public int CapacityBonus { get; set; }


        /// <summary>
        /// Constructs a new equipment causing no threat and providing no
        /// bonuses.
        /// </summary>
        public Equipment()
            : base()
        {
            Type = CardType.Equipment;
        }

        /// <summary>
        /// Constructs a new equipment used by the specified affiliation,
        /// causing the given threat when it enters play and providing the
        /// specified power and capacity bonuses for its equipping ship.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation using the new equipment.
        /// </param>
        /// <param name="threat">
        /// The threat the new equipment generates when it enters play.
        /// </param>
        /// <param name="powerBonus">
        /// The power bonus the new equipment provides for its equipping ship.
        /// </param>
        /// <param name="capacityBonus">
        /// The capacity bonus the new equipment provides for its equipping
        /// ship.
        /// </param>
        public Equipment(string affiliation, int threat, int powerBonus, int capacityBonus)
            : this()
        {
            Affiliation = affiliation;
            Threat = threat;
            PowerBonus = powerBonus;
            CapacityBonus = capacityBonus;
        }
    }
}
