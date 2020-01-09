using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RandomPotions
{
	public class RandomPotions : Mod
	{
		public RandomPotions()
		{

		}

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Mushroom", new int[]
            {
                ItemID.VileMushroom,
                ItemID.ViciousMushroom
            });
            RecipeGroup.RegisterGroup("RandomPotions:EvilMushrooms", group);

            group = new RecipeGroup(() => "Recall or Wormhole Potion", new int[]
            {
                ItemID.RecallPotion,
                ItemID.WormholePotion
            });
            RecipeGroup.RegisterGroup("RandomPotions:TeleportPotion", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Daybloom Buff Potion", new int[]
            {
                ItemID.ArcheryPotion,
                ItemID.CalmingPotion,
                ItemID.FeatherfallPotion,
                ItemID.HeartreachPotion,
                ItemID.HunterPotion,
                ItemID.IronskinPotion,
                ItemID.ManaRegenerationPotion,
                ItemID.RegenerationPotion,
                ItemID.ShinePotion
            });
            RecipeGroup.RegisterGroup("RandomPotions:DaybloomPotions", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Moonglow Buff Potion", new int[]
            {
                ItemID.AmmoReservationPotion,
                ItemID.BuilderPotion,
                ItemID.CratePotion,
                ItemID.InvisibilityPotion,
                ItemID.LifeforcePotion,
                ItemID.MagicPowerPotion,
                ItemID.ManaRegenerationPotion,
                ItemID.SpelunkerPotion,
                ItemID.SummoningPotion
            });
            RecipeGroup.RegisterGroup("RandomPotions:MoonglowPotions", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Deathweed Buff Potion", new int[]
            {
                ItemID.BattlePotion,
                ItemID.CratePotion,
                ItemID.GravitationPotion,
                ItemID.MagicPowerPotion,
                ItemID.RagePotion,
                ItemID.StinkPotion,
                ItemID.ThornsPotion,
                ItemID.TitanPotion,
                ItemID.WrathPotion
            });
            RecipeGroup.RegisterGroup("RandomPotions:DeathweedPotions", group);
        }
    }
}