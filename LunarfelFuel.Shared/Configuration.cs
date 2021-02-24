using NFive.SDK.Core.Controllers;

namespace Lunarfel.LunarfelFuel.Shared
{
	public class Configuration : ControllerConfiguration
	{
		// Are blips enabled?
		public bool CreateBlips { get; set; } = true;

		// Jerrycans / pickup fuel / enabled?
		public bool CreatePickups { get; set; } = false;

		// Name of the blip
		public string BlipName { get; set; } = "Gas Station";

		// Name of the blip
		public int BlipID { get; set; } = 361;

		// Color ID of the blip (default: 0 /White/)
		public int BlipColor { get; set; } = 0;

		// Size of the blip
		public float BlipSize { get; set; } = 0.75f;

		// Is the blip short-ranged? (e.g appears only when nearby)
		public bool BlipSR { get; set; } = true;
	}
}
