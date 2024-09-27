
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
    }
}
