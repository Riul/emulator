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
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkMulticraftCustomerMessage : NetworkMessage
    {
        public const uint Id = 5817;
        public sbyte crafterJobLevel;

        public sbyte maxCase;
        public int skillId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeStartOkMulticraftCustomerMessage()
        {
        }

        public ExchangeStartOkMulticraftCustomerMessage(sbyte maxCase, int skillId, sbyte crafterJobLevel)
        {
            this.maxCase = maxCase;
            this.skillId = skillId;
            this.crafterJobLevel = crafterJobLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(maxCase);
            writer.WriteInt(skillId);
            writer.WriteSByte(crafterJobLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            maxCase = reader.ReadSByte();
            if (maxCase < 0)
                throw new Exception("Forbidden value on maxCase = " + maxCase + ", it doesn't respect the following condition : maxCase < 0");
            skillId = reader.ReadInt();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            crafterJobLevel = reader.ReadSByte();
            if (crafterJobLevel < 0)
                throw new Exception("Forbidden value on crafterJobLevel = " + crafterJobLevel + ", it doesn't respect the following condition : crafterJobLevel < 0");
        }
    }
}