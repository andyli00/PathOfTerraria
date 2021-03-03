using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class ScourgeArrowThornShot : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.EatersBite;

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.arrow = true;
            projectile.scale = 0.75f;
            //projectile.aiStyle = 1;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
            Main.dust[dust].noGravity = true;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextFloat() < 0.15f)
            {
                target.AddBuff(BuffID.CursedInferno, 3 * 60);
            }
        }
    }
}
