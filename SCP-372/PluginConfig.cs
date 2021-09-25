using System;
using System.Collections.Generic;
using System.ComponentModel;
using Synapse.Config;
using Synapse.Config;

namespace SCP_372
{
    public class PluginConfig : AbstractConfigSection
    {
        public ushort Spawn_message_duration { get; set; } = 10;
        public int SpawnChance { get; set; } = 50;
        public int Max_SCP372_Count { get; set; } = 1;

        [Description("how much health should SCP-372 have")]
        public int Health { get; set; } = 150;
    }
}