using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using SiteBMod.NPCs;
using SiteBMod.Items.Weapons;

namespace SiteBMod.NPCs
{
	public class PolluteShark : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pollute Shark");
			NPCID.Sets.MPAllowedEnemies[Type] = true;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.CaveBat);
			NPC.damage = 31;
			NPC.lifeMax = 2500;
			NPC.defense = 11;
			NPC.noGravity = true;
			NPC.scale = 1.75f;
			NPC.width = 102;
			NPC.noTileCollide = true;
			NPC.aiStyle = 86;
			NPC.npcSlots = 1f;
			NPC.value = Item.buyPrice(gold: 25);
			NPC.netAlways = true;
			NPC.height = 42;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.HealingPotion; 
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
            ItemDropRule.OneFromOptions(1, (ModContent.ItemType<OrcaGun>()), (ModContent.ItemType<ToxiBubbleLauncher>()), (ModContent.ItemType<ToxiBladeTyphoon>()));
			npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PollutedFin").Type, 1, 4, 6));
		}
	}
}