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
using SiteBMod.NPCs;

namespace SiteBMod.NPCs
{
    public class DamnedSoul : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Damned Soul");
        }

        public override void SetDefaults()
        {
            NPC.damage = 24;
            NPC.lifeMax = 50;
            NPC.defense = 4;
            NPC.noGravity = true;
            NPC.width = 140;
            NPC.aiStyle = -1;
            NPC.npcSlots = 1f;
            NPC.scale = 0.7f;
            NPC.value = 410f;
            NPC.height = 140;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // we would like this npc to spawn in the overworld.
            return SpawnCondition.OverworldNightMonster.Chance * 0.8f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("DamnedEssence").Type, 3));
        }
        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
            {
                NPC.TargetClosest(true);
            }
            var vector17 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
            var num149 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2;
            var num150 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2;
            num149 = (int)(num149 / 8f) * 8;
            num150 = (int)(num150 / 8f) * 8;
            vector17.X = (int)(vector17.X / 8f) * 8;
            vector17.Y = (int)(vector17.Y / 8f) * 8;
            num149 -= vector17.X;
            num150 -= vector17.Y;
            var num151 = (float)Math.Sqrt(num149 * num149 + num150 * num150);
            var num152 = num151;
            if (num151 == 0f)
            {
                num149 = NPC.velocity.X;
                num150 = NPC.velocity.Y;
            }
            else
            {
                num151 = 4f / num151;
                num149 *= num151;
                num150 *= num151;
            }
            if (num152 > 100f)
            {
                NPC.ai[0] += 1f;
                if (NPC.ai[0] > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.023f;
                }
                else
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.023f;
                }
                if (NPC.ai[0] < -100f || NPC.ai[0] > 100f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.023f;
                }
                else
                {
                    NPC.velocity.X = NPC.velocity.X - 0.023f;
                }
                if (NPC.ai[0] > 200f)
                {
                    NPC.ai[0] = -200f;
                }
            }
            if (num152 < 150f)
            {
                NPC.velocity.X = NPC.velocity.X + num149 * 0.007f;
                NPC.velocity.Y = NPC.velocity.Y + num150 * 0.007f;
            }
            if (Main.player[NPC.target].dead)
            {
                num149 = NPC.direction * 4f / 2f;
                num150 = -4f / 2f;
            }
            if (NPC.velocity.X < num149)
            {
                NPC.velocity.X = NPC.velocity.X + 0.02f;
                if (NPC.velocity.X < 0f && num149 > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.02f;
                }
            }
            else if (NPC.velocity.X > num149)
            {
                NPC.velocity.X = NPC.velocity.X - 0.02f;
                if (NPC.velocity.X > 0f && num149 < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.02f;
                }
            }
            if (NPC.velocity.Y < num150)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.02f;
                if (NPC.velocity.Y < 0f && num150 > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.02f;
                }
            }
            else if (NPC.velocity.Y > num150)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.02f;
                if (NPC.velocity.Y > 0f && num150 < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.02f;
                }
            }
            var num157 = 0.7f;
            if (NPC.collideX)
            {
                NPC.netUpdate = true;
                NPC.velocity.X = NPC.oldVelocity.X * -num157;
                if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 2f)
                {
                    NPC.velocity.X = 2f;
                }
                if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -2f)
                {
                    NPC.velocity.X = -2f;
                }
            }
            if (NPC.collideY)
            {
                NPC.netUpdate = true;
                NPC.velocity.Y = NPC.oldVelocity.Y * -num157;
                if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1.5)
                {
                    NPC.velocity.Y = 2f;
                }
                if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1.5)
                {
                    NPC.velocity.Y = -2f;
                }
            }
            else if (Main.rand.Next(20) == 0)
            {
                var num160 = 18;
                var num161 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), num160, NPC.velocity.X, 2f, 75, NPC.color, NPC.scale);
                var dust13 = Main.dust[num161];
                dust13.velocity.X = dust13.velocity.X * 0.5f;
                var dust14 = Main.dust[num161];
                dust14.velocity.Y = dust14.velocity.Y * 0.1f;
            }
            else if (Main.rand.Next(40) == 0)
            {
                var num162 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), 5, NPC.velocity.X, 2f, 0, default(Color), 1f);
                var dust15 = Main.dust[num162];
                dust15.velocity.X = dust15.velocity.X * 0.5f;
                var dust16 = Main.dust[num162];
                dust16.velocity.Y = dust16.velocity.Y * 0.1f;
            }
            if (Main.dayTime || Main.player[NPC.target].dead)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.02f * 2f;
                if (NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                }
            }
            if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) || (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) && !NPC.justHit)
            {
                NPC.netUpdate = true;
                return;
            }
        }
    }
}