using NFive.SDK.Core.Controllers;

namespace Lunarfel.LunarfelFuel.Shared
{
	public class Configuration : ControllerConfiguration
	{
		// Are blips enabled?
		public bool CreateBlips { get; set; } = true;
		// Jerrycans / pickup fuel / enabled?
		public bool CreatePickups { get; set; } = false;
	}
}
