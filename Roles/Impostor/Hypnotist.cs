//using AmongUs.GameOptions;
//using TOHE.Roles.Core;
//using TOHE.Roles.Impostor;
//using static TOHE.Translator;
//using static TOHE.Options;

//namespace TOHE.Roles.Impostor;

//internal class Hypnotist : RoleBase
{
    //===========================SETUP================================\\
    //private const int Id = 29700;
    //public static bool HasEnabled => CustomRoleManager.HasEnabled(CustomRoles.Hypnotist);
    //public override CustomRoles ThisRolesBase => CustomRoles.Shapeshifter;
    //public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorKilling;
    //==================================================================\\

    //public static OptionItem HypnotizeCooldown;
    //public static OptionItem HypnosisDuration;
    //private static OptionItem AmountOfHypnitizes;

    //public override void SetupCustomOption()
    //{
        //Options.SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Hypnotist);
        //HypnotizeCooldown = FloatOptionItem.Create(Id + 2, "HypnotizeCooldown", new(10f, 30f, 0,5f), 15f, TabGroup.ImpostorRoles, false)
           //.SetParent(Options.CustomRolesSpawnChance[CustomRoles.Hypnotist])
           //.SetValueFormat(OptionFormat.Multiplier);
    //    HypnosisDuration = FloatOptionItem.Create(Id + 3, "HypnosisDuration", new(5f, 25f, 0,5f), 10f, TabGroup.ImpostorRoles, false)
    //       .SetValueFormat(OptionFormat.Seconds);
    //    AmountOfHypnitizes = IntegerOptionItem.Create(Id + 10, "HypnotistMaxCount", new(1, 7, 1), 3, TabGroup.ImpostorRoles, false)
    //        .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist])
    //        .SetValueFormat(OptionFormat.Times);
     //   ShowShapeshiftAnimationsOpt = BooleanOptionItem.Create(Id + 4, GeneralOption.ShowShapeshiftAnimations, true, TabGroup.ImpostorRoles, false)
     //       .SetParent(Options.CustomRoleSpawnChances[CustomRoles.Hypnotist]);
  //  }
    //public override void Init()
//    {
    //    ForHypnotist.Clear();
  //  }
  //  }
   // public override void Init()
  //  {
   //     playerIdList.clear();
   // }
   // public override void Add(byte playerId)
 //   {
  //      playerIdList.Add(playerId);
  //  }
  //  public override bool IsEnable => playerIdList.Any();

  //  public override void ApplyGameOptions(IgameOptions opt, byte playerId)
  //  {
  //      AURoleOptions.ShapeshifterCooldown = HypnotizeCooldown.GetFloat();
   //     AURoleOptions.ShapeshifterDuration = 1f;
   // }
