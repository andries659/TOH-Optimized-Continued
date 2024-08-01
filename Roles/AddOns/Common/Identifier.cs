namespace TOHE.Roles.AddOns.Common;

public static class Identifier
{
    private const int Id = 30100;

    public static OptionItem ImpCanBeIdentifier;
    public static OptionItem CrewCanBeIdentifier;
    public static OptionItem NeutralCanBeIdentifier;
    
    public static Dictionary<byte, string> IdentifierNotify = [];

    public static void SetupCustomOptions()
    {
        Options.SetupAdtRoleOptions(Id, CustomRoles.Identifier, canSetNum: true);
        ImpCanBeIdentifier = BooleanOptionItem.Create(Id + 10, "ImpCanBeIdentifier", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Identifier]);
        CrewCanBeIdentifier = BooleanOptionItem.Create(Id + 11, "CrewCanBeIdentifier", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Identifier]);
        NeutralCanBeIdentifier = BooleanOptionItem.Create(Id + 12, "NeutralCanBeIdentifier", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Identifier]);
    }

    public static void Init()
    {
        IdentifierNotify = [];
    }
    public static void Clear()
    {
        IdentifierNotify.Clear();
    }

    public static void OnReportDeadBody(PlayerControl reporter, NetworkedPlayerInfo deadBody)
    {

    }
}
