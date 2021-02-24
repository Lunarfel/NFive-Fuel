using JetBrains.Annotations;
using NFive.SDK.Server.Migrations;
using Lunarfel.LunarfelFuel.Server.Storage;

namespace Lunarfel.LunarfelFuel.Server.Migrations
{
	[UsedImplicitly]
	public sealed class Configuration : MigrationConfiguration<StorageContext> { }
}
