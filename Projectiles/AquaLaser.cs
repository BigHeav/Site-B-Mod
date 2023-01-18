using Terraria.ID;
using Terraria.ModLoader;

namespace SiteBMod.Projectiles
{
	public class AquaLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aqua Laser"); 
		}

		public override void SetDefaults()
		{
			Projectile.width = 3;  
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.damage = 8;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 1;
			Projectile.light = 1f;
			Projectile.tileCollide = true;

			AIType = ProjectileID.Bullet;
		}
	}
}