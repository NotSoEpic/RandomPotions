using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions
{
	public class HermesPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fleetfeet Potion");
			Tooltip.SetDefault("Makes you run like you are wearing hermes boots.");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
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
            item.buffType = BuffType<HermesBuff>();
            item.buffTime = 60 * 60 * 5;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Feather, 1);
            recipe.AddIngredient(ItemID.Daybloom, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

    public class HermesBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fleetfeet");
            Description.SetDefault("Makes you run like you have hermes boots.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.accRunSpeed > 0)
            {
                player.accRunSpeed += 1f;
            }
            else
            {
                player.accRunSpeed = 6f;
            }
        }
    }
}