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
using SiteBMod.Items.Weapons;

namespace SiteBMod.NPCs.GlobalNPCS
{
	public class TombCrawlerGlobal : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.TombCrawlerHead)
			{
				npcLoot.Add(ItemDropRule.Common(ItemID.ThunderStaff, 50));
				npcLoot.Add(ItemDropRule.Common(ItemID.ThunderSpear, 50));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LightningBow>(), 50));
				npcLoot.Add(ItemDropRule.Common(ItemID.MysticCoilSnake, 50));
				npcLoot.Add(ItemDropRule.Common(ItemID.MagicConch, 50));
				npcLoot.Add(ItemDropRule.Common(ItemID.AncientChisel, 50));
				npcLoot.Add(ItemDropRule.Common(ItemID.SandBoots, 75));
				npcLoot.Add(ItemDropRule.Common(ItemID.FlyingCarpet, 75));
				npcLoot.Add(ItemDropRule.Common(ItemID.SandstorminaBottle, 75));
			
			}
		}
	}
}