namespace Game
{
    class Item
    {
        // Item("이름", 인벤토리 슬롯, 등급(구별번호), 가격, 추가 공격력, 추가 방어력, 추가 체력, 소지 개수(기본 1))
        public string Name { get; private set; }
        public int InvenCode { get; private set; }
        public int Grade { get; private set; }
        public int Price { get; private set; }
        public int AddAtt {  get; private set; }
        public int AddDef { get; private set; }
        public int AddHP { get; private set; }
        public int Count { get; private set; }

        public Item(string name, int invenCode, int grade, int price, int addAtt, int addDef, int addHP, int count = 1)
        {
            Name = name;
            InvenCode = invenCode;
            Grade = grade;
            Price = price;
            AddAtt = addAtt;
            AddDef = addDef;
            AddHP = addHP;
            Count = count;
        }

        public static Item[] Weapons =
        {
            new Item("나무    검", 0, 0, 0, 3, 0, 0),
            new Item("철      검", 0, 1, 100, 7, 0, 0),
            new Item("대      검", 0, 2, 300, 15, 1, 0)
        };
        public static Item[] Shields =
        {
            new Item("낡은  방패", 1, 0, 0, 0, 1, 0),
            new Item("버  클  러", 1, 1, 100, 1, 3, 10),
            new Item("대형  방패", 1, 2, 300, 3, 5, 20)
        };
        public static Item[] Armors =
        {
            new Item("헌  천  옷", 2, 0, 0, 0, 1, 10),
            new Item("가죽  갑옷", 2, 1, 100, 0, 3, 25),
            new Item("사슬  갑주", 2, 2, 300, 1, 5, 40)
        };
        public static Item[] UsableItem =
        {
            new Item("체력 포션", 3, 0, 100, 0, 0, 0, 1),
            new Item("폭     탄", 3, 1, 100, 0, 0, 0, 1)
        };

        public static bool UseItem(Item usableItem, Player p)
        {
            if(usableItem.Count >0)
            {
                Console.WriteLine("체력 포션 사용    플레이어 체력 20 회복");
                usableItem.Count--;
                p.Heal(20);
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("아이템이 존재하지 않습니다.");
                Console.ReadKey();
                return false;
            }
        }

        public static bool UseItem(Item usableItem, Player p, abMonsters m)
        {
            if (usableItem.Count > 0)
            {
                Console.WriteLine("폭탄 사용    몬스터 체력 30 피해");
                usableItem.Count--;
                m.GetDamage(30, p);
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("폭탄이 존재하지 않습니다.");
                Console.ReadKey();
                return false;
            }
        }

        public static void GetItem(Item i)
        {
            i.Count++;
        }
    }
}
