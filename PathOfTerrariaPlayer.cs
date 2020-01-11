using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace PathOfTerraria
{
    class PathOfTerrariaPlayer : ModPlayer
    {
        public static PathOfTerrariaPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<PathOfTerrariaPlayer>();
        }

        //public bool gmpEquipped = false;

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /*if (gmpEquipped)
            {
                int numProjectiles = 3;
                for (int i = 0; i < numProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); //15 degrees of spread 
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                return false;
            }*/
            return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        private void ResetVariables()
        {
            //gmpEquipped = false;
        }
    }
}
