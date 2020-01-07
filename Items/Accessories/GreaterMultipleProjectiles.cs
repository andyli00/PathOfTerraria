using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Accessories
{
    class GreaterMultipleProjectiles : ModItem //TODO add price, rarity, and crafting recipe
    {
        public override string Texture => "Terraria/Item_" + ItemID.Radar;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fire 3 extra projectiles\n33% less damage");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamageMult *= 0.66f;
            PathOfTerrariaPlayer modPlayer = PathOfTerrariaPlayer.ModPlayer(player);
            modPlayer.gmpEquipped = true;
        }
    }
}
