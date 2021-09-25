using System.Collections.Generic;
using MapGeneration;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;
using MEC;
using System.Linq;
using Synapse;
using Synapse.Api.Enum;
using UnityEngine;

namespace SCP_372
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerThrowGrenadeEvent += OnThrowingGrenade;
            Server.Get.Events.Player.PlayerDropItemEvent += OnDroppingItem;
            Server.Get.Events.Map.DoorInteractEvent += OnInteractingDoor;
            Server.Get.Events.Player.PlayerPickUpItemEvent += OnPickingUpItem;
            Server.Get.Events.Player.PlayerShootEvent += OnShooting;
            Server.Get.Events.Round.SpawnPlayersEvent += OnSpawningPlayers;
        }

        public void OnSpawningPlayers(SpawnPlayersEventArgs ev)
        {
            if (Server.Get.Players.Count < 3)
            {
                var ply = ev.SpawnPlayers.FirstOrDefault(x => x.Key.Team == Team.SCP).Key;
                if (Server.Get.GetPlayers(x => x.RoleID != 372).Count < SCP372.Config.Max_SCP372_Count &&
                    ply.RoleID != 372)
                {
                    if (Random.Range(1, 100) <= SCP372.Config.SpawnChance)
                    {
                        ply.RoleID = 372;
                    }
                }
            }
            else
            {
                var ply = ev.SpawnPlayers.FirstOrDefault(x => x.Key.RoleType == RoleType.ClassD).Key;
                if (Server.Get.GetPlayers(x => x.RoleID != 372).Count < SCP372.Config.Max_SCP372_Count &&
                    ply.RoleID != 372)
                {
                    if (Random.Range(1, 100) <= SCP372.Config.SpawnChance)
                    {
                        ply.RoleID = 372;
                    }
                }
            }
        }

        public void OnShooting(PlayerShootEventArgs ev)
        {
            if (ev.Player.RoleID == 372)
            {
                ev.Player.Invisible = false;
                Timing.CallDelayed(0.5f, () => { ev.Player.Invisible = true; });
            }
        }

        public void OnThrowingGrenade(PlayerThrowGrenadeEventArgs ev)
        {
            if (ev.Player.RoleID == 372)
            {
                ev.Player.Invisible = false;
                Timing.CallDelayed(1f, () => { ev.Player.Invisible = true; });
            }
        }

        public void OnPickingUpItem(PlayerPickUpItemEventArgs ev)
        {
            if (ev.Player.RoleID == 372)
            {
                ev.Player.Invisible = false;
                Timing.CallDelayed(1f, () => { ev.Player.Invisible = true; });
            }
        }

        public void OnDroppingItem(PlayerDropItemEventArgs ev)
        {
            if (ev.Player.RoleID == 372)
            {
                ev.Player.Invisible = false;
                Timing.CallDelayed(1f, () => { ev.Player.Invisible = true; });
            }
        }

        public void OnInteractingDoor(DoorInteractEventArgs ev)
        {
            if (ev.Player.RoleID == 372)
            {
                ev.Player.Invisible = false;
                Timing.CallDelayed(1f, () => { ev.Player.Invisible = true; });
            }
        }
    }
}