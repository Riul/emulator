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
    public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
    {
        public const uint Id = 5941;

        public sbyte nbCase;
        public int skillId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeStartOkCraftWithInformationMessage()
        {
        }

        public ExchangeStartOkCraftWithInformationMessage(sbyte nbCase, int skillId)
        {
            this.nbCase = nbCase;
            this.skillId = skillId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(nbCase);
            writer.WriteInt(skillId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            nbCase = reader.ReadSByte();
            if (nbCase < 0)
                throw new Exception("Forbidden value on nbCase = " + nbCase + ", it doesn't respect the following condition : nbCase < 0");
            skillId = reader.ReadInt();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
        }
    }
}