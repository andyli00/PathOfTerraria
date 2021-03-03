using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class ScourgeShot : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.Tsunami;

        public const int baseDamage = 50;
        public const int baseSpeed = 5;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Channel to fire an arrow that leaves spore pods behind"
                + "\nSpore pods fire thorn arrows when they bloom"
                + "\nDeals more damage the longer you channel");
        }

        public override void SetDefaults()
        {
            item.damage = baseDamage;
            item.ranged = true;
            item.width = 50;
            item.height = 18;
            item.noMelee = true;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.channel = true;
            item.shoot = ModContent.ProjectileType<Projectiles.ScourgeArrowCharge>();
            item.shootSpeed = baseSpeed;
            item.value = Item.sellPrice(gold: 30);
            item.rare = ItemRarityID.Red;
            //item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteShotbow, 1);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.SpiderFang, 8);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.ScourgeArrowCharge>(), damage, knockBack, player.whoAmI);
            return false;
        }
    }
}
