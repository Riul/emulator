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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Messages.Game.Social
{
    public class ContactLookMessage : NetworkMessage
    {
        public const uint ID = 5934;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int RequestId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerId { get; set; }
        public EntityLook Look { get; set; }


        public ContactLookMessage()
        {
        }

        public ContactLookMessage(int requestId, string playerName, int playerId, EntityLook look)
        {
            RequestId = requestId;
            PlayerName = playerName;
            PlayerId = playerId;
            Look = look;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteUTF(PlayerName);
            writer.WriteInt(PlayerId);
            Look.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            RequestId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadInt();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}