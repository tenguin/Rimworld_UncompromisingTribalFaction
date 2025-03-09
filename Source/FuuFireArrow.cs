using RimWorld;
using Verse;

namespace UncompromisingTribalFaction
{
    public class FuuFireArrow : Projectile
	{
		private static FloatRange FireSizeRange = new FloatRange(0.5f, 0.8f);

		protected override void Impact(Thing hitThing, bool blockedByShield = false)
		{
			if (!base.Position.GetTerrain(base.Map).IsWater)
			{
				FilthMaker.TryMakeFilth(base.Position, base.Map, FilthDefOf.UncompromisingTribalFaction_Filth_FireArrow, 1, FilthSourceFlags.None, false);
                FireUtility.TryStartFireIn(base.Position, base.Map, FireSizeRange.RandomInRange, launcher);
			}
			FleckCreationData dataStatic = FleckMaker.GetDataStatic(DrawPos, base.Map, FleckDefOf.MicroSparksFast);
			dataStatic.velocitySpeed = 0.8f;
			dataStatic.velocityAngle = ExactRotation.eulerAngles.y;
			base.Map.flecks.CreateFleck(dataStatic);
			base.Impact(hitThing, blockedByShield);
		}
	}
}
