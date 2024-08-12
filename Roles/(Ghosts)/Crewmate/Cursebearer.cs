using AmongUs.GameOptions;
using System;
using TOHE.Roles.Core;
using TOHE.Roles.Double;
using UnityEngine;
using static TOHE.Options;
using static TOHE.Translator;
using static TOHE.Utils;

namespace TOHE.Roles._Ghosts_.Crewmate;

internal class Cursebearer : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 31200;
    public static bool HasEnabled => CustomRoleManager.HasEnabled(CustomRoles.Cursebearer);
    public override CustomRoles ThisRoleBase => CustomRoles.GuardianAngel;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.CrewmateGhosts;
    //==================================================================\\

    public static OptionItem RevealCooldown;
    
    public static readonly Dictionary<byte, byte> BetPlayer = [];
    public int KeepCount = 0;
    public override void SetupCustomOption()
    {
        SetupSingleRoleOptions(Id, TabGroup.CrewmateRoles, CustomRoles.Cursebearer);
        RevealCooldown = FloatOptionItem.Create(Id + 10, GeneralOption.KillCooldown, new(0f, 120f, 2.5f), 25f, TabGroup.CrewmateRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Cursebearer])
    }

    public override void Add(byte playerId)
    {
        AbilityLimit = 1;

        foreach (var pc in Main.AllPlayerControls)
        {
            if (pc.IsAnySubRole(x => x.IsConverted()))
            {
                KeepCount++;
            }
        }
    }
    
    public override void OnReportDeadBody(PlayerControl reporter, NetworkedPlayerInfo target)
    {
        int ThisCount = 0;
        foreach (var pc in Main.AllPlayerControls)
        {
            if (pc.IsAnySubRole(x => x.IsConverted()))
            {
                ThisCount++;
            }
        }
        if (ThisCount > KeepCount && IncreaseByOneIfConvert.GetBool())
        {
            KeepCount++;
            AbilityLimit += ThisCount - KeepCount;
        }

    }
    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.GuardianAngelCooldown = KillCooldown.GetFloat();
        AURoleOptions.ProtectionDurationSeconds = 0f;
    }
    public override bool OnCheckProtect(PlayerControl killer, PlayerControl target)
    {
        if (AbilityLimit <= 0) return false;
        else;
        {
            AbilityLimit--;
            BetPlayer.Add(target.PlayerId);
            return false;
        }
    }


public override bool KnowRoleTarget(PlayerControl player, PlayerControl target)
    {
        if (!KnowTargetRole.GetBool()) return false;
        return BetPlayer.TryGetValue(player.PlayerId, out var tar) && tar == target.PlayerId;
    }
}
