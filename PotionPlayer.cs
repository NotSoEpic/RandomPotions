using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions
{
    class PotionPlayer : ModPlayer
    {
        public bool lifeFlower;
        public int magicFlair;
        public bool challenger;

        public override void ResetEffects()
        {
            lifeFlower = false;
            magicFlair = 0;
            challenger = false;
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (player.HasBuff(BuffType<Potions.OneupBuff>()))
            {
                player.ClearBuff(BuffType<Potions.OneupBuff>());
                int heal = System.Math.Max(100, player.statLifeMax2 / 2);
                player.HealEffect(heal, true);
                player.statLife = heal;
                player.immune = true;
                player.immuneTime = player.longInvince ? 180 : 120;
                for (int i = 0; i < 60; i++)
                {
                    Dust.NewDust(player.position, 30, 30, 74);
                }
                return false;
            }
            return true;
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (player.HasBuff(BuffType<Potions.OneupBuff>()) && Main.rand.NextBool(7))
            {
                Dust.NewDust(player.position, 10, 10, 74);
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (lifeFlower && player.QuickHeal_GetItemToUse() != null && player.statLife + player.QuickHeal_GetItemToUse().healLife < player.statLifeMax2)
            {
                player.QuickHeal();
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (challenger)
            {
                target.GetGlobalNPC<PotionNPC>().challenged = true;
                target.AddBuff(BuffType<Buffs.Challenged>(), 60 * 5);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (challenger)
            {
                target.GetGlobalNPC<PotionNPC>().challenged = true;
                target.AddBuff(BuffType<Buffs.Challenged>(), 60 * 5);
            }
        }

        public override void PostUpdate()
        {
            if (challenger)
            {
                player.statLifeMax2 /= 5;
                player.statLife = System.Math.Min(player.statLife, player.statLifeMax2);
                if (player.extraAccessory)
                {
                    player.extraAccessorySlots = System.Math.Max(player.extraAccessorySlots, 1);
                }
            }
        }
    }
}
