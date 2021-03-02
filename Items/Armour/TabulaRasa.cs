using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Armour
{
    public class TabulaRasa : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.SpectreRobe;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Wipe the slate clean'.\nAdds an accessory slot.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.wornArmor = true;
            item.bodySlot = 1;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.Green;
            item.defense = 0;
        }

        public override void UpdateEquip(Player player)
        {
            player.extraAccessorySlots += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Robe, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
        }
    }
}
