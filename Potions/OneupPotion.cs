using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions
{
	public class OneupPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Extra Life Potion");
			Tooltip.SetDefault("Gives you another chance at life should you die.\nGives potion sickness\nCan't be consumed with potion sickness");
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
            item.buffType = BuffType<OneupBuff>();
            item.buffTime = 60 * 60;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Mushroom, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe.AddRecipeGroup("RandomPotions:EvilMushrooms", 1);
            recipe.AddIngredient(ItemID.JungleSpores, 3);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool CanUseItem(Player player)
        {
            return !player.HasBuff(BuffID.PotionSickness);
        }

        public override void OnConsumeItem(Player player)
        {
            int duration = 60 * (player.pStone ? 45 : 60);
            player.AddBuff(BuffID.PotionSickness, duration);
        }
    }

    public class OneupBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Extra Life");
            Description.SetDefault("Gives you another chance at life should you die.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
        }
    }
}