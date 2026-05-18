namespace Game
{   
    class Inventory
    {
        // 인벤토리 슬롯
        // 0 : 무기
        // 1 : 방패
        // 2 : 갑옷
        // 3 : 포션
        // 4 : 폭탄
        private int maxInven = 5;
        public static Item[] invens;

        public Inventory()
        { 
            invens = new Item[maxInven];
            invens[0] = Item.Weapons[0];
            invens[1] = Item.Shields[0];
            invens[2] = Item.Armors[0];
            invens[3] = Item.UsableItem[0]; // 포션
            invens[4] = Item.UsableItem[1]; // 폭탄
        }
    }
}