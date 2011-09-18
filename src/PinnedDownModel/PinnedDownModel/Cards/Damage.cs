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
    /// Damage taken by a Pinned Down ship.
    /// </summary>
    public class Damage : Card
    {
        /// <summary>
        /// Gets or sets the power malus this damage causes to the damaged
        /// ship.
        /// </summary>
        public int PowerMalus { get; set; }

        /// <summary>
        /// Gets or sets the capacity malus this damage causes to the damaged
        /// ship.
        /// </summary>
        public int CapacityMalus { get; set; }

        /// <summary>
        /// Gets or sets the structure malus this damage causes to the damaged
        /// ship.
        /// </summary>
        public int StructureMalus { get; set; }


        /// <summary>
        /// Constructs a new damage causing no maluses.
        /// </summary>
        public Damage()
            : base()
        {
            Type = CardType.Damage;
        }

        /// <summary>
        /// Constructs a new damage causing the specified maluses to the
        /// damaged ship.
        /// </summary>
        /// <param name="powerMalus">
        /// The power malus the new damage causes to the damaged ship.
        /// </param>
        /// <param name="capacityMalus">
        /// The capacity malus the new damage causes to the damaged ship.
        /// </param>
        /// <param name="structureMalus">
        /// The structure malus the new damage causes to the damaged ship.
        /// </param>
        public Damage(int powerMalus, int capacityMalus, int structureMalus)
            : this()
        {
            PowerMalus = powerMalus;
            CapacityMalus = capacityMalus;
            StructureMalus = structureMalus;
        }
    }
}
