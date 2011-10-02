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
    /// An effect that instantly (and sometimes permanently) changes the
    /// state of a Pinned Down match.
    /// </summary>
    public class Effect : Card
    {
        /// <summary>
        /// Gets or sets the affiliation that can cause this effect.
        /// </summary>
        public string Affiliation { get; set; }

        /// <summary>
        /// Gets or sets the threat this effect generates when it enters play.
        /// </summary>
        public int Threat { get; set; }


        /// <summary>
        /// Constructs a new effect causing no threat.
        /// </summary>
        public Effect()
            : base()
        {
            Type = CardType.Effect;
        }

        /// <summary>
        /// Constructs a new effect that may be caused by the specified
        /// affiliation and generates the given threat when it enters play.
        /// </summary>
        /// <param name="affiliation">
        /// The affiliation that can cause the new effect.
        /// </param>
        /// <param name="threat">
        /// The threat the new effect generates when it enters play.
        /// </param>
        public Effect(string affiliation, int threat)
            : this()
        {
            Affiliation = affiliation;
            Threat = threat;
        }
    }
}
