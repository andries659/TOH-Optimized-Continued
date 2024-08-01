using static TOHE.Options;

namespace TOHE.Roles.AddOns.Common;

public static class Underclocked
{
    private const int Id = 30000;

    public static OptionItem UnderclockedIncrease;

    public static void SetupCustomOptions()
    {
        UnderclockedKillCooldown = FloatOptionItem.Create(Id + 10, "UnderclockedKillCooldown", new(25f, 180f, 2.5f), 30f, TabGroup.Addons, false).SetParent(CustomRoleSpawnChances[CustomRoles.Underclocked])
            .SetValueFormat(OptionFormat.Seconds);
    }
}
