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
    /// A location the player fleets can reside at in Pinned Down.
    /// </summary>
    public class Location : Card
    {
        /// <summary>
        /// Gets or sets the type of this location, specifying which special
        /// effects apply to it.
        /// </summary>
        public LocationType LocationType { get; set; }

        /// <summary>
        /// Gets or sets the distance covered by this location.
        /// </summary>
        public int Distance { get; set; }


        /// <summary>
        /// Constructs a new equipment covering no distance.
        /// </summary>
        public Location()
            : base()
        {
            Type = CardType.Location;
        }

        /// <summary>
        /// Constructs a new location of the passed type, covering the
        /// specified distance.
        /// </param>
        /// <param name="locationType">
        /// The type of the new location, specifying which special effects
        /// apply to it.
        /// </param>
        /// </summary>
        /// <param name="distance">
        /// The distance covered by the new location.
        public Location(LocationType locationType, int distance)
            : this()
        {
            LocationType = locationType;
            Distance = distance;
        }
    }
}
