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
using Emulator.Common.Protocol.Net.Types.Game.Character.Status;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Status
{
    public class PlayerStatusUpdateMessage : NetworkMessage
    {
        public const uint ID = 6386;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int AccountId { get; set; }
        public int PlayerId { get; set; }
        public PlayerStatus Status { get; set; }


        public PlayerStatusUpdateMessage()
        {
        }

        public PlayerStatusUpdateMessage(int accountId, int playerId, PlayerStatus status)
        {
            AccountId = accountId;
            PlayerId = playerId;
            Status = status;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteInt(PlayerId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadInt();
            Status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
        }
    }
}