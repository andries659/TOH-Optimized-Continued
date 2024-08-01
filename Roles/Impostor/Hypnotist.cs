using AmongUs.GameOptions;
using TOHE.Roles.Core;
using TOHE.Roles.Impostor;
using static TOHE.Translator;
using static TOHE.Options;

namespace TOHE.Roles.Impostor;

internal class Hypnotist : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 29700;
    public static bool HasEnabled => CustomRoleManager.HasEnabled(CustomRoles.Hypnotist);

    public override CustomRoles ThisRoleBase => CustomRoles.Shapeshifter;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorKilling;
    //==================================================================\\

    private static OptionItem HypnotizeCooldown;
    private static OptionItem HypnosisDuration;
    private static OptionItem AmountOfHypnotizes;
    private static OptionItem ShowShapeshiftAnimationsOpt;

    private static readonly HashSet<byte> playerIdList = [];

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Hypnotist);
        HypnotizeCooldown = FloatOptionItem.Create(Id + 2, "HypnotistHypnotizeCooldown", new(2.5f, 180f, 2.5f), 15f, TabGroup.ImpostorRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist])
           .SetValueFormat(OptionFormat.Seconds);
        HypnosisDuration = FloatOptionItem.Create(Id + 3, "HypnotistHypnosisDuration", new(2.5f, 180f, 1.5f), 10f, TabGroup.ImpostorRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist])
           .SetValueFormat(OptionFormat.Seconds);
        AmountOfHypnotizes = IntegerOptionItem.Create(Id + 4, "HypnotistMaxCount", new(1, 7, 1), 3, TabGroup.ImpostorRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist])
            .SetValueFormat(OptionFormat.Times);
        ShowShapeshiftAnimationsOpt = BooleanOptionItem.Create(Id + 5, GeneralOption.ShowShapeshiftAnimations, true, TabGroup.ImpostorRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist]);
    }
    public override void Init()
    {
        playerIdList.Clear();
    }
    public override void Add(byte playerId)
    {
        playerIdList.Add(playerId);
    }
    public override bool IsEnable => playerIdList.Any();

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.ShapeshifterCooldown = HypnotizeCooldown.GetFloat();
        AURoleOptions.ShapeshifterDuration = 1f;
    }
}
