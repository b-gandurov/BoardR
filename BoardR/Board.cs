using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardR
{
    public static class Board
    {
        private static List<BoardItem> items = new List<BoardItem>();

        public static void AddItem(BoardItem item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException("Item already exists");
            }
            items.Add(item);
        }

        public static int TotalItems
        {
            get
            {
                return items.Count;
            }
        }

        public static string PrintItems()
        {

            StringBuilder boardItems = new StringBuilder();
            foreach (BoardItem item in items)
            {
                string itemToString = item.ViewInfo();
                boardItems.AppendLine(itemToString);
            }

            return boardItems.ToString();
        }
    }
}
