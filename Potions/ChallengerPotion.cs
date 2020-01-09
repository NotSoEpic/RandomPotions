using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions
{
	public class ChallengerPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Challenger Potion");
			Tooltip.SetDefault("Greatly weakens you but makes fighting much more rewarding");
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
            item.buffType = BuffType<ChallengerBuff>();
            item.buffTime = 60 * 60 * 20;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

    public class ChallengerBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Challenger");
            Description.SetDefault("Greatly weakens you but makes fighting much more rewarding");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<PotionPlayer>().challenger = true;
        }
    }
}