using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PathOfTerraria.Items.Weapons
{
    class KaomsPrimacy : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.LunarHamaxeSolar;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Culls enemies that have 10% health or lower");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 11;
            item.useAnimation = 11;
            item.axe = 40;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 50);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarHamaxeSolar, 1);
            recipe.AddIngredient(mod, "AlchemyOrb", 50);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if ((target.life - damage) <= target.lifeMax / 10) //if target is on 10% health or lower after being hit, kills target.
            {
                player.ApplyDamageToNPC(target, target.life, knockBack, 0, crit);
            }
        }
    }
}
