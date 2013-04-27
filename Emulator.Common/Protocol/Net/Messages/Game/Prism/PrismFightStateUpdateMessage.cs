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

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightStateUpdateMessage : NetworkMessage
    {
        public const uint Id = 6040;

        public sbyte state;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PrismFightStateUpdateMessage()
        {
        }

        public PrismFightStateUpdateMessage(sbyte state)
        {
            this.state = state;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(state);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            state = reader.ReadSByte();
            if (state < 0)
                throw new Exception("Forbidden value on state = " + state + ", it doesn't respect the following condition : state < 0");
        }
    }
}