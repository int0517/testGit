namespace Game
{
    abstract class abMonsters
    {
        public string? Name { get; protected set; }
        public int MaxHP { get; protected set; }
        public int CurrentHP { get; protected set; }
        public int Att { get; protected set; }
        public int DropGold { get; protected set; }
        public int DropEXP { get; protected set; }
        public bool isLive { get; protected set; }

        public virtual void Attack(Player p) // chance%
        {
            Random rand = new Random();
            int skillRange = rand.Next(1, 101);
            int chance = 100;

            if (skillRange > chance)
            {
                // 스킬 사용
            }
            else
            {
                // 기본 공격
            }
        }

        public void GetDamage(int damage, Player p)
        {
            if (!this.isLive) return;

            if (damage < CurrentHP)
            {
                CurrentHP -= damage;
            }
            else
            {
                CurrentHP = 0;
                isLive = false;
                p.GetGold(DropGold);
                p.GetEXP(DropEXP);
                p.ResetHP();
                Console.WriteLine($"\n{Name} 처치    보상 : {DropGold}G");
            }
        }
        public void ResetHP()
        {
            isLive = true;
            CurrentHP = MaxHP; 
        }
    }

    class Slime : abMonsters
    {
        public Slime()
        {
            Name = "슬라임";
            MaxHP = 30;
            CurrentHP = MaxHP;
            Att = 4;
            DropGold = 50;
            DropEXP = 10;
            isLive = true;
        }

        public override void Attack(Player p)
        {
            Random rand = new Random();
            int skillRange = rand.Next(1, 101);
            int chance = 50;

            if (skillRange > chance)
            {
                Console.WriteLine($"{Name}의 융해로 플레이어에게 {(Att * 2) - p.Def} 피해");
                p.GetDamage(Att * 2);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{Name}의 몸통 박치기로 플레이어에게 {Att - p.Def} 피해");
                p.GetDamage(Att);
                Console.ReadKey();
            }
        }
    }

    class Goblin : abMonsters
    {
        public Goblin()
        {
            Name = "고블린";
            MaxHP = 35;
            CurrentHP = MaxHP;
            Att = 6;
            DropGold = 30;
            DropEXP = 20;
            isLive = true;
        }

        public override void Attack(Player p)
        {
            Random rand = new Random();
            int skillRange = rand.Next(1, 101);
            int chance = 70;

            if (skillRange > chance)
            {
                Console.WriteLine($"{Name}의 머리 으깨기로 플레이어에게 {(Att * 2) - p.Def} 피해");
                p.GetDamage(Att * 2);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{Name}의 곤봉으로 플레이어에게 {Att - p.Def} 피해");
                p.GetDamage(Att);
                Console.ReadKey();
            }
        }
    }
    class Bandit : abMonsters
    {
        public Bandit()
        {
            Name = "산적";
            MaxHP = 35;
            CurrentHP = MaxHP;
            Att = 8;
            DropGold = 300;
            DropEXP = 40;
            isLive = true;
        }

        public override void Attack(Player p)
        {
            Random rand = new Random();
            int skillRange = rand.Next(1, 101);
            int chance = 60;

            if (skillRange > chance)
            {
                Console.WriteLine($"{Name}의 잡아찢기로 플레이어에게 {Att - p.Def} + {Att - p.Def} + {Att - p.Def} 피해");
                p.GetDamage(Att);
                p.GetDamage(Att);
                p.GetDamage(Att);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{Name}의 단검으로 플레이어에게 {Att - p.Def} 피해");
                p.GetDamage(Att);
                Console.ReadKey();
            }
        }
    }

    class Werewolf : abMonsters
    {
        public Werewolf()
        {
            Name = "늑대인간";
            MaxHP = 70;
            CurrentHP = MaxHP;
            Att = 15;
            DropGold = 200;
            DropEXP = 50;
            isLive = true;
        }

        public override void Attack(Player p)
        {
            Random rand = new Random();
            int skillRange = rand.Next(1, 101);
            int chance = 30;

            if (skillRange > chance)
            {
                Console.WriteLine($"{Name}의 송곳니로 플레이어에게 {(Att * 3) - p.Def} 피해");
                p.GetDamage(Att);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{Name}의 후려치기로 플레이어에게 {Att - p.Def} 피해");
                p.GetDamage(Att);
                Console.ReadKey();
            }
        }
    }

    class Wyvern : abMonsters
    {
        public Wyvern()
        {
            Name = "와이번";
            MaxHP = 300;
            CurrentHP = MaxHP;
            Att = 30;
            DropGold = 500;
            DropEXP = 200;
            isLive = true;
        }

        public override void Attack(Player p)
        {
            Random rand = new Random();
            int skillRange = rand.Next(1, 101);
            int chance1 = 85;
            int chance2 = 55;

            if (skillRange > chance1)
            {
                Console.WriteLine($"{Name}의 브레스로 플레이어에게 {(Att * 3) - p.Def} 피해");
                p.GetDamage(Att * 3);
                Console.ReadKey();
            }
            else if (skillRange <= chance1 && skillRange > chance2)
            {
                Console.WriteLine($"{Name}의 움켜쥐기로 플레이어에게 {(Att / 2) - p.Def} + {(Att / 2) - p.Def} + {(Att / 2) - p.Def} 피해");
                p.GetDamage(Att / 2);
                p.GetDamage(Att / 2);
                p.GetDamage(Att / 2);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{Name}의 할퀴기로 플레이어에게 {Att - p.Def} 피해");
                p.GetDamage(Att);
                Console.ReadKey();
            }
        }
    }
}
