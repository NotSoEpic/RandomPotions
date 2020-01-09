using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Items
{
    class ManaLifeFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("8% reduced mana usage\nAutomatically use health and mana potions when needed");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 44;
            item.accessory = true;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaFlower, 1);
            recipe.AddIngredient(ItemType<LifeFlower>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaFlower = true;
            player.GetModPlayer<PotionPlayer>().lifeFlower = true;
            player.manaCost -= 0.08f;
        }
    }
}
