using AmongUs.GameOptions
using Hazel 

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
            StartSetup(647550)
                .AutoSetupOption(ref AbilityCooldown, 30, new IntegerValueRule(0, 60, 1), OptionFormat.Seconds)
                .AutoSetupOption(ref AbilityDuration, 15, new IntegerValueRule(0, 30, 1), OptionFormat.Seconds)
                .AutoSetupOption(ref AbilityUseLimit, 1, new IntegerValueRule(0, 5, 1), OptionFormat.Times);
        }
