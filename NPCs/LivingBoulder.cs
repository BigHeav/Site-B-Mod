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
using Terraria.ModLoader.Utilities;

namespace SiteBMod.NPCs
{
	public class LivingBoulder : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Boulder");
			NPCID.Sets.MPAllowedEnemies[Type] = true;
		}

		public override void SetDefaults()
		{
			NPC.damage = 31;
			NPC.lifeMax = 50;
			NPC.defense = 11;
			NPC.scale = 0.8f;
			NPC.width = 102;
			NPC.noTileCollide = false;
			NPC.aiStyle = 26;
			NPC.velocity.X += 10f;
			NPC.npcSlots = 1f;
			NPC.value = Item.buyPrice(silver: 3);
			NPC.netAlways = true;
			NPC.height = 42;
			NPC.HitSound = SoundID.Tink;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.knockBackResist = 0f;
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.Geode, 15));
			npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 1, 10, 85));
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			// we would like this npc to spawn in the overworld.
			return SpawnCondition.Cavern.Chance * 0.8f;
		}
	}
}