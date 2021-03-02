using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace PathOfTerraria
{
    class PathOfTerrariaPlayer : ModPlayer
    {
        public static PathOfTerrariaPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<PathOfTerrariaPlayer>();
        }

        public bool farrulSetBonus;

        public override void ResetEffects()
        {
            farrulSetBonus = false;
        }

        public override void UpdateDead()
        {
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (farrulSetBonus && Main.rand.NextFloat() < 0.05f)
            {
                player.NinjaDodge();
                return false;
            }
            return true;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (farrulSetBonus)
            {
                target.AddBuff(BuffID.Venom, 5 * 60);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (farrulSetBonus)
            {
                target.AddBuff(BuffID.Venom, 5 * 60);
            }
        }
    }
}
