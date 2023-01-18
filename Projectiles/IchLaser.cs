using Terraria.ID;
using Terraria.ModLoader;

namespace SiteBMod.Projectiles
{
	public class IchLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Laser"); 
		}

		public override void SetDefaults()
		{
			Projectile.width = 3;  
			Projectile.damage = 65;
			Projectile.height = 32;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 1;
			Projectile.light = 1f;
			Projectile.tileCollide = true;

			AIType = ProjectileID.Bullet;
		}
	}
}