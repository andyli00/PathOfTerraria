using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Armour
{
    class FarrulsFur : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.FossilShirt;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("15% increased ranged and throwing critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.wornArmor = true;
            item.bodySlot = 1;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 15;
            player.thrownCrit += 15;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TigerSkin, 1);
            recipe.AddIngredient(ItemID.FossilShirt, 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TigerSkin, 1);
            recipe.AddIngredient(ItemID.FossilShirt, 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
