using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomPotions
{
    class PotionNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool challenged;

        public override void ResetEffects(NPC npc)
        {
            challenged = false;
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            int flair = Main.player[projectile.owner].GetModPlayer<PotionPlayer>().magicFlair;
            if (projectile.magic)
            {
                if (flair == 1) // party
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, Main.rand.Next(139, 143), projectile.velocity.X, projectile.velocity.Y, 0, default, 1.2f);
                    }
                }
                else if (flair == 2) // cursed flames
                {
                    npc.AddBuff(BuffID.CursedInferno, 60 * 5);
                }
                else if (flair == 3) // gold
                {
                    npc.AddBuff(BuffID.Midas, 60 * 2);
                }
                else if (flair == 4) // ichor
                {
                    npc.AddBuff(BuffID.Ichor, 60 * Main.rand.Next(10, 20));
                }
                else if (flair == 5) // fire
                {
                    npc.AddBuff(BuffID.OnFire, 60 * 6);
                }
                else if (flair == 6) // poison
                {
                    npc.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 10));
                }
                else if (flair == 7) // venom
                {
                    npc.AddBuff(BuffID.Venom, 60 * Main.rand.Next(5, 10));
                }
                else if (flair == 8) // confusion
                {
                    npc.AddBuff(BuffID.Confused, 60 * Main.rand.Next(1, 4));
                }
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (challenged)
            {
                if (npc.boss)
                {
                    npc.value *= 2.5f;
                    npc.DropBossBags();
                    Projectile.NewProjectile(npc.position, npc.velocity, 289, 0, 0);
                }
                else
                {
                    npc.value *= 1.5f;
                }
            }
        }
    }
}
