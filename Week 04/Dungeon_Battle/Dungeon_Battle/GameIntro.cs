using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class DisplayGameIntro
	{
		public static DisplayGameIntro _instance = null;
		public static DisplayGameIntro Instance()
		{
			if (_instance == null)
			{
				_instance = new DisplayGameIntro();
			}
			return _instance;
		}

		
		public List<IItem> potionList = new List<IItem>() {new HealthPotion(), new StrengthPotion()};
		public Minion minion = new Minion();
		public CannonMinion cannonminion = new CannonMinion();
		public EmptyWorm emptyworm = new EmptyWorm();
		public Golem golem = new Golem();
		public Goblin goblin = new Goblin();
		public Slime slime = new Slime();
		public List<Monster> monsterlist = new List<Monster>();
		public List<Monster> allMonsterlist = new List<Monster>();
		public List<Monster> hardMonsterlist = new List<Monster>();
		public Player player = new Player("Sungho", "마법사", 1, 10, 5, 100, 1500, 50, 0, 1, 100, 50);
		public bool jobChk = false;
		public bool Layer2 = false;
		public bool Layer3 = false;
		public DisplayGameIntro()
		{
			monsterlist.Add(minion);
			monsterlist.Add(cannonminion);
			monsterlist.Add(emptyworm);
			hardMonsterlist.Add(golem);
			hardMonsterlist.Add(slime);
			hardMonsterlist.Add(goblin);
			allMonsterlist.AddRange(hardMonsterlist);
			allMonsterlist.AddRange(monsterlist);
		}
		public void GameIntro()
		{
			
			StageSelect stageSelect = new StageSelect();
			Inventory inventory = new Inventory();
			JobSelect jobSelect = new JobSelect();
			Status status = new Status();
			Dungeon dg = new Dungeon();
			Console.Clear();
			if(!jobChk) jobSelect.Job_Select();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                       스파르타 마을에 오신 여러분 환영합니다.                      ]");
            Console.WriteLine("[                 이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.               ]");
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine();
            Console.WriteLine("                                  1. 상태보기");
            Console.WriteLine();
            Console.WriteLine("                                  2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine($"                                  3. 던전 입장 (Dungeon : {player.Stage} 층)");
            Console.WriteLine();
            Console.WriteLine("                                  4. 던전 선택");
            Console.WriteLine();
            Console.WriteLine("                                  0. 종료");
            Console.WriteLine();
            Console.WriteLine("[====================================================================================]");

            Console.Write("원하시는 행동을 입력해주세요: ");

            int input = CheckValidInput(0, 4);

			switch (input)
			{
				case 1:

					Console.Clear();
					status.DisplayMyInfo();
					break;

				case 2:

					Console.Clear();
					inventory.AddItem();
					break;

				case 3:

					Console.Clear();
					dg.BattleStage();

					break;

				case 4:

					Console.Clear();
					stageSelect.Stage_Select();
					break;

				case 0:
                    Console.WriteLine("게임을 종료합니다.");
					Environment.Exit(0);break;

            }

		}
		public int CheckValidInput(int min, int max)
		{
			while (true)
			{
				string input = Console.ReadLine();

				bool parseSuccess = int.TryParse(input, out var ret);
				if (parseSuccess)
				{
					if (ret >= min && ret <= max)
						return ret;
				}

				Console.WriteLine("잘못된 입력입니다.");
			}
		}
	}
}
