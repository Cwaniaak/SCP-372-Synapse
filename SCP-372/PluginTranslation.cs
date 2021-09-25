using Synapse.Translation;

namespace SCP_372
{
    public class PluginTranslation : IPluginTranslation
    {
        public string spawn_message { get; private set; } = "<b>You have spawned as <color=red>SCP-372</color></b>\n<i>you are invisible (unless you shoot or speak), cooperate with SCPs</i>";
    }
}