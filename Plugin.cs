using System;
using LabApi.Loader.Features.Plugins;

namespace BartokLoadouts
{
    public class BartokLoadoutsPlugin : Plugin
    {
        public static Config Config;

        public override string Name => "BartokLoadouts";
        public override string Description => "special loadouts for Guards, D-Class, and Scientists!";
        public override string Author => "Magic Simmons";

        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredApiVersion => new Version(1, 0, 0);

        public override void Enable()
        {
            Config = Config.Load();

            EventHandlers.Register();
        }

        public override void Disable()
        {
            EventHandlers.Unregister();
        }
    }
}
