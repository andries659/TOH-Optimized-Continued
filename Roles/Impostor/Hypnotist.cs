using AmongUs.GameOptions
using Hazel 

namespace TOHE.Roles.Impostor;

internal class Hypnotist : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 30200;
    private static readonly HashSet<byte> playerIdList = [];
    public static bool HasEnabled => playerIdList.Any();
    
    public override CustomRoles ThisRoleBase => CustomRoles.Impostor;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.CrewmateBasic;
    //==================================================================\\
