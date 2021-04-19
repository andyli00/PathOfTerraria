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
        public bool arcaneCloak;

        public override void ResetEffects()
        {
            farrulSetBonus = false;
            arcaneCloak = false;
        }

        public override void UpdateDead()
        {
        }

        public override void GetWeaponDamage(Item item, ref int damage)
        {
            if (arcaneCloak && item.magic)
            {
                float manaPercent = (float)player.statMana / player.statManaMax2;
                //damage boost of 20% at max mana
                damage += (int)(damage * manaPercent / 4);
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (farrulSetBonus && Main.rand.NextFloat() < 0.05f)
            {
                player.NinjaDodge();
                return false;
            }

            if (arcaneCloak)
            {
                //30% damage reduction
                int reduction = (int)((float)damage * 0.3);
                Main.NewText(damage + "," + reduction);

                //if the damage reduction is more than the mana than the 
                //player has left, consume the rest of player's mana
                //otherwise, normal 30% reduction
                if (reduction > player.statMana)
                {
                    reduction = player.statMana;
                }
                damage -= reduction;
                player.statMana -= reduction;
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
