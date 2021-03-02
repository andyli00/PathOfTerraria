using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Armour
{
    class FarrulsBite : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.FossilHelm;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("18% increased ranged and throwing damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.wornArmor = true;
            item.headSlot = 1;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.18f;
            player.thrownDamage += 0.18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TigerSkin, 1);
            recipe.AddIngredient(ItemID.FossilHelm, 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TigerSkin, 1);
            recipe.AddIngredient(ItemID.FossilHelm, 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<FarrulsFur>() && legs.type == ModContent.ItemType<FarrulsChase>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Become the aspect of Farrul"
                + "\nGain stealth while not moving"
                + "\nPoison enemies on hit" 
                + "\n5% chance to dodge hits";
            player.GetModPlayer<PathOfTerrariaPlayer>().farrulSetBonus = true;
        }
    }
}
