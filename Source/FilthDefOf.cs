using RimWorld;
using Verse;

namespace UncompromisingTribalFaction
{
	[DefOf]
	public static class FilthDefOf
	{
		public static ThingDef UncompromisingTribalFaction_Filth_FireArrow;

		static FilthDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(FilthDefOf));
		}
	}
}
