using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class IceSpearProjectile : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.MagicMissile;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.knockBack = 3;
            projectile.light = 1f;
            drawOriginOffsetY = -6;
        }

        public override void AI()
        {
            //spawn noise
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item8, projectile.position);
            }

            //rotate sprite
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);

            projectile.ai[0] += 1f;
            //change forms after half a second
            if (projectile.ai[0] == 30)
            {
                projectile.velocity *= 4;
                projectile.maxPenetrate = 3;
                projectile.penetrate = 3;
                projectile.damage *= 2;
                projectile.knockBack *= 2f;
                for (int i = 0; i < 2; i++)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, 0f, 0f, 50, default(Color), 1.2f);
                }
                Main.PlaySound(SoundID.Item28, projectile.position);
            }

            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.3f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 5 * 60);
        }
    }
}
