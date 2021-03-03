using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class ScourgeArrowRelease : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.ChlorophyteArrow;

        private int sporePodsCreated = 0;

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.penetrate = -1;
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        private int Stages
        {
            get => (int)projectile.ai[1];
        }

        public override void AI()
        {
            projectile.ai[0]++;
            DoDust();
            //rotate sprite
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);

            //gravity
            if (projectile.ai[0] >= 15)
            {
                projectile.velocity.Y += 0.1f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }

            if (projectile.ai[0] % (ScourgeArrowCharge.TICKS_PER_STAGE / 2) == 0 && sporePodsCreated < Stages)
            {
                sporePodsCreated++;
                Projectile.NewProjectile(projectile.Center, projectile.velocity, ModContent.ProjectileType<ScourgeArrowThornPod>(), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }

        private void DoDust()
        {
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 40);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1.3f;
            Main.dust[dust].velocity *= 0.5f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 3 * 60);
        }
    }
}
