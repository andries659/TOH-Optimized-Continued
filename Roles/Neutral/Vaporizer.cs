﻿using AmongUs.GameOptions;
using TOHE.Roles.Core;
using UnityEngine;
using static TOHE.Options;
namespace TOHE.Roles.Neutra;;

internal class Vaporizer : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 30600;
    public static bool HasEnabled => CustomRoleManager.HasEnabled(CustomRoles.Hangman);
    public override CustomRoles ThisRoleBase => CustomRoles.Shapeshifter;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorKilling;
    //==================================================================\\

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Vaporizer);
        VaporizerKillCooldown = FloatOptionItem.Create(Id + 2, GeneralOption.KillCooldown, new(1f, 60f, 1f), 20f, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Vaporizer])
            .SetValueFormat(OptionFormat.Seconds);
    }
    public override bool OnCheckMurderAsKiller(PlayerControl killer, PlayerControl target)
    {
        killer.RpcGuardAndKill(target)
        target.RpcExileV2();
        Main.PlayerStates[target.PlayerId].SetDead();
        target.Data.IsDead = true;
        target.SetRealKiller(killer);

        killer.SetKillCooldown();
        return false;
    }
}