using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Potions.MagicFlair
{
	public class VenomPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Vial of Venom");
			Tooltip.SetDefault("Magic attacks inflict venom on enemies\nNot to be confused with [c/0645AD:vial of venom], a crafting material.");
		}

		public override void SetDefaults() 
		{
			item.width = 14;
			item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
			item.value = 100;
			item.rare = 4;
            item.buffType = BuffType<VenomBuff>();
            item.buffTime = 60 * 60 * 20;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.VialofVenom, 5);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void OnConsumeItem(Player player)
        {
            int[] buffs = new FlairValues().flairList();
            foreach (int i in buffs)
            {
                if (i != item.buffType) player.ClearBuff(i);
            }
        }
    }

    public class VenomBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("[c/C402DA:Magic Flair: Venom]");
            Description.SetDefault("Magic attacks inflict venom on enemies");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<PotionPlayer>().magicFlair = 7;
        }
    }
}