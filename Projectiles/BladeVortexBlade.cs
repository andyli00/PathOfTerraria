using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class BladeVortexBlade : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.TerraBeam;

        private Vector2 spinningPoint;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ethereal Blade");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.timeLeft = 5 * 60;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.light = 0.5f;
            drawOffsetX = -19;
            drawOriginOffsetX = 13;
        }

        public override void AI()
        {
            Player myOwner = Main.player[projectile.owner];

            //make sure the rotation direction is correct
            spinningPoint = myOwner.Center;
            Vector2 toCenter = spinningPoint - projectile.Center;
            toCenter.Normalize();
            //TODO for some reason projectiles slowly get farther away from the player and i dont know why
            projectile.velocity = (toCenter * projectile.velocity.Length()).RotatedBy(MathHelper.PiOver2);

            //make the projectile visually face the right direction
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver4;

            //make sure the rotation stays constant even if the player is moving
            projectile.velocity += myOwner.velocity;
            projectile.velocity.Normalize();
            projectile.velocity *= 30;
        }
    }
}
