class Program
{
    static Character player;
    static Item[] inventory;


    static void Main(string[] args)
    {
        DataSetting();
        DisplayMainMenu();
    }

    static void DataSetting()
    {
        player = new Character(level: 1, name: "Ed", job: "거너", atk: 10, def: 5, hp: 100, gold: 1500);

        inventory = new Item[10];
        inventory[0] = new Item(name: "무쇠갑옷", atk: 0, def: 5, desc: "무쇠로 만든 갑옷입니다.");
        inventory[1] = new Item(name: "무쇠갑옷", atk: 2, def: 0, desc: "낡은 검 입니다.");
    }



    static void Equipitem(Item item)
    {
        item.isEquiped = true;
    }

    static void Unequipitem(Item item)
    {
        item.isEquiped = false;
    }


    static void DisplayMainMenu()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 1)
            {
                // 상태보기
                DisplayMyInfo();

            }
            else if (x == 2)
            {
                //인벤토리
                DisplayInventory();
            }
            else
            {
                //error
                Console.WriteLine("잘못 입력하셨습니다.");
            }
        }
    }

    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보르 표시합니다.");
        Console.WriteLine();
        Console.WriteLine("Lv. " + player.Level);
        Console.WriteLine("공격력 : " + player.Atk);
        Console.WriteLine("방어력 : " + player.Def);
        Console.WriteLine("체 력 : " + player.Hp);
        Console.WriteLine("Gold :" + player.Gold);
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                // 메인화면
                DisplayMainMenu();
            }
            else
            {
                //error
                Console.WriteLine("잘못 입력하셨습니다.");
            }
        }
    }

    static void DisplayInventory()
    {
        Console.Clear();

        Console.WriteLine("장착 관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");


        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                break;

            if (inventory[i].isEquiped)
                Console.WriteLine("[E] ");
            Console.WriteLine($"[E] - {inventory[i].Name} | 방어력 + {inventory[i].Def} | {inventory[i].Desc}");
        }



        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.WriteLine(">>");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                // 메인화면
                DisplayMainMenu();

            }
            else if (x == 1)
            {
                //장착관리
                DisplayEquip();
            }
            else
            {
                //에러
                Console.WriteLine("잘못 입력하셨습니다.");
            }
        }
    }

    static void DisplayEquip()
    {
        Console.Clear();

        Console.WriteLine("장착 관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");


        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                break;

            Console.WriteLine(i + 1 + " ");

            if (inventory[i].isEquiped) // bool - 플래그를 남긴다
                Console.WriteLine("[E] ");

            Console.WriteLine($"[E] - {inventory[i].Name} | 방어력 + {inventory[i].Def} | {inventory[i].Desc}");
        }



        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.WriteLine(">>");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                // 메인화면
                DisplayMainMenu();

            }
            else if (x >= 1 && x <= 5)
            {
                Item item = inventory[x - 1];
                if (item.isEquiped)
                {
                    Unequipitem(item);
                }
                else
                {
                    Equipitem(item);
                }

                DisplayEquip();
            }
            else
            {
                //에러
                Console.WriteLine("잘못 입력하셨습니다.");
            }
        }
    }
}
//참조 형식
class Character
{
    public int Level;
    public string Name;
    public string Job;
    public int Atk;
    public int Def;
    public int Hp;
    public int Gold;

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }
}

class Item
{
    public string Name;
    public int Atk;
    public int Def;
    public string Desc;

    public bool isEquiped;

    public Item(string name, int atk, int def, string desc)
    {
        Name = name;
        Atk = atk;
        Def = def;
        Desc = desc;

        isEquiped = true;
    }
}