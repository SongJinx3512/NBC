using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Dungeon
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		bool deadChk = false;
		bool mpChk = false;
		public void BattleStage()
		{
			Stage stage = new Stage();
			Stage2Monster stage2Monster = new Stage2Monster();
			if (dp.player.Stage == 1) stage.Stage1();
			else if (dp.player.Stage == 2) stage.Stage2(stage2Monster.Stage2_Monster());
			else if (dp.player.Stage == 3) stage.Stage3();
		}

		public void SkillSelect(Skill job, List<Monster> monVal)
		{
			Stage stage = new Stage();
			
			Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");
            foreach (Monster val in monVal)
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
			Console.WriteLine();
			Console.WriteLine($"1. {job.skill1} - MP {job.skill1Cost}");
			Console.WriteLine($"{job.skill1Info}");
			Console.WriteLine();
			Console.WriteLine($"2. {job.skill2} - MP {job.skill2Cost}");
			Console.WriteLine($"{job.skill2Info}");
			Console.WriteLine();
			Console.WriteLine("0. 취소");
			Console.WriteLine();
			if (mpChk) Console.WriteLine("마나가 부족합니다.");
			Console.WriteLine();
			mpChk = false;
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 2);

			switch (input)
			{
				case 1: if(dp.player.Mp >= job.skill1Cost) job.skill_1(monVal); 
						else mpChk = true; SkillSelect(job, monVal); break;
				case 2: if (dp.player.Mp >= job.skill2Cost) job.skill_2(monVal);
						else mpChk = true; SkillSelect(job, monVal); break;
				case 0:
					if (dp.player.Stage == 1) stage.Stage1();
					else if (dp.player.Stage == 2) stage.Stage2(monVal);
					else if (dp.player.Stage == 3) stage.Stage3(); break;


			}
		}

		public void MonsterSelect(List<Monster> monVal)
		{
			int j = 1;
            Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");
            foreach (Monster val in monVal)
			{
				if (val.Hp > 0)
					Console.WriteLine($"{j}. Lv.{val.Level} {val.Name} HP {val.Hp}");
				else
				{
					Console.WriteLine($"{j}. Lv.{val.Level} {val.Name} Dead");
				}
				j++;
			}
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("대상을 선택해주세요.");
			Console.Write(">>");
			if (deadChk) Console.WriteLine("잘못된 입력입니다.");
			deadChk = false;
			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 1:
					if (monVal[0].Hp > 0) PlayerAtkStage(monVal[0], dp.player.Atk, monVal);
					else deadChk = true; MonsterSelect(monVal); break;
				case 2:
					if (monVal[1].Hp > 0) PlayerAtkStage(monVal[1], dp.player.Atk, monVal);
					else deadChk = true; MonsterSelect(monVal); break;
				case 3:
					if (monVal[2].Hp > 0) PlayerAtkStage(monVal[2], dp.player.Atk, monVal);
					else deadChk = true; MonsterSelect(monVal); break;
			}
		}

		public void PlayerAtkStage(Monster monster, int Atk, List<Monster> monVal)
		{
			Random playerAtk = new Random();
			int monsterHp = monster.Hp;
			double error = (Atk / (double)100) * 10;
			int Error = (int)Math.Ceiling(error);
			int player_Atk = playerAtk.Next(Atk - Error, Atk + Error + 1);

            Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine($"{dp.player.Name} 의 공격!");

			if (playerAtk.Next(100) <= 90)//공격 성공률
			{
				if (playerAtk.Next(100) <= 15)
				{
					player_Atk = (int)(player_Atk * 1.6); // 크리티컬 데미지 증가
					monster.Hp -= player_Atk;
					Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]-치명타 공격!");

				}
				else
				{
					monster.Hp -= player_Atk;
					Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]");
				}
			}
			else
			{
				Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
			}

			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
			if (monster.Hp > 0) Console.WriteLine($"HP {monsterHp} -> {monster.Hp}");
			else Console.WriteLine($"HP {monsterHp} -> Dead");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("0. 다음");
			Console.WriteLine();
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 0: MonsterAtkStage(monVal); break;
			}
		}

		public void MonsterAtkStage(List<Monster> monVal)
		{
			Stage stage = new Stage();
			int deadCnt = 0;
			foreach (Monster num in monVal)
			{
				if (num.Hp <= 0)
				{
					deadCnt++;
				}
			}
			if (deadCnt == 3) Victory();

			foreach (Monster val in monVal)
			{
				if (val.Hp > 0)
				{
					Random monsterAtk = new Random();
					int playerHp = dp.player.Hp;
					double error = (val.Atk / (double)100) * 10;
					int Error = (int)Math.Ceiling(error);
					int monster_Atk = monsterAtk.Next(val.Atk - Error, val.Atk + Error + 1);


                    Console.Clear();
                    Console.WriteLine("[====================================================================================]");
                    Console.WriteLine("[                                                                                    ]");
                    Console.WriteLine("[                                     Battle!!                                       ]");
                    Console.WriteLine("[                                                                                    ]");
                    Console.WriteLine("[====================================================================================]");
                    Console.WriteLine($"Lv.{val.Level} {val.Name} 의 공격!");

					if (monsterAtk.Next(100) <= 90)
					{
						if (monsterAtk.Next(100) <= 15)
						{
							monster_Atk = (int)(monster_Atk * 1.6); // 크리티컬 데미지 증가
							dp.player.Hp -= monster_Atk;

							Console.WriteLine($"Lv.{dp.player.Name} 을(를) 맞췄습니다. [데미지 : {monster_Atk}]-치명타 공격!");
						}
						else
						{
							dp.player.Hp -= monster_Atk;
							Console.WriteLine($"Lv.{dp.player.Name} 을(를) 맞췄습니다. [데미지 : {monster_Atk}]");
						}
					}
					else
					{

						Console.WriteLine($"Lv.{dp.player.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
					}


					Console.WriteLine();
                    Console.WriteLine("[====================================================================================]");
                    Console.WriteLine($"Lv.{dp.player.Level} {dp.player.Name}");
					if (dp.player.Hp > 0) Console.WriteLine($"HP {playerHp} -> {dp.player.Hp}");
					else Console.WriteLine($"HP {dp.player.Hp} -> Dead");
					Console.WriteLine();
                    Console.WriteLine("[====================================================================================]");
                    Console.WriteLine("0. 다음");
					Console.WriteLine();
					Console.Write(">>");

					int input = dp.CheckValidInput(0, 0);

					switch (input)
					{
						case 0: break;
					}
				}
			}
		
			if (dp.player.Hp <= 0) Lose();

			if (dp.player.Stage == 1) stage.Stage1();
			else if (dp.player.Stage == 2) stage.Stage2(monVal);
			else if (dp.player.Stage == 3) stage.Stage3();
		}

		public void Victory()
		{
			LvUp lvUp = new LvUp();
			MonsterHpSet monsterHpSet = new MonsterHpSet();
			monsterHpSet.MonsterHp_Set();
			Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Victory!!                                      ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("던전에서 몬스터 3마리를 잡았습니다.");
			Console.WriteLine();
			Console.WriteLine($"Lv.{dp.player.Level} {dp.player.Name}");
			Console.WriteLine($"HP {dp.player.OriHp} -> {dp.player.Hp}");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("0. 다음");
			Console.WriteLine();
			Console.Write(">>");

			if (dp.player.Stage == 1 && !dp.Layer2) dp.Layer2 = true;
			if (dp.player.Stage == 2 && !dp.Layer3) dp.Layer3 = true;

			lvUp.PlayerLvUp(dp.player.Level);

			int input = dp.CheckValidInput(0, 0);

			switch (input)
			{
				case 0: dp.GameIntro(); break;
			}
		}

		public void Lose()
		{
			MonsterHpSet monsterHpSet = new MonsterHpSet();
			monsterHpSet.MonsterHp_Set();
			dp.player.Hp = 0;
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("You Lose");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Lv.{dp.player.Level} {dp.player.Name}");
			Console.WriteLine($"HP {dp.player.OriHp} -> {dp.player.Hp}");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("0. 다음");
			Console.WriteLine();
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 0);

			switch (input)
			{
				case 0: dp.GameIntro(); break;
			}
		}
	}
}
