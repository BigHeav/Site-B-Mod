using Terraria.ID;
using Terraria.ModLoader;

namespace SiteBMod.Projectiles
{
	public class ToxiBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxic Bubble"); 
		}

		public override void SetDefaults()
		{
			Projectile.width = 17;  
			Projectile.DamageType = DamageClass.Magic;
			Projectile.height = 17; 
			Projectile.friendly = true; 
			Projectile.penetrate = 1;
			Projectile.timeLeft = 60;
			Projectile.aiStyle = 72; 
			Projectile.tileCollide = true;  
		}
	}
}