using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public interface Skill
	{
		public string skill1 { get; set; }
		public string skill2 { get; set; }
		public string skill1Info { get; set; }
		public string skill2Info { get; set; }
		public int skill1Cost { get; set; }
		public int skill2Cost { get; set; }

		void skill_1(List<Monster> monVal);
		void skill_2(List<Monster> monVal);
	}
}
