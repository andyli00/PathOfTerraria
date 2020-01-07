using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Materials
{
    class AlchemyOrb : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.MusketBall;

        public override void SetDefaults()
        {
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.value = Item.sellPrice(silver: 1);
            item.rare = ItemRarityID.Blue;
        }
    }
}
