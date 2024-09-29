using AmongUs.GameOptions;
using static TOHE.Options;

namespace TOHE.Roles.Neutral;

internal class MemoryThief : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 31800;
    public override CustomRoles ThisRoleBase => CustomRoles.Neutral;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.NeutralChaos;
    //==================================================================\\
}
