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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryPlayerInfo
    {
        public const short Id = 194;

        public sbyte alignmentSide;
        public sbyte breed;
        public bool isInWorkshop;
        public int mapId;
        public int playerId;
        public string playerName;
        public bool sex;
        public short subAreaId;
        public short worldX;
        public short worldY;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public JobCrafterDirectoryEntryPlayerInfo()
        {
        }

        public JobCrafterDirectoryEntryPlayerInfo(int playerId, string playerName, sbyte alignmentSide, sbyte breed, bool sex, bool isInWorkshop, short worldX, short worldY, int mapId, short subAreaId)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.alignmentSide = alignmentSide;
            this.breed = breed;
            this.sex = sex;
            this.isInWorkshop = isInWorkshop;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(playerId);
            writer.WriteUTF(playerName);
            writer.WriteSByte(alignmentSide);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteBoolean(isInWorkshop);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteShort(subAreaId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            playerName = reader.ReadUTF();
            alignmentSide = reader.ReadSByte();
            breed = reader.ReadSByte();
            if (breed < (byte) Enums.PlayableBreedEnum.Feca || breed > (byte) Enums.PlayableBreedEnum.Steamer)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Steamer");
            sex = reader.ReadBoolean();
            isInWorkshop = reader.ReadBoolean();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
        }
    }
}