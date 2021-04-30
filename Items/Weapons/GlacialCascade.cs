using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class GlacialCascade : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RazorbladeTyphoon;

        private const int numBursts = 5;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Creates a cascade of icicle bursts");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.magic = true;
            item.mana = 12;
            item.width = 24;
            item.height = 28;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.shoot = ModContent.ProjectileType<Projectiles.GlacialCascadeProjectile>();
            item.shootSpeed = 4f;
            item.rare = ItemRarityID.Pink;
            item.value = Item.buyPrice(gold: 20);
            item.UseSound = SoundID.Item8;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.GlacialCascadeProjectile>(), 50, 5f, player.whoAmI, ai1: numBursts);
            return false;
        }
    }
}
