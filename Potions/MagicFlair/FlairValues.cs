using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions.MagicFlair
{
    class FlairValues
    {
        public int[] flairList()
        {
            return new int[] {
                BuffType<PartyBuff>(),
                BuffType<CursedFlamesBuff>(),
                BuffType<GoldBuff>(),
                BuffType<IchorBuff>(),
                BuffType<FireBuff>(),
                BuffType<PoisonBuff>(),
                BuffType<VenomBuff>(),
                BuffType<ConfusionBuff>()
            };
        }
    }
}
