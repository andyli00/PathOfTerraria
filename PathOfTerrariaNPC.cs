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
            npc.buffImmune[ModContent.BuffType<Buffs.Maimed>()] = npc.buffImmune[BuffID.Bleeding];
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (maimed)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 10;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
        }
    }
}
