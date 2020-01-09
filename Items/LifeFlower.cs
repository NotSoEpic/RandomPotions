using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomPotions.Items
{
    class LifeFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Automatically use health potions when needed");
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
            recipe.AddIngredient(ItemID.JungleRose, 1);
            recipe.AddIngredient(ItemID.HealingPotion, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PotionPlayer>().lifeFlower = true;
        }
    }
}
