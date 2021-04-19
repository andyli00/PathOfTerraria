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
            item.shoot = ModContent.ProjectileType<Projectiles.IceSpearProjectile>();
            item.shootSpeed = 5f;
            item.autoReuse = true;
            item.rare = ItemRarityID.Pink;
            item.value = Item.buyPrice(gold: 5);
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
}
