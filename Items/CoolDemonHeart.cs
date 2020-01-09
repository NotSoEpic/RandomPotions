using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RandomPotions.Items
{
    class CoolDemonHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Cooler Demon Heart");
            Tooltip.SetDefault("Permanently increases the number of accessory slots\nAlways consumable");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.consumable = true;
            item.expert = true;
            item.rare = 4;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 4;
            item.UseSound = SoundID.Item4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemonHeart);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            player.extraAccessory = true;
            item.TurnToAir();
            return true;
        }
    }
}
