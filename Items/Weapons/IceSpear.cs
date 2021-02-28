using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class IceSpear : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.CrystalStorm;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires shards of ice" 
                + "\nAfter a short distance, they accelerate and pierce");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.magic = true;
            item.mana = 8;
            item.width = 24;
            item.height = 28; 
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("IceSpearProjectile");
            item.shootSpeed = 5f;
            item.autoReuse = true;
            item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostStaff, 1);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(calamityMod.ItemType("VerstaltiteBar"), 5);
            }
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles = 2 + Main.rand.Next(2); //2 or 3 projectiles
            for (int i = 0; i < numProjectiles; i++)
            {
                Vector2 perturbed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                Projectile.NewProjectile(position, perturbed, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }

    class IceSpearProjectile : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.EnchantedBeam;

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 255;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.knockBack = 3;
            projectile.light = 1f;
        }

        public override void AI()
        {
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item8, projectile.position);
            }

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
