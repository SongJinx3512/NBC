using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class HealthPotion : IItem
    {
		public string Name { get; set; }
		public int Quantity { get; set; }

		public HealthPotion()
        {
            Name = "체력 포션";
            Quantity = 20;
            
        }
        public void Use(Player player)
        {
            player.Hp += Quantity;
            Console.WriteLine($"{player.Name}의 체력이 20만큼 회복했습니다!");
        }
    }
}
