using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria
{
    class PathOfTerrariaNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool maimed;

        public override void ResetEffects(NPC npc)
        {
            maimed = false;
        }

        public override void SetDefaults(NPC npc)
        {
            //npc.buffImmune[ModContent.BuffType<Buffs.Maimed>()] = npc.buffImmune[BuffID.Bleeding];
        }

        /*public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(BuffID.Bleeding))
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 100;
                if (damage < 2)
                {
                    damage = 20;
                }
            }
        }*/

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.WitchDoctor && Main.hardMode)
            {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Convocation>());
            }
            if (type == NPCID.Wizard)
            {
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Weapons.GlacialCascade>());
                }
                
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessories.ArcaneCloak>());
                }


            }
        }
    }
}
