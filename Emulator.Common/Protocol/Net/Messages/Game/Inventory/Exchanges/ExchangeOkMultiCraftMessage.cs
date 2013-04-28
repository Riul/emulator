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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeOkMultiCraftMessage : NetworkMessage
    {
        public const uint ID = 5768;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int InitiatorId { get; set; }
        public int OtherId { get; set; }
        public sbyte Role { get; set; }


        public ExchangeOkMultiCraftMessage()
        {
        }

        public ExchangeOkMultiCraftMessage(int initiatorId, int otherId, sbyte role)
        {
            InitiatorId = initiatorId;
            OtherId = otherId;
            Role = role;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(InitiatorId);
            writer.WriteInt(OtherId);
            writer.WriteSByte(Role);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            InitiatorId = reader.ReadInt();
            OtherId = reader.ReadInt();
            Role = reader.ReadSByte();
        }
    }
}