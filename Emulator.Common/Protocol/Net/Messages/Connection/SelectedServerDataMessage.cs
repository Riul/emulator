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
    public class SelectedServerDataMessage : NetworkMessage
    {
        public const uint ID = 42;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short ServerId { get; set; }
        public string Address { get; set; }
        public ushort Port { get; set; }
        public bool CanCreateNewCharacter { get; set; }
        public string Ticket { get; set; }


        public SelectedServerDataMessage()
        {
        }

        public SelectedServerDataMessage(short serverId, string address, ushort port, bool canCreateNewCharacter, string ticket)
        {
            ServerId = serverId;
            Address = address;
            Port = port;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ServerId);
            writer.WriteUTF(Address);
            writer.WriteUShort(Port);
            writer.WriteBoolean(CanCreateNewCharacter);
            writer.WriteUTF(Ticket);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ServerId = reader.ReadShort();
            Address = reader.ReadUTF();
            Port = reader.ReadUShort();
            CanCreateNewCharacter = reader.ReadBoolean();
            Ticket = reader.ReadUTF();
        }
    }
}