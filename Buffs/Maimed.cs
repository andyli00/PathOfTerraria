using Terraria;
using Terraria.ModLoader;

namespace PathOfTerraria.Buffs
{
    class Maimed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Maimed");
            Description.SetDefault("Bleeding out");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<PathOfTerrariaPlayer>().maimed = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<PathOfTerrariaNPC>().maimed = true;
        }
    }
}
