using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions
{
    class PotionItem : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.type == ItemID.DemonHeart)
            {
                return true;
            }
            return true; // base.ConsumeItem(item, player);
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.DemonHeart)
            {
                return true;
            }
            return true; // base.CanUseItem(item, player);
        }
    }
}
