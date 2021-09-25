using MEC;
using Synapse.Api;
using MapGeneration;
using UnityEngine;
using System.Collections.Generic;

namespace SCP_372
{
    public class Scp372PlayerScript : Synapse.Api.Roles.Role
    {
        public override int GetRoleID() => 682;

        public override string GetRoleName() => "SCP-372";

        public override int GetTeamID() => (int) Team.SCP;

        public List<CoroutineHandle> coroutines = new List<CoroutineHandle>();

        public override void Spawn()
        {
            Player.Invisible = true;
            Player.SendBroadcast(SCP372.Config.Spawn_message_duration, SCP372.PluginTranslation.ActiveTranslation.spawn_message);
            Player.RemoveDisplayInfo(PlayerInfoArea.Role);
            Player.RoleType = RoleType.Tutorial;
            Player.MaxHealth = SCP372.Config.Health;
            Player.Health = SCP372.Config.Health;
            Player.DisplayInfo = "<color=red>SCP-372</color>";
            Timing.CallDelayed(1f, () =>
            {
                var rm = Map.Get.GetRoom(RoomName.LczGlassroom);
                Player.Position = new Vector3(rm.Position.x, rm.Position.y + 1, rm.Position.z + 4);
            });
            coroutines.Add(Timing.RunCoroutine(VoiceChatCheck()));
        }

        public override void DeSpawn()
        {
            Map.Get.AnnounceScpDeath("3 7 2");
            Player.AddDisplayInfo(PlayerInfoArea.Role);
            Player.Invisible = false;
            Player.DisplayInfo = null;
            foreach (CoroutineHandle coroutine in coroutines)
            {
                Timing.KillCoroutines(coroutine);
            }

            coroutines.Clear();
        }

        public IEnumerator<float> VoiceChatCheck()
        {
            while (true)
            {
                if (Player.Invisible && Player || Player.Radio.UsingVoiceChat && Player.Radio.UsingRadio)
                {
                    Player.Invisible = false;
                }
                else if (!Player.Invisible && !Player.Radio.UsingVoiceChat && !Player.Radio.UsingRadio)
                {
                    Player.Invisible = true;
                }

                yield return Timing.WaitForSeconds(0.5f);
            }
        }
    }
}