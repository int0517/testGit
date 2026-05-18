namespace Game
{
    class Player
    {
        public int Level { get; private set; }
        public int MaxEXP { get; private set; }
        public int CurrentEXP { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int StandardAtt {  get; private set; }
        public int Def { get; private set; }
        public int Gold { get; private set; }
        public bool isLive { get; private set; }
        public int ItemAtt { get; private set; }
        public int ItemHP { get; private set; }
        public bool isGuard { get; private set; }
        public int Skill1Cooldown { get; private set; }
        public int Skill2Cooldown { get; private set; }

        public Player()
        {
            Level = 1;
            CurrentEXP = 0;
            MaxEXP = 10;
            MaxHP = 20;
            CurrentHP = MaxHP;
            StandardAtt = 5;
            Def = 0;
            Gold = 500;
            isLive = true;
            isGuard = false;
            Skill1Cooldown = 0;
            Skill2Cooldown = 0;
        }

        public void PlayerInfo(Item[] invens)
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("플레이어 정보");
            Console.WriteLine($"레    벨 : {Level}");
            Console.WriteLine($"경 험 치 : {CurrentEXP} / {MaxEXP}");
            Console.WriteLine($"체    력 : {FinalHP()} ({MaxHP} + {ItemHP})");
            Console.WriteLine($"공 격 력 : {FinalAtt()} ({StandardAtt} + {ItemAtt})");
            Console.WriteLine($"방 어 력 : {Def}");
            Console.WriteLine($"소 지 금 : {Gold}G");
            Console.WriteLine("\n소지 아이템");
            Console.WriteLine($"무    기 : {invens[0].Name}");
            Console.WriteLine($"방    패 : {invens[1].Name}");
            Console.WriteLine($"방 어 구 : {invens[2].Name}");
            Console.WriteLine($"체력포션 : {invens[3].Name} {invens[3].Count}개");
            Console.WriteLine($"폭    탄 : {invens[4].Name} {invens[4].Count}개");
            Console.WriteLine("=================================================");
            Console.ReadKey();
        }

        public void Attack(abMonsters m)
        {
            Console.WriteLine($"플레이어의 공격    {FinalAtt()} 피해");
            m.GetDamage(FinalAtt(), this);
            Console.ReadKey();
        }
        public bool Skill1(abMonsters m) // 강타
        {
            if (Skill1Cooldown == 0)
            {
                Console.WriteLine($"플레이어의 강타    {FinalAtt() * 2} 피해");
                m.GetDamage(FinalAtt() * 2, this);
                Skill1Cooldown = 3;
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("쿨타임입니다.");
                Console.ReadKey();
                return false;
            }
        }
        public bool Skill2(abMonsters m) // 가르기
        {
            if (Skill2Cooldown == 0)
            {
                Console.WriteLine($"플레이어의 가르기    {FinalAtt()} + {FinalAtt()} 피해");
                m.GetDamage(FinalAtt(), this);
                m.GetDamage(FinalAtt(), this);
                Skill2Cooldown = 3;
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("쿨타임입니다.");
                Console.ReadKey();
                return false;
            }
        }
        public void SkillCooldown()
        {
            if (Skill1Cooldown != 0) Skill1Cooldown--;
            if (Skill2Cooldown != 0) Skill2Cooldown--;
        }
        public void Guard()
        {
            isGuard = true;
            Console.WriteLine("플레이어의 방어    이번 턴에 받는 피해가 반으로 감소");
            Console.ReadKey();
        }

        public void GetDamage(int damage)
        {
            if (!this.isLive) return;

            int totalDamage = damage - Def;
            if (totalDamage <= 0) totalDamage = 1;

            if (isGuard)
            {
                totalDamage = totalDamage / 2;
                isGuard = false;
            }

            if (CurrentHP > totalDamage)
            {
                CurrentHP -= totalDamage;
            }
            else
            {
                CurrentHP = 0;
                isLive = false;

                // 사망 처리
                Console.WriteLine("플레이어 사망");
            }
        }

        public void GetGold(int amount)
        {
            Gold += amount;
        }

        public void GetEXP(int amount)
        {
            CurrentEXP += amount;
            if (CurrentEXP >= MaxEXP)
            {
                CurrentEXP -= MaxEXP;
                Level++;
                MaxEXP += 10;
                StandardAtt += 2;
                MaxHP += 3;
                Console.WriteLine($"플레이어 레벨업!    현재 레벨 : {Level}");
            }
        }

        public int FinalAtt()
        {
            return StandardAtt + ItemAtt;
        }
        public int FinalHP()
        {
            return MaxHP + ItemHP;
        }

        public void ResetHP()
        {
            isLive = true;
            CurrentHP = FinalHP();
            Skill1Cooldown = 0;
            Skill2Cooldown = 0;
        }
        public void Heal(int amount)
        {
            CurrentHP += amount;
            if (CurrentHP > FinalHP()) CurrentHP = FinalHP();
        }

        public void StatApply()
        {
            ItemAtt = 0;
            Def = 0;
            ItemHP = 0;

            foreach (Item i in Inventory.invens)
            {
                if (i == null) continue;
                ItemAtt += i.AddAtt;
                Def += i.AddDef;
                ItemHP += i.AddHP;
            }
        }
    }
}