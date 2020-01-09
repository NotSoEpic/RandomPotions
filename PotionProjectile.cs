using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions
{
    class PotionProjectile : GlobalProjectile
    {
        public override void PostDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            int flair = Main.player[projectile.owner].GetModPlayer<PotionPlayer>().magicFlair;
            if (projectile.magic)
            {
                if (flair == 1 && Main.rand.NextBool(9)) // party
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, Main.rand.Next(139, 143), projectile.velocity.X, projectile.velocity.Y, 0, default, 1.2f);
                }
                else if (flair == 2 && Main.rand.NextBool(6)) // cursed flames
                {
                    Dust dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 0, default, 2.5f)];
                    dust.noGravity = true;
                }
                else if (flair == 3 && Main.rand.NextBool(7)) // gold
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                }
                else if (flair == 4 && Main.rand.NextBool(3)) // ichor
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 228, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                }
                else if (flair == 5 && Main.rand.NextBool(6)) // fire
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                }
                else if (flair == 6 && Main.rand.NextBool(9)) // poison
                {
                    Dust dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 46, 0f, 0f, 100, default, 0.25f)];
                    dust.fadeIn = 1.15f;
                }
                else if (flair == 7 && Main.rand.NextBool(7)) // venom
                {
                    Dust dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 171, 0f, 0f, 100, default, 1f)];
                    dust.noGravity = true;
                    dust.fadeIn = 1.35f;
                }
                else if (flair == 8 && Main.rand.NextBool(3)) // confusion
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 187, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                }
            }
        }

        public override void Kill(Projectile projectile, int timeLeft)
        {
            int flair = Main.player[projectile.owner].GetModPlayer<PotionPlayer>().magicFlair;
            if (projectile.magic)
            {
                if (flair == 1) // party
                {
                    Projectile.NewProjectile(projectile.position, projectile.velocity, 289, 0, 0);
                }
                else if (flair == 2) // cursed flames
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 0, default, 2.5f)];
                        dust.noGravity = true;
                    }
                }
                else if (flair == 3) // gold
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                    }
                }
                else if (flair == 4) // ichor
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 228, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                    }
                }
                else if (flair == 5) // fire
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                    }
                }
                else if (flair == 8) // confusion
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 187, projectile.velocity.X, projectile.velocity.Y, 0, default, 1f);
                    }
                }
            }
        }
    }
}
