using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace SiteBMod.Projectiles{	public class Sandstorm : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Sandstorm");		}		public override void SetDefaults()		{			Projectile.width = 4;			Projectile.height = 4;			Projectile.scale = 3f;			Projectile.alpha = 255;			Projectile.aiStyle = -1;			Projectile.timeLeft = 3600;			Projectile.friendly = true;			Projectile.penetrate = 1;			Projectile.ignoreWater = true;			Projectile.tileCollide = true;		}        public override void AI()        {            var newColor2 = default(Color);            var num972 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 10, 0f, 0f, 100, newColor2, 2f);            Main.dust[num972].noGravity = true;            return;        }    }}