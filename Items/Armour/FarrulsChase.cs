using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Armour
{
    class FarrulsChase : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.FossilPants;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("20% increased movement speed"
                + "\n15% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.wornArmor = true;
            item.legSlot = 1;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.2f;
            player.thrownVelocity += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TigerSkin, 1);
            recipe.AddIngredient(ItemID.FossilPants, 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TigerSkin, 1);
            recipe.AddIngredient(ItemID.FossilPants, 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
