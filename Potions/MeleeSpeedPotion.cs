using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions
{
	public class MeleeSpeedPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Melee Speed Potion");
			Tooltip.SetDefault("Increases melee speed by 20%");
		}

		public override void SetDefaults() 
		{
			item.width = 16;
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
            item.buffType = BuffType<MeleeSpeedBuff>();
            item.buffTime = 60 * 60 * 4;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddIngredient(ItemID.Daybloom, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

    public class MeleeSpeedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Melee Speed");
            Description.SetDefault("Increases melee speed by 20%");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed += 0.2f;
        }
    }
}