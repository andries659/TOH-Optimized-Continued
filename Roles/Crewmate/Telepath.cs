
using AmongUs.GameOptions;
using System;
using System.Text;
using UnityEngine;
using static TOHE.Options;
using static TOHE.Utils;

namespace TOHE.Roles.Crewmate
{
    internal class Telepath : RoleBase
    {
        //===========================SETUP================================\\
        private const int Id = 30200;
        private static readonly HashSet<byte> playerIdList = [];
        public static bool HasEnabled => playerIdList.Any();
        
        public override CustomRoles ThisRoleBase => CustomRoles.Telepath;
        public override Custom_RoleType ThisRoleType => Custom_RoleType.CrewmateHindering;
        //==================================================================\\

        private static OptionItem TelepathLinkCooldown;
        private static OptionItem TelepathStunDuration;

        private PlayerControl linkedPlayer;
        private float linkCooldownTime;
        private bool isStunned;

        public override void SetupCustomOption()
        {
            SetupSingleRoleOptions(Id, TabGroup.CrewmateRoles, CustomRoles.Telepath, 1);
            TelepathLinkCooldown = FloatOptionItem.Create(Id + 10, "LinkCooldown", new(5, 120, 5), 30, TabGroup.CrewmateRoles, false)
                .SetParent(CustomRoleSpawnChances[CustomRoles.Telepath])
                .SetValueFormat(OptionFormat.Seconds);
            TelepathStunDuration = FloatOptionItem.Create(Id + 11, "StunDuration", new(1, 10, 0.5f), 3, TabGroup.CrewmateRoles, false)
                .SetParent(CustomRoleSpawnChances[CustomRoles.Telepath])
                .SetValueFormat(OptionFormat.Seconds);
        }

        public override void Init()
        {
            playerIdList.Clear();
            linkedPlayer = null;
            isStunned = false;
        }

        public override void Add(byte playerId)
        {
            playerIdList.Add(playerId);
        }

        public override void ApplyGameOptions(IGameOptions opt, byte playerId)
        {
            AURoleOptions.TelepathLinkCooldown = TelepathLinkCooldown.GetFloat();
        }

        public override string GetProgressText(byte playerId, bool comms)
        {
            var ProgressText = new StringBuilder();
            var taskState = Main.PlayerStates?[playerId].TaskState;
            Color TextColor;
            var TaskCompleteColor = Color.green;
            var NonCompleteColor = Color.yellow;
            var NormalColor = taskState.IsTaskFinished ? TaskCompleteColor : NonCompleteColor;
            TextColor = comms ? Color.gray : NormalColor;
            string Completed = comms ? "?" : $"{taskState.CompletedTasksCount}";
            ProgressText.Append(ColorString(TextColor, $"({Completed}/{taskState.AllTasksCount})"));
            return ProgressText.ToString();
        }

        public override void OnUseAbility(PlayerControl pc)
        {
            if (linkedPlayer != null || isStunned)
            {
                pc.Notify(GetString("TelepathAbilityUnavailable"));
                return;
            }

            linkedPlayer = SelectLinkedPlayer(pc);

            if (linkedPlayer != null)
            {
                pc.Notify($"{linkedPlayer.PlayerName} is now linked to you.");
                MonitorLinkedPlayer(pc, linkedPlayer);
            }
        }

        private PlayerControl SelectLinkedPlayer(PlayerControl pc)
        {
            // Logic to select a random player (or allow user to pick) within vision range
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId != pc.PlayerId && player.IsAlive())
                {
                    return player; // Select the first available player (or customize selection logic)
                }
            }
            return null;
        }

        private void MonitorLinkedPlayer(PlayerControl telepath, PlayerControl target)
        {
            // Start monitoring the linked player's actions (this can be called frequently in the game loop)
            telepath.Notify($"You are viewing {target.PlayerName}'s actions.");

            // Check if the linked player dies
            if (!target.IsAlive())
            {
                StunTelepath(telepath);
            }
        }

        private void StunTelepath(PlayerControl telepath)
        {
            isStunned = true;
            telepath.Notify("Your linked player has died! You are stunned.");
            // Implement stun logic (disable movement/abilities for a duration)
            ApplyStun(telepath, TelepathStunDuration.GetFloat());

            // Unlink after stun
            linkedPlayer = null;
        }

        private void ApplyStun(PlayerControl telepath, float duration)
        {
            telepath.SetPlayerControl(false); // Disable player control
            _ = new LateTask(() =>
            {
                telepath.SetPlayerControl(true); // Re-enable after stun duration
                telepath.Notify("You have recovered from the stun.");
                isStunned = false;
            }, duration, "Telepath Stun");
        }

        public override void SetAbilityButtonText(HudManager hud, byte id)
        {
            hud.AbilityButton.buttonLabelText.text = GetString("TelepathLinkButtonText");
        }
    }
}
