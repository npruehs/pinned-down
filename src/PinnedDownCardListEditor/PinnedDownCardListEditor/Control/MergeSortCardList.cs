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
using PinnedDownModel.Cards;

namespace PinnedDownCardListEditor.Control
{
    /// <summary>
    /// Utility class implementing a MergeSort algorithm that provides a stable
    /// sort of card lists according to different orders.
    /// </summary>
    public class MergeSortCardList
    {
        /// <summary>
        /// The order according to which to sort a card list.
        /// </summary>
        public enum SortMode
        {
            Affiliation,
            CardType,
            Name
        }

        /// <summary>
        /// Sorts the passed card list according to the specified order. This
        /// is a stable sort, i.e. two equal elements are ensured to preserve
        /// order.
        /// </summary>
        /// <param name="cardList">
        /// The card list to sort.
        /// </param>
        /// <param name="mode">
        /// The order according to which the card list should be ordered.
        /// </param>
        public static void Sort(List<Card> cardList, SortMode mode)
        {
            // create copy of the list to be ordered
            List<Card> listCopy = new List<Card>();

            listCopy.AddRange(cardList);

            // sort the list using the copy
            ParaSort(cardList, 0, cardList.Count - 1, listCopy, mode);
        }

        /// <summary>
        /// Merges both ordered halfs of <paramref name="u"/> into an ordered list
        /// <paramref name="v"/>.
        /// </summary>
        /// <param name="u">
        /// The list containing two ordered halfs of a card list.
        /// </param>
        /// <param name="l">
        /// The index of the first element of the first ordered half.
        /// </param>
        /// <param name="m">
        /// The index of the first element of the second ordered half.
        /// </param>
        /// <param name="r">
        /// The index of the last element of the second ordered half.
        /// </param>
        /// <param name="v">
        /// The card list to merge to.
        /// </param>
        /// <param name="mode">
        /// The order according to which the card list should be ordered.
        /// </param>
        private static void Merge(List<Card> u, int l, int m, int r, List<Card> v, SortMode mode)
        {
            // initialize pointers to remaining segments
            int L = l;
            int R = m;

            // copy both smallest elements to the result list
            while (L < m || R < r + 1)
            {
                // check whether right segment empty, or
                // left one non-empty and first element of left one smaller than of the right one
                if (R > r || (L < m && CardIsLessEqual(u[L], u[R], mode)))
                {
                    // copy first element of left segment
                    v[l] = u[L];
                    L++;
                }
                else
                {
                    // copy first element of right segment
                    v[l] = u[R];
                    R++;
                }

                l++;
            }
        }

        /// <summary>
        /// Sorts <paramref name="u"/> within the specified bounds using
        /// <paramref name="v"/>.
        /// </summary>
        /// <param name="u">
        /// The card list to sort.
        /// </param>
        /// <param name="l">
        /// The index of the first element of the segment to sort.
        /// </param>
        /// <param name="r">
        /// The index of the last element of the segment to sort.
        /// </param>
        /// <param name="v">
        /// The card list copy to use for sorting.
        /// </param>
        /// <param name="mode">
        /// The order according to which the card list should be ordered.
        /// </param>
        private static void ParaSort(List<Card> u, int l, int r, List<Card> v, SortMode mode)
        {
            int m;

            // check whether segment has at least two elements
            if (l < r)
            {
                // compute center element of the segment
                m = l + (r - l + 1) / 2;

                // sort both halfs
                ParaSort(v, l, m - 1, u, mode);
                ParaSort(v, m, r, u, mode);

                // merge ordered halfs
                Merge(v, l, m, r, u, mode);
            }
        }

        /// <summary>
        /// Returns true, if the first card is less or equal than the second
        /// one according to the specified order, and false otherwise.
        /// </summary>
        /// <param name="first">
        /// The first card to compare.
        /// </param>
        /// <param name="second">
        /// The second card to compare.
        /// </param>
        /// <param name="mode">
        /// The order according to which the cards should be compared.
        /// </param>
        /// <returns>
        /// True, if the first card is less or equal than the second
        /// one according to the specified order, and false otherwise.
        /// </returns>
        private static bool CardIsLessEqual(Card first, Card second, SortMode mode)
        {
            switch (mode)
            {
                case SortMode.Affiliation:
                    return String.Compare(first.GetAffiliation(), second.GetAffiliation()) <= 0;

                case SortMode.CardType:
                    return String.Compare(first.Type.ToString(), second.Type.ToString()) <= 0;

                case SortMode.Name:
                    return String.Compare(first.Name, second.Name) <= 0;

                default:
                    return true;
            }
        }
    }
}
