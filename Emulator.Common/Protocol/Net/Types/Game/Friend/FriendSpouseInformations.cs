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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Friend
{
    public class FriendSpouseInformations
    {
        public const short Id = 77;
        public sbyte alignmentSide;

        public sbyte breed;
        public BasicGuildInformations guildInfo;
        public sbyte sex;
        public int spouseAccountId;
        public EntityLook spouseEntityLook;
        public int spouseId;
        public byte spouseLevel;
        public string spouseName;


        public FriendSpouseInformations()
        {
        }

        public FriendSpouseInformations(int spouseAccountId, int spouseId, string spouseName, byte spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, BasicGuildInformations guildInfo, sbyte alignmentSide)
        {
            this.spouseAccountId = spouseAccountId;
            this.spouseId = spouseId;
            this.spouseName = spouseName;
            this.spouseLevel = spouseLevel;
            this.breed = breed;
            this.sex = sex;
            this.spouseEntityLook = spouseEntityLook;
            this.guildInfo = guildInfo;
            this.alignmentSide = alignmentSide;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(spouseAccountId);
            writer.WriteInt(spouseId);
            writer.WriteUTF(spouseName);
            writer.WriteByte(spouseLevel);
            writer.WriteSByte(breed);
            writer.WriteSByte(sex);
            spouseEntityLook.Serialize(writer);
            guildInfo.Serialize(writer);
            writer.WriteSByte(alignmentSide);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            spouseAccountId = reader.ReadInt();
            if (spouseAccountId < 0)
                throw new Exception("Forbidden value on spouseAccountId = " + spouseAccountId + ", it doesn't respect the following condition : spouseAccountId < 0");
            spouseId = reader.ReadInt();
            if (spouseId < 0)
                throw new Exception("Forbidden value on spouseId = " + spouseId + ", it doesn't respect the following condition : spouseId < 0");
            spouseName = reader.ReadUTF();
            spouseLevel = reader.ReadByte();
            if (spouseLevel < 1 || spouseLevel > 200)
                throw new Exception("Forbidden value on spouseLevel = " + spouseLevel + ", it doesn't respect the following condition : spouseLevel < 1 || spouseLevel > 200");
            breed = reader.ReadSByte();
            sex = reader.ReadSByte();
            spouseEntityLook = new EntityLook();
            spouseEntityLook.Deserialize(reader);
            guildInfo = new BasicGuildInformations();
            guildInfo.Deserialize(reader);
            alignmentSide = reader.ReadSByte();
        }
    }
}