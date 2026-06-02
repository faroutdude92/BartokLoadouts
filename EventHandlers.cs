using LabApi.Events.Handlers;
using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;
using InventorySystem.Items.Keycards;
using LabApi.Features.Wrappers;

namespace BartokLoadouts
{
    public static class EventHandlers
    {
        public static void Register()
        {
            PlayerEvents.ChangedRole += OnChangedRole;
        }

        public static void Unregister()
        {
            PlayerEvents.ChangedRole -= OnChangedRole;
        }

        private static void OnChangedRole(PlayerChangedRoleEventArgs ev)
        {
            ev.ChangeReason.ToString();
            // Guard Chief
            if (ev.NewRole.RoleTypeId == RoleTypeId.FacilityGuard)
            {
                ev.ChangeReason.ToString();

                if (RandomLoadouts.Random.Next(100) < BartokLoadoutsPlugin.Config.GuardChieftainChance)
                {
                    ev.Player.AddItem(ItemType.KeycardMTFPrivate); 
                    ev.Player.SendHint(
                        "You spawned as a Security Cheiftain!",
                        8
                    );

                  
                }
            }

            // Senior Researcher
            if (ev.NewRole.RoleTypeId == RoleTypeId.Scientist)
            {
                if (RandomLoadouts.Random.Next(100) < BartokLoadoutsPlugin.Config.SeniorResearcherChance)
                {
                    ev.Player.AddItem(ItemType.KeycardResearchCoordinator);
                    ev.Player.AddItem(ItemType.Adrenaline);
                    ev.Player.SendHint(
                        "You spawned as a Senior Researcher!",
                        8
                    );

                    
                }
            }

            // Escaped Convict
            if (ev.NewRole.RoleTypeId == RoleTypeId.ClassD)
            {
                if (RandomLoadouts.Random.Next(100) < BartokLoadoutsPlugin.Config.ClassEChance)
                {
                    ev.Player.AddItem(ItemType.Coin);
                    ev.Player.AddItem(ItemType.Flashlight);
                    ev.Player.SendHint(
                        "You spawned as a Class-E!",
                        8
                    );

                    
                }
            }
        }
    }
}