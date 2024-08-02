using AmongUs.GameOptions;
using TOHE.Roles.AddOns.Common;
using static TOHE.Options;
using static TOHE.Translator;
using static TOHE.Utils;

namespace TOHE.Roles.Impostor;

internal class Capitalist : RoleBase
{
    private const int Id = 5400;
    private static readonly HashSet<byte> PlayerIds = [];
    public static bool HasEnabled => PlayerIds.Any();
    
    public override CustomRoles ThisRoleBase => CustomRoles.Shapeshifter;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorHindering;
    //==================================================================\\

    private static OptionItem KillCooldown;
    private static OptionItem TaskAddCooldown;
    
    


   public static Dictionary<byte, int> CapitalistAddTask = [];
   public static Dictionary<byte, int> CapitalistAssignTask = [];
   public static bool On;
   public override bool IsEnable => On;

         public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Capitalist);
        KillCooldown = FloatOptionItem.Create(Id + 10, GeneralOption.KillCooldown, new(0f, 180f, 2.5f), 30f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Capitalist])
            .SetValueFormat(OptionFormat.Seconds);
        TaskAddCooldown = FloatOptionItem.Create(Id + 11, "TaskAddCooldown", new(0f, 180f, 2.5f), 30f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Capitalist])
            .SetValueFormat(OptionFormat.Seconds);
         CanVent = BooleanOptionItem.Create(Id + 12, GeneralOption.CanVent, true, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Capitalist]);


    public override void Init()
    {
        CapitalistAssignTask = [];
        PlayerIds.Clear();
    }

    public override void Add(byte playerId)
    {
        CapitalistAssignTask.TryAdd(playerId, []);
        PlayerIds.Add(playerId);
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.ShapeshifterCooldown = ShapeshiftCooldown.GetFloat();
        AURoleOptions.ShapeshifterDuration = 1f;
    }

    public override void SetKillCooldown(byte id) => Main.AllPlayerKillCooldown[id] = KillCooldown.GetFloat();

    public override bool OnCheckShapeshift(PlayerControl shapeshifter, PlayerControl target)
        {
                CapitalistAddTask.TryAdd(target.PlayerId, 0);
                CapitalistAddTask[target.PlayerId]++;
                CapitalistAssignTask.TryAdd(target.PlayerId, 0);
                CapitalistAssignTask[target.PlayerId]++;
                Logger.Info($"{killer.GetRealName()} added a task for：{target.GetRealName()}", "Capitalist Add Task");
                shapeshifter.SetShapeshifterCooldown(TaskAddCooldown.GetFloat());
            });
        }

     public static bool AddTaskForPlayer(PlayerControl player)
        {
            if (CapitalistAddTask.TryGetValue(player.PlayerId, out var amount))
            {
                var taskState = player.GetTaskState();
                taskState.AllTasksCount += amount;
                CapitalistAddTask.Remove(player.PlayerId);
                taskState.CompletedTasksCount++;
                player.Data.RpcSetTasks(new(0)); 
                player.SyncSettings();
                Utils.NotifyRoles(SpecifySeer: player, SpecifyTarget: player);
                return false;
            }

            return true;
        }
    }
}
