using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Buffs
{
    class Challenged : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Challenged");
            Description.SetDefault("U hav ben chalenged [sic]");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<PotionNPC>().challenged = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(BuffType<Challenged>());
        }
    }
}
