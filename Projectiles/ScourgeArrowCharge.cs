using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Projectiles
{
    class ScourgeArrowCharge: ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.SeedlerThorn;

        //1 stage per fifth second
        public const int TICKS_PER_STAGE = 12;
        public const int MAX_STAGES = 5;
        private const int MAX_CHARGE = MAX_STAGES * TICKS_PER_STAGE;

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.knockBack = 8f;
            projectile.penetrate = -1;
            projectile.alpha = 255;
        }

        private float Charge
        {
            get => projectile.localAI[0];
            set => projectile.localAI[0] = value;
        }

        private float Shot
        {
            get => projectile.localAI[1];
            set => projectile.localAI[1] = value;
        }

        private bool IsMaxCharge => Charge == MAX_CHARGE;

        public override void AI()
        {
            if (Charge == 0f)
            {
                projectile.damage = 0;
            }

            Player player = Main.player[projectile.owner];
            Charge++;
            UpdatePlayer(player);
            UpdateCharge(player);

            //release shot
            if (Shot == 1f)
            {
                Vector2 toCursor = Main.MouseWorld - player.Center;
                toCursor.Normalize();
                toCursor *= CalculateSpeed;
                Projectile.NewProjectile(player.Center, toCursor, ModContent.ProjectileType<ScourgeArrowRelease>(), CalculateDamage, projectile.knockBack, player.whoAmI, ai1: Stages);
                projectile.Kill();
            }
        }

        private int Stages
        {
            get => (Charge > MAX_CHARGE) ? MAX_CHARGE / TICKS_PER_STAGE : (int)Charge / TICKS_PER_STAGE;
        }

        private int CalculateDamage
        {
            //50% multiplicative damage per stage
            get => Items.Weapons.ScourgeShot.baseDamage * (int)Math.Pow(1.5, Stages);
        }

        private int CalculateSpeed
        {
            get => Items.Weapons.ScourgeShot.baseSpeed * (Stages + 1);
        }

        private void UpdateCharge(Player player)
        {
            if (player.channel)
            {
                projectile.Center = player.Center;
                if (IsMaxCharge)
                {
                    Main.PlaySound(SoundID.MaxMana, player.position); 
                    for (int i = 0; i < 5; i++)
                    {
                        int dust = Dust.NewDust(player.position, player.width, player.height, 45, 0f, 0f, 255, default, Main.rand.Next(20, 26) * 0.1f);
                        Main.dust[dust].noLight = true;
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 0.5f;
                    }
                }
            }
            else if (Shot == 0f) //release the shot
            {
                Shot = 1f;
            }
        }

        //make the player point at the cursor
        private void UpdatePlayer(Player player)
        {
            int direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
            player.ChangeDir(direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (Main.MouseWorld - player.Center).ToRotation();
            if (direction == -1)
            {
                player.itemRotation += (float)Math.PI;
            }
        }
    }
}
