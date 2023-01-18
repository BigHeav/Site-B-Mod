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
	public class CorruptedEyeChance : GlobalNPC
	{
		public override void ModifyGlobalLoot(GlobalLoot globalLoot)
		{
			globalLoot.Add(ItemDropRule.ByCondition(new Conditions.CorruptKeyCondition(), ModContent.ItemType<CorruptedEye>(), 100));
		}
	}
}