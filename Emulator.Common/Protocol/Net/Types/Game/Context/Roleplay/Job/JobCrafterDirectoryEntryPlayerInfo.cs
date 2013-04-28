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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryPlayerInfo
    {
        public const short ID = 194;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte AlignmentSide { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public bool IsInWorkshop { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }


        public JobCrafterDirectoryEntryPlayerInfo()
        {
        }

        public JobCrafterDirectoryEntryPlayerInfo(int playerId, string playerName, sbyte alignmentSide, sbyte breed, bool sex, bool isInWorkshop, short worldX, short worldY, int mapId, short subAreaId)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            AlignmentSide = alignmentSide;
            Breed = breed;
            Sex = sex;
            IsInWorkshop = isInWorkshop;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteBoolean(IsInWorkshop);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            PlayerId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            AlignmentSide = reader.ReadSByte();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            IsInWorkshop = reader.ReadBoolean();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
        }
    }
}