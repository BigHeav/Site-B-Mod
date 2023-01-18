using Terraria.ID;
using Terraria.ModLoader;

namespace SiteBMod.Projectiles
{
	public class AeonBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeon Beam"); 
		}

		public override void SetDefaults()
		{
			Projectile.width = 17;  
			Projectile.DamageType = DamageClass.Melee;
			Projectile.height = 17; 
			Projectile.friendly = true; 
			Projectile.penetrate = 8;  
			Projectile.aiStyle = 81; 
			Projectile.tileCollide = true;  
		}
	}
}