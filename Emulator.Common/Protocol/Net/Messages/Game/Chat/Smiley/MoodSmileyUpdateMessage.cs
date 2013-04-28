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

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat.Smiley
{
    public class MoodSmileyUpdateMessage : NetworkMessage
    {
        public const uint ID = 6388;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int AccountId { get; set; }
        public int PlayerId { get; set; }
        public sbyte SmileyId { get; set; }


        public MoodSmileyUpdateMessage()
        {
        }

        public MoodSmileyUpdateMessage(int accountId, int playerId, sbyte smileyId)
        {
            AccountId = accountId;
            PlayerId = playerId;
            SmileyId = smileyId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteInt(PlayerId);
            writer.WriteSByte(SmileyId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadInt();
            SmileyId = reader.ReadSByte();
        }
    }
}