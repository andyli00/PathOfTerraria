using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class ScourgeArrowThornPod : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.SporeTrap;

        private Vector2 initialVelocity;
        private int initialDamage;

        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 15;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.scale = 1.5f;
        }

        public override void AI()
        {
            //dont want the thorn pods to move, but still need to store the velocity
            //for the thorn shots that spawn. same with damage
            if (projectile.ai[0] == 0)
            {
                initialVelocity = projectile.velocity;
                projectile.velocity = Vector2.Zero;
                initialDamage = projectile.damage;
                projectile.damage = 0;
            }

            projectile.ai[0]++;
            DoDust();

            //release thorn shots after a delay
            if (projectile.ai[0] == 15)
            {
                Main.PlaySound(SoundID.Grass, projectile.position);
                initialVelocity = initialVelocity.RotatedByRandom(MathHelper.Pi);
                int numThorns = 10;
                for (int i = 0; i < numThorns; i++)
                {
                    Vector2 perturbedVel = initialVelocity.RotatedBy(MathHelper.ToRadians(i * 360 / numThorns));
                    Projectile.NewProjectile(projectile.Center, perturbedVel, ModContent.ProjectileType<ScourgeArrowThornShot>(), initialDamage / 2, projectile.knockBack, projectile.owner);
                }
                projectile.Kill();
            }
        }

        private void DoDust()
        {
            for (int i = 0; i < 25; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 157);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.5f;
                Main.dust[dust].scale = 1.5f;
            }
        }
    }
}
