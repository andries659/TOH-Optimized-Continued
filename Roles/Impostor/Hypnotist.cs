using AmongUs.GameOptions;
using Hazel;

namespace TOHE.Roles.Impostor;

internal class Hypnotist : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 30200;
    public static bool HasEnabled => CustomRoleManager.HasEnabled(CustomRoles.Hypnotist);
    public override CustomRoles ThisRoleBase => CustomRoles.Impostor;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorSupport;
    //==================================================================\\

    public static OptionItem AbilityCooldown;
    public static OptionItem AbilityDuration;
    public static OptionItem AbilityUseLimit;

    public override void SetupCustomOption()
        {
        SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Hypnotist);
        AbilityCooldown = FloatOptionItem.Create(Id + 2, GeneralOption.ShapeshifterBase_ShapeshiftCooldown, new(1f, 180f, 1f), 25f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Hypnotist])
            .SetValueFormat(OptionFormat.Seconds);
        AbilityDuration = FloatOptionItem.Create(Id + 4, GeneralOption.ShapeshifterBase_ShapeshiftDuration, new(1f, 180f, 1f), 25f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Hypnotist])
            .SetValueFormat(OptionFormat.Seconds);
        AbilityUseLimit = FloatOptionItem.Create(Id + 4, GeneralOption.ShapeshifterBase_ShapeshiftDuration, new(1f, 60f, 1f), 10f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Hypnotist])
            .SetValueFormat(OptionFormat.Seconds);
    }
}
