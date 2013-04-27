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
    public class ExchangeReadyMessage : NetworkMessage
    {
        public const uint Id = 5511;

        public bool ready;
        public short step;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeReadyMessage()
        {
        }

        public ExchangeReadyMessage(bool ready, short step)
        {
            this.ready = ready;
            this.step = step;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(ready);
            writer.WriteShort(step);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ready = reader.ReadBoolean();
            step = reader.ReadShort();
            if (step < 0)
                throw new Exception("Forbidden value on step = " + step + ", it doesn't respect the following condition : step < 0");
        }
    }
}