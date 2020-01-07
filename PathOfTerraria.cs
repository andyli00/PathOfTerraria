using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace PathOfTerraria
{
	public class PathOfTerraria : Mod
	{
		public PathOfTerraria()
		{
		}

		public override void AddRecipeGroups()
		{
			//any demonite bar
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Demonite Bar", new int[]
			{
				ItemID.DemoniteBar,
				ItemID.CrimtaneBar
			});
			RecipeGroup.RegisterGroup("PathOfTerraria:EvilBars", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Demonite Bow", new int[]
			{
				ItemID.DemonBow,
				ItemID.TendonBow
			});
			RecipeGroup.RegisterGroup("PathOfTerraria:EvilBows", group);
		}
	}
}