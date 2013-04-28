#region License

//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character.Choice;
using Emulator.Common.Protocol.Net.Types.Game.Character.Status;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party
{
    public class PartyMemberInformations : CharacterBaseInformations
    {
        public const short ID = 90;

        public override short TypeId
        {
            get { return ID; }
        }

        public int LifePoints { get; set; }
        public int MaxLifePoints { get; set; }
        public short Prospecting { get; set; }
        public byte RegenRate { get; set; }
        public short Initiative { get; set; }
        public bool PvpEnabled { get; set; }
        public sbyte AlignmentSide { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }
        public PlayerStatus Status { get; set; }


        public PartyMemberInformations()
        {
        }

        public PartyMemberInformations(int id, byte level, string name, EntityLook entityLook, sbyte breed, bool sex, int lifePoints, int maxLifePoints, short prospecting, byte regenRate, short initiative, bool pvpEnabled, sbyte alignmentSide, short worldX, short worldY, int mapId, short subAreaId, PlayerStatus status)
                : base(id, level, name, entityLook, breed, sex)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
            Initiative = initiative;
            PvpEnabled = pvpEnabled;
            AlignmentSide = alignmentSide;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Status = status;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LifePoints);
            writer.WriteInt(MaxLifePoints);
            writer.WriteShort(Prospecting);
            writer.WriteByte(RegenRate);
            writer.WriteShort(Initiative);
            writer.WriteBoolean(PvpEnabled);
            writer.WriteSByte(AlignmentSide);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            LifePoints = reader.ReadInt();
            MaxLifePoints = reader.ReadInt();
            Prospecting = reader.ReadShort();
            RegenRate = reader.ReadByte();
            Initiative = reader.ReadShort();
            PvpEnabled = reader.ReadBoolean();
            AlignmentSide = reader.ReadSByte();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
            Status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
        }
    }
}