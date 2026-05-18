namespace Game
{     
    class TShop
    {
        private Player p;
        private Inventory invens;
        public TShop(Player p, Inventory invens)
        {
            this.p = p;
            this.invens = invens;
        }

        public void DisTShop()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("행동 선택\n");
                Console.WriteLine("1. 강화    2. 구매    3. 나가기");
                Console.WriteLine("=================================================");
                Console.Write("=> ");

                switch (TMain.iTP(Console.ReadLine() ?? ""))
                {
                    case 1: // 강화
                        DisTReinforce();
                        break;
                    case 2: // 구매
                        DisTBuyItem();
                        break;
                    case 3: // 나가기
                        Console.WriteLine("상점에서 나갑니다.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void DisTReinforce()
        {
            while (true)
            {
                p.StatApply();
                string Price0 = (Inventory.invens[0].Grade < 2) ? (Item.Weapons[(Inventory.invens[0].Grade) + 1].Price).ToString() : "최대 강화";
                string Price1 = (Inventory.invens[1].Grade < 2) ? (Item.Weapons[(Inventory.invens[1].Grade) + 1].Price).ToString() : "최대 강화";
                string Price2 = (Inventory.invens[2].Grade < 2) ? (Item.Weapons[(Inventory.invens[2].Grade) + 1].Price).ToString() : "최대 강화";
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine($"소지금 : {p.Gold}");
                Console.WriteLine("\n소지 아이템");
                Console.WriteLine($"무  기 : {Inventory.invens[0].Name}    강화 금액 : {Price0}");
                Console.WriteLine($"방  패 : {Inventory.invens[1].Name}    강화 금액 : {Price1}");
                Console.WriteLine($"방어구 : {Inventory.invens[2].Name}    강화 금액 : {Price2}");
                Console.WriteLine("강화 선택\n");
                Console.WriteLine("1. 무기    2. 방패    3. 방어구    4. 나가기");
                Console.WriteLine("=================================================");
                Console.Write("=> ");


                switch (TMain.iTP(Console.ReadLine() ?? ""))
                {
                    case 1: // 무기
                        if (Inventory.invens[0].Grade == 2)
                        {
                            Console.WriteLine("최대로 강화된 장비입니다.");
                            Console.ReadKey();
                            break;
                        }
                        else if (p.Gold >= int.Parse(Price0))
                        {
                            p.GetGold(-int.Parse(Price0));
                            Inventory.invens[0] = Item.Weapons[Inventory.invens[0].Grade + 1];
                            Console.WriteLine("무기 강화 완료");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Console.ReadKey();
                            break;
                        }
                    case 2: // 방패
                        if (Inventory.invens[1].Grade == 2)
                        {
                            Console.WriteLine("최대로 강화된 장비입니다.");
                            Console.ReadKey();
                            break;
                        }
                        else if (p.Gold >= int.Parse(Price1))
                        {
                            p.GetGold(-int.Parse(Price1));
                            Inventory.invens[1] = Item.Shields[Inventory.invens[1].Grade + 1];
                            Console.WriteLine("방패 강화 완료");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Console.ReadKey();
                            break;
                        }
                    case 3: // 갑옷
                        if (Inventory.invens[2].Grade == 2)
                        {
                            Console.WriteLine("최대로 강화된 장비입니다.");
                            Console.ReadKey();
                            break;
                        }
                        else if (p.Gold >= int.Parse(Price2))
                        {
                            p.GetGold(-int.Parse(Price2));
                            Inventory.invens[2] = Item.Armors[Inventory.invens[2].Grade + 1];
                            Console.WriteLine("갑옷 강화 완료");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Console.ReadKey();
                            break;
                        }
                    case 4: // 나가기
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void DisTBuyItem()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine($"아이템 구매          {p.Gold}G");
                Console.WriteLine($"1. {Inventory.invens[3].Name} ({Inventory.invens[3].Count}개    {Inventory.invens[3].Price}G)");
                Console.WriteLine($"2. {Inventory.invens[4].Name} ({Inventory.invens[4].Count}개    {Inventory.invens[3].Price}G)");
                Console.WriteLine("3. 나가기");
                Console.WriteLine("=================================================");
                Console.Write("=> ");

                switch (TMain.iTP(Console.ReadLine() ?? ""))
                {
                    case 1:
                        BuyItem(3);
                        break;
                    case 2:
                        BuyItem(4);
                        break;
                    case 3:
                        return;
                }
            }
        }
        public void BuyItem(int slot)
        {
            if (Inventory.invens[slot].Price > p.Gold)
            {
                Console.WriteLine("골드가 부족합니다.");
            }
            else
            {
                Console.WriteLine($"{Inventory.invens[slot].Name} 구매");
                p.GetGold(-Inventory.invens[slot].Price);
                Item.GetItem(Inventory.invens[slot]);
            }
            Console.ReadKey();
        }
    }
}
