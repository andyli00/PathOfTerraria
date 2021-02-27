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
            item.damage = 85;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.axe = 40;
            item.useStyle = 1;
            item.knockBack = 8f;
            item.value = Item.sellPrice(gold: 30);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenHamaxe, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            //if calamity mod is present, requires scoria bars
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(calamityMod.ItemType("CruptixBar"), 8);
            }
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            //if target is on 10% health or lower after being hit, kills target.
            //does not work on bosses
            if (!target.boss && (target.life - damage) <= target.lifeMax / 10)
            {
                player.ApplyDamageToNPC(target, target.life, knockBack, 0, crit);
            }
        }
    }
}
