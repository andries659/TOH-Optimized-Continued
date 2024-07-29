using AmongUs.GameOptions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static TOHE.Options;
using static TOHE.Translator;
using static TOHE.Utils;

namespace TOHE.Roles.Neutral;
{
    internal class Artist : RoleBase
    {
         private static readonly NetworkedPlayerInfo.PlayerOutfit PaintedOutfit = new NetworkedPlayerInfo.PlayerOutfit()
             .Set("", 15, "", "", "visor_Crack", "", "");

         private const int Id = 28800;
         private static readonly HashSet<byte> PlayerIds = new HashSet<byte>();
         
         private static OptionItem KillCooldown;
         private static OptionItem CanVent;
         private static OptionItem HasImpostorVision;
         private static OptionItem AbilityUses;

         private static readonly Dictionary<byte, float> NowCooldown = new Dictionary<byte, float>();
         private static readonly Dictionary<byte, List<byte>> PlayerSkinsPainted = new Dictionary<byte, List<byte>>();
        

         public override CustomRoles ThisRoleBase => CustomRoles.Impostor;
         public override Custom_RoleType ThisRoleType => Custom_RoleType.NeutralKilling;

         public static bool HasEnabled => PlayerIds.Any();

         public override void SetupCustomOption()
         {
             SetupRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Artist);
             KillCooldown = FloatOptionItem.Create(Id + 10, GeneralOption.KillCooldown, new(0f, 180f, 2.5f), 30f, TabGroup.NeutralRoles, false)
                 .SetParent(CustomRoleSpawnChances[CustomRoles.Artist])
                 .SetValueFormat(OptionFormat.Seconds);
             CanVent = BooleanOptionItem.Create(Id + 13, GeneralOption.CanVent, true, TabGroup.NeutralRoles, false)
                 .SetParent(CustomRoleSpawnChances[CustomRoles.Artist]);
             HasImpostorVision = BooleanOptionItem.Create(Id + 14, GeneralOption.ImpostorVision, true, TabGroup.NeutralRoles, false)
                 .SetParent(CustomRoleSpawnChances[CustomRoles.Artist]);
             AbilityUses = IntegerOptionItem.Create(Id + 11, "AbilityUses", new(1, 15, 1), 5, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Artist])
                .SetValueFormat(OptionFormat.Times);

                 public override void Init()
    {
        PlayerPainted.Clear();
        OriginalPlayerSkins.Clear();
        PlayerIds.Clear();
    }
    public override void Add(byte playerId)
    {
        PlayerPainted.TryAdd(playerId, []);
        PlayerIds.Add(playerId);
    }

        private void SetSkin(PlayerControl target, NetworkedPlayerInfo.PlayerOutfit outfit)
        {
            var sender = CustomRpcSender.Create(name: $"Artist.RpcSetSkin({target.Data.PlayerName})");

            public override void Add(byte playerId)
    {
        AbiltyUses = PaintingMaxCount.GetInt();
        PaintingTarget.TryAdd(playerId, []);

        var pc = Utils.GetPlayerById(playerId);
        pc?.AddDoubleTrigger();

        if (!Main.ResetCamPlayerList.Contains(playerId))
            Main.ResetCamPlayerList.Add(playerId);
    }

       private void SendRPC(byte playerId, byte targetId)
    {
    
        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncRoleSkill, SendOption.Reliable, -1);
        writer.WriteNetObject(_Player);
        writer.Write(playerId);
        writer.Write(AbilityLimit);
        writer.Write(targetId);
        AmongUsClient.Instance.FinishRpcImmediately(writer);
    }
    public override void ReceiveRPC(MessageReader reader, PlayerControl NaN)
    {
        byte playerId = reader.ReadByte();

        AbilityLimit = reader.ReadSingle();
          PaintingTarget[playerId].Add(reader.ReadByte());
        
    }
    public override void ApplyGameOptions(IGameOptions opt, byte id) => opt.SetVision(HasImpostorVision.GetBool());
    public override void SetKillCooldown(byte id) => Main.AllPlayerKillCooldown[id] = KillCooldown.GetFloat();
    public override bool CanUseKillButton(PlayerControl pc) => true;
    public override bool CanUseImpostorVentButton(PlayerControl pc) => CanVent.GetBool();
    public override bool CanUseSabotage(PlayerControl pc) => false;

     public override bool OnCheckMurderAsKiller(PlayerControl killer, PlayerControl target)
    {
        if (AbilityLimit > 0)
        {
            return killer.CheckDoubleTrigger(target, () => { SetPainting(killer, target); });
        }
        else return true;
    }

    public static bool IsPainting(byte seer, byte target)
    {
        if (PaintingTarget[seer].Contains(target))
        {
            return true;
        }
        return false;
    }
    private void SetPainting(PlayerControl killer, PlayerControl target)
    {
        if (!PlayerPainted[killer.PlayerId].Contains(target.PlayerId))
        {
            if (!Camouflage.IsCamouflage)
            {
                SetSkin(target, PaintedOutfit);
            }

            PlayerPainted[killer.PlayerId].Add(target.PlayerId);
            killer.Notify(Utils.ColorString(Utils.GetRoleColor(CustomRoles.Artist), GetString("ArtistPaintedSkin")));
            target.Notify(Utils.ColorString(Utils.GetRoleColor(CustomRoles.Artist), GetString("PaintedByArtist")));

            OriginalPlayerSkins.Add(target.PlayerId, Camouflage.PlayerSkins[target.PlayerId]);
            Camouflage.PlayerSkins[target.PlayerId] = PaintedOutfit;
        }
    }

    private static void SetSkin(PlayerControl target, NetworkedPlayerInfo.PlayerOutfit outfit)
    {
        var sender = CustomRpcSender.Create(name: $"Artist.RpcSetSkin({target.Data.PlayerName})");
        
            target.SetColor(outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetColor)
                .Write(target.Data.NetId)
                .Write((byte)outfit.ColorId)
                .EndRpc();

            target.SetHat(outfit.HatId, outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetHatStr)
                .Write(outfit.HatId)
                .Write(target.GetNextRpcSequenceId(RpcCalls.SetHatStr))
                .EndRpc();

            target.SetSkin(outfit.SkinId, outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetSkinStr)
               .Write(outfit.SkinId)
               .Write(target.GetNextRpcSequenceId(RpcCalls.SetSkinStr))
               .EndRpc();

            target.SetVisor(outfit.VisorId, outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetVisorStr)
                .Write(outfit.VisorId)
                .Write(target.GetNextRpcSequenceId(RpcCalls.SetVisorStr))
                .EndRpc();

            target.SetPet(outfit.PetId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetPetStr)
                .Write(outfit.PetId)
                .Write(target.GetNextRpcSequenceId(RpcCalls.SetPetStr))
                .EndRpc();

          sender.SendMessage();
        }
    }
        }
    }
}
