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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Basic
{
    public class BasicWhoIsMessage : NetworkMessage
    {
        public const uint ID = 180;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Self { get; set; }
        public sbyte Position { get; set; }
        public string AccountNickname { get; set; }
        public int AccountId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerId { get; set; }
        public short AreaId { get; set; }


        public BasicWhoIsMessage()
        {
        }

        public BasicWhoIsMessage(bool self, sbyte position, string accountNickname, int accountId, string playerName, int playerId, short areaId)
        {
            Self = self;
            Position = position;
            AccountNickname = accountNickname;
            AccountId = accountId;
            PlayerName = playerName;
            PlayerId = playerId;
            AreaId = areaId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(Self);
            writer.WriteSByte(Position);
            writer.WriteUTF(AccountNickname);
            writer.WriteInt(AccountId);
            writer.WriteUTF(PlayerName);
            writer.WriteInt(PlayerId);
            writer.WriteShort(AreaId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Self = reader.ReadBoolean();
            Position = reader.ReadSByte();
            AccountNickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadInt();
            AreaId = reader.ReadShort();
        }
    }
}