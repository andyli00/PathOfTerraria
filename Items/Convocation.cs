using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items
{
    class Convocation : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.BookofSkulls;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Recalls all your minions to your location");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 30;
            item.useAnimation = 30;
            item.reuseDelay = 30;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.buyPrice(gold: 10);
            item.mana = 10;
        }

        public override void OnConsumeMana(Player player, int manaConsumed)
        {
            foreach (Projectile proj in Main.projectile)
            {
                if (proj.friendly && proj.minion)
                {
                    proj.Center = player.Center;
                }
            }
        }
    }
}
