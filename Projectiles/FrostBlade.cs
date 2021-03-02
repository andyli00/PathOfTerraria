using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class FrostBlade : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.EnchantedBeam;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.knockBack = 5;
            projectile.light = 1f;
            projectile.aiStyle = 27;
        }

        public override void AI()
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.3f;
            }
		}

        //split projectile on hit
        //projectiles spawned from a split cannot split into more
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextFloat() < 0.10f)
            {
                target.AddBuff(BuffID.Frostburn, 5 * 60);
            }

            if (projectile.ai[0] == 1f)
            {
                return;
            }

            float targetSize = new Vector2(target.width, target.height).Length();
            Vector2 newPos = projectile.position + Vector2.Normalize(projectile.velocity) * targetSize;
            for (int i = 0; i < 6; i++)
            {
                Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(45));
                int proj = Projectile.NewProjectile(newPos, perturbedSpeed, ModContent.ProjectileType<FrostBlade>(), damage, 5, projectile.owner);
                Main.projectile[proj].ai[0] = 1f;
            }
        }
    }
}
