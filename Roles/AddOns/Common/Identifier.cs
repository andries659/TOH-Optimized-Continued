using static TOHE.Options;
using static TOHE.Translator;
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
        if (reporter.Is(CustomRoles.Identifier) && !deadBody.Object.IsAlive() && reporter.PlayerId != deadBody.PlayerId)
        {
            var realKiller = deadBody.Object.GetRealKiller();
            var killerOutfit = Camouflage.PlayerSkins[realKiller.PlayerId];

            if (killerOutfit.ColorId == 0)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
            
            if (killerOutfit.ColorId == 1)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
            
            if (killerOutfit.ColorId == 2)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }

            if (killerOutfit.ColorId == 3)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }
            
            if (killerOutfit.ColorId == 4)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
            
            if (killerOutfit.ColorId == 5)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }

            if (killerOutfit.ColorId == 6)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
            
            if (killerOutfit.ColorId == 7)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }
            
            if (killerOutfit.ColorId == 8)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }

            if (killerOutfit.ColorId == 9)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
            
            if (killerOutfit.ColorId == 10)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }
            
            if (killerOutfit.ColorId == 11)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }

            if (killerOutfit.ColorId == 12)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
            
            if (killerOutfit.ColorId == 13)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }
            
            if (killerOutfit.ColorId == 14)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }

            if (killerOutfit.ColorId == 15)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }
            
            if (killerOutfit.ColorId == 16)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierLight"));
            }
            
            if (killerOutfit.ColorId == 17)
            {
                string msg;
                msg = string.Format(Translator.GetString("IdentifierDark"));
            }
        }

    }
}
