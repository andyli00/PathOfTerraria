using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Accessories
{
    public class KaruiWard : KaruiAmulet
    {
        public override string Texture => "Terraria/Item_" + ItemID.CrossNecklace;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Shoot first, ask no questions.'" +
                "\n15% increased movement speed" +
                "\n10% increased ranged damage");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.15f;
            player.rangedDamage += 0.15f;
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Aglet, 1);
            recipe.AddRecipeGroup("PathOfTerraria:EvilBars", 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
         }
    }
}
