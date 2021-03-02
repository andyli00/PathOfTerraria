using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class ShiverSting : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.Frostbrand;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires an icy blade that splits upon hitting an enemy");
        }

        public override void SetDefaults()
        {
            item.damage = 85;
            item.melee = true;
            item.width = 24;
            item.height = 28;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8f;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.FrostBlade>();
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Frostbrand, 1);
            //recipe.AddIngredient(ItemID.Ectoplasm, 5);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(calamityMod.ItemType("CryoBar"), 8);
            }
            else
            {
                recipe.AddIngredient(ItemID.HallowedBar, 8);
            }
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
