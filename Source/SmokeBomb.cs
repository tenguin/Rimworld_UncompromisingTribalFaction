using RimWorld;
using Verse;

namespace UncompromisingTribalFaction
{
	public class SmokeBomb : Apparel
	{
		private float ApparelScorePerBeltRadius = 0.046f;
		public override void Notify_BulletImpactNearby(BulletImpactData impactData)
		{
			base.Notify_BulletImpactNearby(impactData);
			Pawn wearer = base.Wearer;
			if (wearer != null && !wearer.Dead && !impactData.bullet.def.projectile.damageDef.isExplosive && impactData.bullet.Launcher != null &&
				impactData.bullet.Launcher.HostileTo(base.Wearer) && !wearer.IsColonist && wearer.Spawned)
			{
				Gas gas = wearer.Position.GetGas(wearer.Map);
				if (gas == null || !gas.def.gas.blockTurretTracking)
				{
					Verb_SmokePop.Pop(this.TryGetComp<CompReloadable>());
				}
			}
		}
		public override float GetSpecialApparelScoreOffset()
		{
			return this.GetStatValue(StatDefOf.SmokepopBeltRadius) * ApparelScorePerBeltRadius;
		}
	}
}
