using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class DeathsOpus : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.Marrow;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Another hears Death's final song.");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.noMelee = true;
            item.useTime = 27; //'average' speed
            item.useAnimation = 27;
            item.useStyle = 5;
            item.UseSound = SoundID.Item5;
            item.width = 14; //use same dimensions as Marrow
            item.height = 32;
            item.shoot = 1;
            item.shootSpeed = 6f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AlchemyOrb", 10);
            recipe.AddRecipeGroup("PathOfTerraria:EvilBows");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles = 3;
            for (int i = 0; i < numProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); //15 degrees of spread 
                float scale = 1f - (Main.rand.NextFloat() * 0.2f);
                perturbedSpeed *= scale; //slightly randomized speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; 
        }
    }
}
