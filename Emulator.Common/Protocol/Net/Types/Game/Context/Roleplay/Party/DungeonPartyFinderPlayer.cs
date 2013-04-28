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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party
{
    public class DungeonPartyFinderPlayer
    {
        public const short ID = 373;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public short Level { get; set; }


        public DungeonPartyFinderPlayer()
        {
        }

        public DungeonPartyFinderPlayer(int playerId, string playerName, sbyte breed, bool sex, short level)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Breed = breed;
            Sex = sex;
            Level = level;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteShort(Level);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            PlayerId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Level = reader.ReadShort();
        }
    }
}