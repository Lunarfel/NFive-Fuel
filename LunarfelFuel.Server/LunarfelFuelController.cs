using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Communications;
using NFive.SDK.Server.Controllers;
using Lunarfel.LunarfelFuel.Shared;

namespace Lunarfel.LunarfelFuel.Server
{
	[PublicAPI]
	public class LunarfelFuelController : ConfigurableController<Configuration>
	{
		public LunarfelFuelController(ILogger logger, Configuration configuration, ICommunicationManager comms) : base(logger, configuration)
		{
			// Send configuration when requested
			comms.Event(LunarfelFuelEvents.Configuration).FromClients().OnRequest(e => e.Reply(this.Configuration));
		}
	}
}
