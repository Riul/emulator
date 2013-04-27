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

namespace Emulator.Common.Protocol.Net.Messages.Game.Atlas.Compass
{
    public class CompassResetMessage : NetworkMessage
    {
        public const uint Id = 5584;

        public sbyte type;

        public override uint MessageId
        {
            get { return Id; }
        }


        public CompassResetMessage()
        {
        }

        public CompassResetMessage(sbyte type)
        {
            this.type = type;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(type);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
        }
    }
}