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
    /// A serializable list of Pinned Down cards.
    /// </summary>
    [XmlRootAttribute("CardList", Namespace = "http://pinneddown.org/cardlist", IsNullable = false)]
    public class CardList
    {
        /// <summary>
        /// The list of cards that make up this serializable <c>CardList</c>
        /// object.
        /// </summary>
        [XmlArrayItem(Type = typeof(Character)),
         XmlArrayItem(Type = typeof(Damage)),
         XmlArrayItem(Type = typeof(Effect)),
         XmlArrayItem(Type = typeof(Equipment)),
         XmlArrayItem(Type = typeof(Location)),
         XmlArrayItem(Type = typeof(Starship))]
        public Card[] cards;
    }
}
