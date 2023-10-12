using CreateNewCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	internal class Intro
	{
		DisplayGameIntro dp = new DisplayGameIntro();
		bool click1 = false;
		bool click2 = false;
		bool click3 = false;
		bool click1Chk = false;
		bool click2Chk = false;
		bool click3Chk = false;
		public void ShowIntro()
		{
			Console.Clear();
			CreateNewCharater createNewCharater = new CreateNewCharater();
			ConsoleHelper.SetCurrentFont("바탕", 17);
			Console.Title = "Dungeon And Battle";

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			Console.WriteLine(String.Format("{0}", "Dungeon And Battle").PadLeft(84 - (42 - ("Dungeon And Battle".Length / 2))));
			Console.WriteLine("DOWA team");
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			Console.WriteLine();
			if (!click1) Console.WriteLine(String.Format("{0}", "1. New Game").PadLeft(84 - (42 - ("New Game".Length / 2))));
			else Console.WriteLine(String.Format("{0}", "-->  1. [New Game]").PadLeft(84 - (42 - ("[New Game]".Length / 2))));
			Console.WriteLine();
			if (!click2) Console.WriteLine(String.Format("{0}", "2. Load Game").PadLeft(85 - (42 - ("Load Game".Length / 2))));
			else Console.WriteLine(String.Format("{0}", "-->  2. [Load Game]").PadLeft(85 - (42 - ("[Load Game]".Length / 2))));
			Console.WriteLine();
			if (!click3) Console.WriteLine(String.Format("{0}", "3. Quit").PadLeft(82 - (42 - ("Quit".Length / 2))));
			else Console.WriteLine(String.Format("-->  {0}", "3. [Quit]").PadLeft(82 - (42 - ("[Quit]".Length / 2))));
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			Console.WriteLine();
			if (click1) Console.WriteLine(String.Format("{0}", "새로운 게임을 시작합니다").PadLeft(80 - (42 - ("새로운 게임을 시작합니다".Length / 2))));
			if (click2) Console.WriteLine(String.Format("{0}", "저장된 게임을 시작합니다").PadLeft(80 - (42 - ("새로운 게임을 시작합니다".Length / 2))));
			if (click3) Console.WriteLine(String.Format("{0}", "게임을 종료합니다").PadLeft(80 - (42 - ("게임을 종료합니다".Length / 2))));
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			if(click1Chk || click2Chk || click3Chk)
			Console.WriteLine("실행하시려면 숫자를 한 번 더 눌러주세요!");

            click1 = false;
			click2 = false;
			click3 = false;

			ConsoleKeyInfo keyInfo = Console.ReadKey();
			switch (keyInfo.Key)
			{
				case ConsoleKey.D1:
					if (!click1Chk)
					{
						click1 = true;
						click1Chk = true;
						click2Chk = false;
						click3Chk = false;
						ShowIntro();
					}
					else createNewCharater.Create_NewCharacter();
					break;
				case ConsoleKey.D2:

					if (!click2Chk)
					{
						click2 = true;
						click2Chk = true;
						click1Chk = false;
						click3Chk = false;
						ShowIntro();
					}
					else Console.Clear();
                    Console.WriteLine("아직 기능이 미구현 입니다!");
                    Console.WriteLine();
					Console.WriteLine("0. 돌아가기");
					Console.Write(">>");
					int input = dp.CheckValidInput(0, 0);
					if (input == 0) ShowIntro();
					break;
				case ConsoleKey.D3:

					if (!click3Chk)
					{
						click3 = true;
						click3Chk = true;
						click2Chk = false;
						click1Chk = false;
						ShowIntro();
					}
					else
						Console.Clear();
						Console.WriteLine("플레이 해주셔서 감사합니다!");
						Console.WriteLine();
						Console.WriteLine("게임을 종료합니다.");
						Environment.Exit(0);
						break;
				default:
					Console.Clear();
					Console.WriteLine("잘못된 입력입니다.");
					ShowIntro();
					break;
			}
		}

		private static void NewGame()
		{
			Console.WriteLine("새로운 게임 시작하는 중...");
			DisplayGameIntro displayIntro = new DisplayGameIntro();
			displayIntro.GameIntro();
		}

		private static void LoadGame()
		{
			Console.WriteLine("세이브 된 파일 불러오는중...");
		}

		private static void QuitGame()
		{
			Console.WriteLine("게임 나가는중...");
			Environment.Exit(0);
		}
	}

}
