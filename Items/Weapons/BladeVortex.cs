using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class BladeVortex : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.MagnetSphere;

        private const int max_distance = 5;
        private const int min_distance = 1;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Creates a storm of ethereal blades around the player");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.magic = true;
            item.noMelee = true;
            item.mana = 10;
            item.width = 24;
            item.height = 28;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.shoot = ModContent.ProjectileType<Projectiles.BladeVortexBlade>();
            item.shootSpeed = 30f;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.buyPrice(gold: 5);
            item.UseSound = SoundID.Item84;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ItemID.FlyingKnife);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        private float Distance => Main.rand.NextFloat(min_distance, max_distance);

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 velocity = new Vector2(speedX, speedY);
            int numBlades = 5;
            for (int i = 0; i < numBlades; i++)
            {
                float distance = Distance;
                Vector2 startPoint = player.Center + (velocity * distance);
                Projectile.NewProjectile(startPoint, velocity.RotatedBy(MathHelper.PiOver2), type, damage, knockBack, Main.myPlayer, ai0: distance);
            }
            return false;
        }
    }
}
