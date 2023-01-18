using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Bestiary;
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
using SiteBMod.Systems;
using SiteBMod.Projectiles;

namespace SiteBMod.NPCs
{
	[AutoloadBossHead]
	public class LaserHell : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Hell");
			NPCID.Sets.MPAllowedEnemies[Type] = true;
		}

		public override void SetDefaults()
		{
			NPC.damage = 120;
			NPC.lifeMax = 180000;
			NPC.defense = 11;
			NPC.noGravity = true;
			NPC.scale = 2.75f;
			NPC.width = 100;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.aiStyle = 56;
			NPC.npcSlots = 10f;
			NPC.value = Item.buyPrice(platinum: 25);
			NPC.netAlways = true;
			NPC.height = 100;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}
		public override void OnKill()
		{
			NPC.SetEventFlagCleared(ref DownedBossSystem.downedLaserHell, -1);
		}
		public override void AI()
		{
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
			{
				NPC.TargetClosest();
			}

			Player player = Main.player[NPC.target];

			if (player.dead)
			{
				// If the targeted player is dead, flee
				NPC.velocity.Y -= 0.65f;
				// This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
				NPC.EncourageDespawn(10);
				return;
			}
			NPC.rotation = NPC.velocity.X * 0.02f;
			Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), 2f, 2f, 2f);
			NPC.TargetClosest();
			if (Main.player[NPC.target].dead)
			{
				NPC.velocity.Y = NPC.velocity.Y - 0.04f;
				if (NPC.timeLeft > 10)
				{
					NPC.timeLeft = 10;
					return;
				}
			}
			base.NPC.ai[1] += 1f;
			if (!(base.NPC.ai[1] >= 150f))
			{
				return;
			}
			float rotation = (float)Math.Atan2(base.NPC.Center.Y - Main.player[base.NPC.target].Center.Y, base.NPC.Center.X - Main.player[base.NPC.target].Center.X);
			float speed2 = 12f;
			for (float f = 0f; f <= 0.3f; f += 0.1f)
			{
				int p2 = Projectile.NewProjectile(base.NPC.GetSource_FromAI(), base.NPC.Center.X, base.NPC.Center.Y, (float)(Math.Cos(rotation + f) * (double)speed2 * -1.0f), (float)(Math.Sin(rotation + f) * 12.0 * -1.0), ProjectileID.DeathLaser, 20, 0f, base.NPC.target, 0f, 0f);
				Main.projectile[p2].timeLeft = 90;
				Main.projectile[p2].damage = 78;
				Main.projectile[p2].friendly = false;
				Main.projectile[p2].hostile = true;
				Main.projectile[p2].tileCollide = false;
				if (Main.netMode != 0)
				{
					NetMessage.SendData(27, -1, -1, NetworkText.Empty, p2);
				}
				p2 = Projectile.NewProjectile(base.NPC.GetSource_FromAI(), base.NPC.Center.X, base.NPC.Center.Y, (float)(Math.Cos(rotation - f) * (double)speed2 * -1.0f), (float)(Math.Sin(rotation - f) * 12.0 * -1.0), ProjectileID.DeathLaser, 20, 0f, base.NPC.target, 0f, 0f);
				Main.projectile[p2].timeLeft = 90;
				Main.projectile[p2].damage = 78;
				Main.projectile[p2].friendly = false;
				Main.projectile[p2].hostile = true;
				Main.projectile[p2].tileCollide = false;
				if (Main.netMode != 0)
				{
					NetMessage.SendData(27, -1, -1, NetworkText.Empty, p2);
				}
			}
			base.NPC.ai[1] = 0f;
			return;
		}
	}
}