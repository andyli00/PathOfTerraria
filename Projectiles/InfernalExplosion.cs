using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class InfernalExplosion : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.InfernoFriendlyBlast;

        public override void SetDefaults()
        {
            projectile.width = 150;
            projectile.height = 150;
            projectile.melee = true;
			projectile.friendly = true;
			projectile.knockBack = 5f;
			projectile.penetrate = -1;
			projectile.timeLeft = 3;
        }

		public override void AI()
		{
			if (projectile.ai[0] == 0)
			{
                //create a vanilla explosion that deals no damage just for the visual effect
				Projectile.NewProjectile(projectile.position.X + projectile.width / 2f, projectile.position.Y + projectile.height / 2, 0f, 0f, ProjectileID.SolarWhipSwordExplosion, 0, 0f, projectile.owner);
			}
		}

        //explosions that kill enemies can cause more explosions, creating a chain
        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
        {   
            if (damage >= target.life)
            {
                int explosionDamage = damage + (int)(target.lifeMax * 0.05f);
				Projectile.NewProjectile(target.position, new Vector2(0, 0), ModContent.ProjectileType<InfernalExplosion>(), explosionDamage, knockBack, projectile.owner);
			}
        }
    }
}
