using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public interface IItem
	{
		string Name { get; set; }
		int Quantity { get; set; }

		void Use(Player player);
	}
}
