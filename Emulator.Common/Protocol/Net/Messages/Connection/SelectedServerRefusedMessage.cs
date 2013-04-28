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

namespace Emulator.Common.Protocol.Net.Messages.Connection
{
    public class SelectedServerRefusedMessage : NetworkMessage
    {
        public const uint ID = 41;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short ServerId { get; set; }
        public sbyte Error { get; set; }
        public sbyte ServerStatus { get; set; }


        public SelectedServerRefusedMessage()
        {
        }

        public SelectedServerRefusedMessage(short serverId, sbyte error, sbyte serverStatus)
        {
            ServerId = serverId;
            Error = error;
            ServerStatus = serverStatus;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ServerId);
            writer.WriteSByte(Error);
            writer.WriteSByte(ServerStatus);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ServerId = reader.ReadShort();
            Error = reader.ReadSByte();
            ServerStatus = reader.ReadSByte();
        }
    }
}