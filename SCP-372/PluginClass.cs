using System;
using System.Linq;
using System.Reflection;
using Synapse;
using Synapse.Api.Plugin;
using Synapse.Translation;

namespace SCP_372
{
    [PluginInformation(
        Author = "Naku",
        Description = "",
        LoadPriority = 1,
        Name = "SCP-372",
        SynapseMajor = 2,
        SynapseMinor = 5,
        SynapsePatch = 3,
        Version = "v.1.0.0"
    )]
    public class SCP372 : AbstractPlugin
    {
        [Config(section = "Scp372")] 
        public static PluginConfig Config;

        [SynapseTranslation] 
        public static SynapseTranslation<PluginTranslation> PluginTranslation;

        public override void Load()
        {
            Server.Get.RoleManager.RegisterCustomRole<Scp372PlayerScript>();
            PluginTranslation.AddTranslation(new PluginTranslation());
            new EventHandlers();
        }
    }
}