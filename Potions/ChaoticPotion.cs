using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions
{
	public class ChaoticPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaotic Potion");
			Tooltip.SetDefault("Gives a few random potion effects\n'Don't drop it'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 6));
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
			item.value = 100;
			item.rare = 0;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("RandomPotions:DaybloomPotions", 1);
            recipe.AddRecipeGroup("RandomPotions:MoonglowPotions", 1);
            recipe.AddRecipeGroup("RandomPotions:DeathweedPotions", 1);
            recipe.AddIngredient(ItemID.CrystalShard, 3);
            recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}

        public override bool UseItem(Player player)
        {
            int[] effects = new int[]
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,26,29,48,58,59,63,104,105,106,107,108,109,110,111,112,113,114,115,116,117,119,121,122,123,
                20,21,22,23,24,25,30,31,32,33,35,36,39,44,46,67,69,70,80,88,94,103,120
            };
            for (int i = 0; i < Main.rand.Next(4, 6); i++)
            {
                int buffid = effects[Main.rand.Next(0, effects.Length)];
                if (Main.rand.NextBool())
                {
                    player.AddBuff(buffid, 60 * Main.rand.Next(15, 60));
                }
                else
                {
                    player.AddBuff(buffid, 60 * 60 * Main.rand.Next(1, 5));
                }
            }
            return true;
        }
    }
}