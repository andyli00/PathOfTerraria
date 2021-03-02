using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class InfernalBlade : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.FieryGreatsword;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Enemies explode on death, dealing damage based on their health");
        }

        public override void SetDefaults()
        {
            item.damage = 300;
            item.melee = true;
            item.width = 24;
            item.height = 28;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 15f;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (damage >= target.life)
            {
                int explosionDamage = damage + (int)(target.lifeMax * 0.05f);
                Projectile.NewProjectile(target.position.X + target.width / 2f, target.position.Y + target.height / 2f, 0f, 0f, ModContent.ProjectileType<Projectiles.InfernalExplosion>(), explosionDamage, knockBack, player.whoAmI);
            }
        }
    }
}
