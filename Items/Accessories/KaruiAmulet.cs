using Terraria;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Accessories
{
    public abstract class KaruiAmulet : ModItem
    {
        public override bool CanEquipAccessory(Player player, int slot)
        {
            if (slot < 10)
            {
                int index = FindDifferentKaruiAmulet().index;
                if (index != -1)
                {
                    return slot == index;
                }
            }

            return base.CanEquipAccessory(player, slot);
        }

        public override bool CanRightClick()
        {
            int maxIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
            for (int i = 13; i < 13 + maxIndex; i++)
            {
                if (Main.LocalPlayer.armor[i].type == item.type)
                {
                    return false;
                }
            }

            if (FindDifferentKaruiAmulet().accessory != null)
            {
                return true;
            }

            return base.CanRightClick();
        }

        public override void RightClick(Player player)
        {
            var (index, accessory) = FindDifferentKaruiAmulet();
            if (accessory != null)
            {
                Main.LocalPlayer.QuickSpawnClonedItem(accessory);
                Main.LocalPlayer.armor[index] = item.Clone();
            }
        }

        protected (int index, Item accessory) FindDifferentKaruiAmulet()
        {
            int maxIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
            for (int i = 3; i < 3 + maxIndex; i++)
            {
                Item otherAcc = Main.LocalPlayer.armor[i];
                if (!otherAcc.IsAir && !item.IsTheSameAs(otherAcc) && otherAcc.modItem is KaruiAmulet)
                {
                    return (i, otherAcc);
                }
            }

            return (-1, null);
        }
    }
}
