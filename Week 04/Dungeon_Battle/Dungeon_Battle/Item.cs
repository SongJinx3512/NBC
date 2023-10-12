using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Dungeon_Battle.IItem;

namespace Dungeon_Battle
{
    public class IItem1
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public IItem1(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} (x{Quantity})";
        }
    }

}
