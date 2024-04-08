using System;
using System.Collections.Generic;
using System.Linq;

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

        public static void PrintItems()
        {
            foreach (BoardItem item in items)
            {
                Console.WriteLine(item.ViewInfo());
            }
        }
    }
}
