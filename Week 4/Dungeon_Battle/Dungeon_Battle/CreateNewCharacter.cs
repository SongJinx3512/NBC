using Dungeon_Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CreateNewCharacter;

public class CreateNewCharater
{
	DisplayGameIntro dp = DisplayGameIntro.Instance();
	JobSelect jobselect = new JobSelect();
	public void Create_NewCharacter() // 메인 함수에서만 쓰는 코드
	{
		bool nameChk = false;
		string playerName = "";
        Console.Clear();
		Console.WriteLine("====================================================================================");
		Console.WriteLine();
		Console.Write("원하시는 이름을 설정해주세요");
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("====================================================================================");
	
		Console.WriteLine();
		if (!nameChk)
		{
            Console.Write("이름 : ");
            playerName = Console.ReadLine();
			nameChk = true;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("====================================================================================");

		}
		Console.WriteLine();
		Console.WriteLine();
		if (nameChk) Console.WriteLine($"당신이 선택한 이름은 \"{playerName}\" 입니다."); Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("====================================================================================");
		Console.WriteLine("0. 다음");
		Console.WriteLine();
		Console.Write(">>");

		int input = dp.CheckValidInput(0, 0);

		switch (input)
		{
			case 0:
				dp.player.Name = playerName;
				jobselect.Job_Select(); break;
		}
	}
}