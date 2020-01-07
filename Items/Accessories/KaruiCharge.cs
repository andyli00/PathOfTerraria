using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Accessories
{
    public class KaruiCharge : ModItem //TODO prevent equipping both karui amulets at the same time
    {
        public override string Texture => "Terraria/Item_" + ItemID.CrossNecklace;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'For dead men require no answer.'" +
                "\n15% increased movement speed" +
                "\n25% increased ranged damage" +
                "\n+10% to ranged critical strike chance");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.15f;
            player.rangedDamage += 0.25f;
            player.rangedCrit += 10;
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RangerEmblem, 1);
            recipe.AddIngredient(mod, "KaruiWard", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
