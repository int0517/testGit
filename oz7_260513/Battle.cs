namespace Game
{
    class TBattle
    {
        private Dictionary<int, abMonsters> monsters = new Dictionary<int, abMonsters>();

        private Player p;
        

        public TBattle(Player p) 
        {
            this.p = p;
            monsters.Add(1, new Slime());
            monsters.Add(2, new Goblin());
            monsters.Add(3, new Bandit());
            monsters.Add(4, new Werewolf());
            monsters.Add(5, new Wyvern());
        }

        public  void DisTBattleChoice()
        {
            Random r = new Random();

            while (true)
            {
                int rancho = r.Next(0, 2);
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("사냥터 선택\n");
                Console.WriteLine("1. 초급    2. 중급    3. 보스    4. 취소");
                Console.WriteLine("=================================================");
                Console.Write("=> ");

                switch (TMain.iTP(Console.ReadLine() ?? ""))
                {
                    case 1:
                        if(rancho == 0) DisTBattle(monsters[1]);
                        else DisTBattle(monsters[2]);
                        Console.ReadKey();
                        break;
                    case 2:
                        if(rancho == 0) DisTBattle(monsters[3]);
                        else DisTBattle(monsters[4]);
                        Console.ReadKey();
                        break;
                    case 3:
                        DisTBattle(monsters[5]);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("전투를 취소합니다.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void DisTBattle(abMonsters m)
        {
            int turnCount = 1;
            m.ResetHP();
            p.ResetHP();

            while (p.isLive && m.isLive)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine($"{turnCount}턴");
                Console.WriteLine($"{m.Name}    체력 : {m.CurrentHP} / {m.MaxHP}\n");
                Console.WriteLine($"플레이어    체력 : {p.CurrentHP} / {p.FinalHP()}\n");
                Console.WriteLine($"1. 일반 공격    2. 강타({p.Skill1Cooldown}턴)    3. 가르기({p.Skill2Cooldown}턴)\n4. 방어         5. 아이템       6. 도망");
                Console.WriteLine("=================================================");
                Console.Write("=> ");

                switch (TMain.iTP(Console.ReadLine() ?? ""))
                {
                    case 1: // 일반 공격
                        p.Attack(m);
                        Console.WriteLine();
                        if (m.isLive) m.Attack(p);
                        else return;
                        turnCount++;
                        p.SkillCooldown();
                        break;
                    case 2: // 강타
                        if (p.Skill1(m)) { }
                        else break;
                        Console.WriteLine();
                        if (m.isLive) m.Attack(p);
                        else return;
                        turnCount++;
                        p.SkillCooldown();
                        break;
                    case 3: // 가르기
                        if (p.Skill2(m)) { }
                        else break;
                        Console.WriteLine();
                        if (m.isLive) m.Attack(p);
                        else return;
                        turnCount++;
                        p.SkillCooldown();
                        break;
                    case 4: // 방어
                        p.Guard();
                        Console.WriteLine();
                        if (m.isLive) m.Attack(p);
                        else return;
                        turnCount++;
                        p.SkillCooldown();
                        break;
                    case 5:
                        if(!DisTUseItem(m)) break;
                        Console.WriteLine();
                        if (m.isLive) m.Attack(p);
                        turnCount++;
                        p.SkillCooldown();
                        break;
                    case 6: // 도망
                        Console.WriteLine("싸함을 느끼고 도망갔다");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public bool DisTUseItem(abMonsters m)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine($"1. {Inventory.invens[3].Name} ({Inventory.invens[3].Count})    2. {Inventory.invens[4].Name} ({Inventory.invens[4].Count})    3. 취소");
                Console.WriteLine("=================================================");
                Console.Write("=> ");

                switch (TMain.iTP(Console.ReadLine() ?? ""))
                {
                    case 1:
                        if (Item.UseItem(Inventory.invens[3], p)) return true;
                        else break;
                    case 2:
                        if (Item.UseItem(Inventory.invens[4], p, m)) return true;
                        else break;
                    case 3:
                            return false;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
