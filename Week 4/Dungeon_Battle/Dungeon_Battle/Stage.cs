using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Stage
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		Dungeon dungeon = new Dungeon();
		Warrior warrior = new Warrior();
		Bandit bandit = new Bandit();
		Wizard wizard = new Wizard();
		public void Stage1()
		{
			bool skillOn = false;
            Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");

            for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
				else
				{
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} Dead");
				}
			}
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine($"MP {dp.player.OriMp} / {dp.player.Mp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine("2. 스킬");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(1, 2);

			switch (input)
			{
				case 1: dungeon.MonsterSelect(dp.monsterlist); break;
				case 2:
					if (dp.player.Job == "전사") dungeon.SkillSelect(warrior, dp.monsterlist);
					else if (dp.player.Job == "도적") dungeon.SkillSelect(bandit, dp.monsterlist);
					else dungeon.SkillSelect(wizard, dp.monsterlist);
					break;
			}
		}

		public void Stage2(List<Monster> monList)
		{
			bool skillOn = false;
            Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");

            foreach (Monster val in monList) 
			{
				if (val.Hp > 0)
					Console.WriteLine($"Lv.{val.Level} {val.Name} HP {val.Hp}");
				else
				{
					Console.WriteLine($"Lv.{val.Level} {val.Name} Dead");
				}
			}
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine($"MP {dp.player.OriMp} / {dp.player.Mp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine("2. 스킬");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(1, 2);

			switch (input)
			{
				case 1: dungeon.MonsterSelect(monList); break;
				case 2:
					if (dp.player.Job == "전사") dungeon.SkillSelect(warrior, monList);
					else if (dp.player.Job == "도적") dungeon.SkillSelect(bandit, monList);
					else dungeon.SkillSelect(wizard, monList);
					break;
			}
		}

		public void Stage3()
		{
			bool skillOn = false;
			Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");

            for (int i = 0; i < dp.hardMonsterlist.Count; i++)
			{
				if (dp.hardMonsterlist[i].Hp > 0)
					Console.WriteLine($"Lv.{dp.hardMonsterlist[i].Level} {dp.hardMonsterlist[i].Name} HP {dp.hardMonsterlist[i].Hp}");
				else
				{
					Console.WriteLine($"Lv.{dp.hardMonsterlist[i].Level} {dp.hardMonsterlist[i].Name} Dead");
				}
			}
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine($"MP {dp.player.OriMp} / {dp.player.Mp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine("2. 스킬");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(1, 2);

			switch (input)
			{
				case 1: dungeon.MonsterSelect(dp.hardMonsterlist); break;
				case 2:
					if (dp.player.Job == "전사") dungeon.SkillSelect(warrior, dp.hardMonsterlist);
					else if (dp.player.Job == "도적") dungeon.SkillSelect(bandit, dp.hardMonsterlist);
					else dungeon.SkillSelect(wizard, dp.hardMonsterlist);
					break;
			}
		}
	}
}
