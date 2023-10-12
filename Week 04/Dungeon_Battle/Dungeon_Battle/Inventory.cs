using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Dungeon_Battle
{
    public class Inventory
    {
        DisplayGameIntro dp = DisplayGameIntro.Instance();

        
        public void AddItem()
        {
            // 생성자에서 체력 포션 3개 추가
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine();
            for(int i = 0; i < dp.potionList.Count; i++)
            {
                Console.WriteLine($"아이템 이름 : {dp.potionList[i].Name} 아이템 수량 : ");
            }

            // 1아이템 선택
            // 2아이템 장착해제
            //3아이템 장착

            int input = dp.CheckValidInput(1, 3);

         
        }
       
    }
}
