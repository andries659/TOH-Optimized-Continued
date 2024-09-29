using AmongUs.GameOptions;
using TOHE.Roles.Core;
using static TOHE.Options;

namespace TOHE.Roles.Neutral;

internal class MemoryThief : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 31800;
    public override CustomRoles ThisRoleBase => CustomRoles.Crewmate;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.NeutralChaos;
    //==================================================================\\

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.MemoryThief);
    }
}
