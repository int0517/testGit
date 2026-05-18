namespace Game
{
    // git edit
    class TMain
    {
        public Player p = new Player();
        public Inventory inven = new Inventory();
        public TShop TS;
        public TBattle TB;

        public TMain()
        {
            TB = new TBattle(p);
            TS = new TShop(p, inven);
        }

        public void DisTMain()
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("행동 선택\n");
            Console.WriteLine("1. 전투    2. 상점    3. 인벤토리    4. 종료");
            Console.WriteLine("=================================================");
            Console.Write("=> ");

            switch (iTP(Console.ReadLine() ?? ""))
            {
                case 1:
                    TB.DisTBattleChoice();
                    break;

                case 2:
                    TS.DisTShop();
                    break;

                case 3:
                    p.PlayerInfo(Inventory.invens);
                    break;

                case 4:
                    Console.WriteLine("게임을 종료합니다.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public static int iTP(string input)
        {
            if(int.TryParse(input, out int choice)) return choice;
            else return -1;
        }
    }

    internal class MainGame
    {
        static void Main()
        {
            TMain TM = new TMain();

            while (true)
            {
                TM.DisTMain();
            }
        }
    }
}