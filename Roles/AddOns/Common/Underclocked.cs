using static TOHE.Options;

namespace TOHE.Roles.AddOns.Common;

public static class Underclocked
{
    private const int Id = 30000;

    public static OptionItem UnderclockedIncrease;

    public static void SetupCustomOptions()
    {
        UnderclockedIncrease = FloatOptionItem.Create(Id + 10, "UnderclockedIncrease", new(5f, 180f, 2.5f), 15f, TabGroup.Addons, false).SetParent(CustomRoleSpawnChances[CustomRoles.Underclocked])
            .SetValueFormat(OptionFormat.Seconds);
    }
}
