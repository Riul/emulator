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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Friend
{
    public class FriendSpouseInformations
    {
        public const short ID = 77;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int SpouseAccountId { get; set; }
        public int SpouseId { get; set; }
        public string SpouseName { get; set; }
        public byte SpouseLevel { get; set; }
        public sbyte Breed { get; set; }
        public sbyte Sex { get; set; }
        public EntityLook SpouseEntityLook { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }
        public sbyte AlignmentSide { get; set; }


        public FriendSpouseInformations()
        {
        }

        public FriendSpouseInformations(int spouseAccountId, int spouseId, string spouseName, byte spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, BasicGuildInformations guildInfo, sbyte alignmentSide)
        {
            SpouseAccountId = spouseAccountId;
            SpouseId = spouseId;
            SpouseName = spouseName;
            SpouseLevel = spouseLevel;
            Breed = breed;
            Sex = sex;
            SpouseEntityLook = spouseEntityLook;
            GuildInfo = guildInfo;
            AlignmentSide = alignmentSide;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(SpouseAccountId);
            writer.WriteInt(SpouseId);
            writer.WriteUTF(SpouseName);
            writer.WriteByte(SpouseLevel);
            writer.WriteSByte(Breed);
            writer.WriteSByte(Sex);
            SpouseEntityLook.Serialize(writer);
            GuildInfo.Serialize(writer);
            writer.WriteSByte(AlignmentSide);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            SpouseAccountId = reader.ReadInt();
            SpouseId = reader.ReadInt();
            SpouseName = reader.ReadUTF();
            SpouseLevel = reader.ReadByte();
            Breed = reader.ReadSByte();
            Sex = reader.ReadSByte();
            SpouseEntityLook = new EntityLook();
            SpouseEntityLook.Deserialize(reader);
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
            AlignmentSide = reader.ReadSByte();
        }
    }
}