using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class StrengthPotion : IItem
    {
		public string Name { get; set; }
		public int Quantity { get; set; }
		public StrengthPotion()
		{
			Name = "공격 포션";
			Quantity = 5;
		}

		public void Use(Player player)
        {
            player.Atk += Quantity;  // 공격력을 5만큼 증가시킵니다.
            Console.WriteLine($"{player.Name}의 공격력이 5만큼 증가했습니다!");
            throw new NotImplementedException();
        }
    }
}
