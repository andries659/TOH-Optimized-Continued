using Hazel;
using System;
using System.Text;
using UnityEngine;
using TOHE.Roles.Core;
using static TOHE.Translator;
using static TOHE.Options;

namespace TOHE.Roles.Crewmate;

internal class Savior : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 31000;
    private static readonly HashSet<byte> playerIdList = [];
    public static bool HasEnabled => playerIdList.Any();
    
    public override CustomRoles ThisRoleBase => CustomRoles.Crewmate;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.CrewmateSupport;
    //==================================================================\\


    private static readonly HashSet<byte> saviorTarget = [];
    private static readonly Dictionary<byte, bool> DidVote = [];
    public static OptionItem ResetCooldown;

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.CrewmateRoles, CustomRoles.Savior);
        ResetCooldown = IntegerOptionItem.Create(Id + 2, "SaviorResetCooldown", new (0, 60, 2.5), 10, TabGroup.CrewmateRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Savior])
            .SetValueFormat(OptionFormat.Seconds);
    }
    public override void Init()
    {
        playerIdList.Clear();
        saviorTarget.Clear();
        DidVote.Clear();
    }

    public override void Add(byte playerId)
    {
        saviorTarget.Add(playerId);
        playerIdList.Add(playerId);
        DidVote.Add(playerId, false);
    }
    public override void Remove(byte playerId)
    {
        saviorTarget.Remove(playerId);
        playerIdList.Remove(playerId);
        DidVote.Remove(playerId);
    }

    public static bool OnVotes(PlayerControl voter, PlayerControl target)
    {
        if (!CustomRoles.Savior.HasEnabled()) return true;
        if (voter == null || target == null) return true;
        if (!voter.Is(CustomRoles.Savior)) return true;
        if (DidVote[voter.PlayerId]) return true;
        DidVote[voter.PlayerId] = true;
        if (saviorTarget.Contains(target.PlayerId)) return true;

        saviorTarget.Add(target.PlayerId);
        Logger.Info($"{voter.GetNameWithRole()} chosen as savior target by {target.GetNameWithRole()}", "Savior");
        Utils.SendMessage(string.Format(GetString("SaviorProtect"), target.GetRealName()), voter.PlayerId, title: Utils.ColorString(Utils.GetRoleColor(CustomRoles.Keeper), GetString("SaviorTitle")));
        return false;
    }
    public override bool CheckMurderOnOthersTarget(PlayerControl killer, PlayerControl target)
    {

        var Saviors = Utils.GetPlayerListByRole(CustomRoles.Savior);
        if (killer == null || target == null || Saviors == null || !Saviors.Any()) return true;
        if (saviorTarget.Contains(target.PlayerId)) return false;

        killer.RpcGuardAndKill(target);
        killer.SetKillCooldown(ResetCooldown.GetFloat());

        Utils.NotifyRoles(SpecifySeer: killer, SpecifyTarget: target, ForceLoop: true);
        Utils.NotifyRoles(SpecifySeer: target, SpecifyTarget: killer, ForceLoop: true);
        Logger.Info($"{target.GetNameWithRole()} : Shield Shatter from the Savior", "Savior");
        return true;
    }
    public override bool OnCheckStartMeeting(PlayerControl reporter)
    {
        saviorTarget.Clear();
        return true;
    }
}
