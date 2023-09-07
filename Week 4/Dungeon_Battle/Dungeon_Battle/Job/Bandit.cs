using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class Bandit : Skill
    {
        public string skill1 { get; set; }
        public string skill2 { get; set; }
        public string skill1Info { get; set; }
        public string skill2Info { get; set; }
        public int skill1Cost { get; set; }
        public int skill2Cost { get; set; }
        public Bandit()
        {
            skill1 = "찌르기";
            skill2 = "숨기";
            skill1Info = "공격력 * 1.3으로 하나의 적을 공격합니다.";
            skill2Info = "회피율이 10% 증가합니다.";
            skill1Cost = 10;
            skill2Cost = 20;
        }

        DisplayGameIntro dp = DisplayGameIntro.Instance();
        public void skill_1(List<Monster> monVal)
        {
            int i = 1;
            bool deadChk = false;
            Dungeon dungeon = new Dungeon();
            int skill1Atk = (int)(dp.player.Atk * 1.3);
            Console.Clear();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     Battle!!                                       ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");
            foreach (Monster val in monVal)
            {
                if (val.Hp > 0)
                    Console.WriteLine($"{i} Lv.{val.Level} {val.Name} HP {val.Hp}");
                else
                {
                    Console.WriteLine($"{i} Lv.{val.Level} {val.Name} Dead");
                }
                i++;
            }
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
                    if (monVal[0].Hp > 0)
                    {
                        dp.player.Mp -= skill1Cost; dungeon.PlayerAtkStage(monVal[0], skill1Atk, monVal);
                    }
                    else deadChk = true; skill_1(monVal); break;
                case 2:
                    if (monVal[1].Hp > 0)
                    {
                        dp.player.Mp -= skill1Cost; dungeon.PlayerAtkStage(monVal[1], skill1Atk, monVal);
                    }
                    else deadChk = true; skill_1(monVal); break;
                case 3:
                    if (monVal[2].Hp > 0)
                    {
                        dp.player.Mp -= skill1Cost; dungeon.PlayerAtkStage(monVal[2], skill1Atk, monVal);
                    }
                    else deadChk = true; skill_1(monVal); break;
            }
        }

        public void skill_2(List<Monster> monVal)
        {
            Stage stage = new Stage();
            Dungeon dungeon = new Dungeon();
            dp.player.Mp -= skill2Cost;
            dp.player.Avoidance += 1;
            Console.Clear();
            Console.WriteLine("플레이어의 회피율이 10% 증가했습니다!");
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine("원하시는 행동을 선택해주세요.");
            Console.Write(">>");

            int input = dp.CheckValidInput(0, 0);

            switch (input)
            {
                case 0:
					if (dp.player.Stage == 1) stage.Stage1();
					else if (dp.player.Stage == 2) stage.Stage2(monVal);
					else if (dp.player.Stage == 3) stage.Stage3(); break; 
            }
        }
    }
}
