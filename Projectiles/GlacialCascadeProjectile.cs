using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class GlacialCascadeProjectile : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.FrostBoltSword;

        private const int ticksPerBurst = 15;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icicle burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 150;
            projectile.height = 150;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.alpha = 255;
        }

        private float Ticks
        {
            get => projectile.localAI[0];
            set => projectile.localAI[0] = value;
        }
        private float Bursts
        {
            get => projectile.ai[1];
            set => projectile.ai[1] = value;
        }

        public override void AI()
        {
            if (Bursts == 0)
            {
                projectile.Kill();
            }

            if (projectile.damage > 0)
            {
                deactivate();
            }

            if (Ticks > 0 && Ticks % ticksPerBurst == 0)
            {
                activate();
                makeDust();
                Bursts--;
                Main.PlaySound(SoundID.Item27, projectile.position);
            }

            Ticks++;
        }

        private void activate()
        {
            projectile.damage = 50;
        }

        private void deactivate()
        {
            projectile.damage = 0;
        }

        private void makeDust()
        {
            for (int i = 0; i < 100; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, 0f, 0f, 50, default, 1.2f);
                //Main.dust[dust].noGravity = true;
            }
        }
    }
}
