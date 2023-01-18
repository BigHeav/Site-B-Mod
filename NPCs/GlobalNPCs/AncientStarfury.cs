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
using Terraria.ModLoader.Utilities;
using SiteBMod.Items.Materials;

namespace SiteBMod.NPCs.GlobalNPCS
{
	public class AncientStarfury : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Vulture)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DesertFeather>(), 2, 1, 3));
			}
		}
	}
}