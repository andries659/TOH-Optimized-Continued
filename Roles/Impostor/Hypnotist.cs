using AmongUs.GameOptions;
using Hazel;

namespace TOHE.Roles.Impostor;

internal class Hypnotist : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 30200;
    public override CustomRoles ThisRoleBase => CustomRoles.Impostor;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorSupport;
    //==================================================================\\

    public static OptionItem AbilityCooldown;
    public static OptionItem AbilityDuration;

    public override void SetupCustomOption()
        {
        Options.SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Hypnotist);
        AbilityCooldown = FloatOptionItem.Create(Id + 2, "HypnotistHypnotizeCooldown", new(1f, 180f, 1f), 25f, TabGroup.ImpostorRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist])
            .SetValueFormat(OptionFormat.Seconds);
        AbilityDuration = FloatOptionItem.Create(Id + 4, "HypnotistHypnotizeDuration", new(1f, 180f, 1f), 25f, TabGroup.ImpostorRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist])
            .SetValueFormat(OptionFormat.Seconds);
    }
}
