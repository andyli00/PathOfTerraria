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
            spinningPoint = new Vector2(projectile.ai[0], projectile.ai[1]);
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);
            Vector2 toCenter = spinningPoint - projectile.Center;
            toCenter.Normalize();
            projectile.velocity = (toCenter * projectile.velocity.Length()).RotatedBy(MathHelper.ToRadians(75));
        }
    }
}
