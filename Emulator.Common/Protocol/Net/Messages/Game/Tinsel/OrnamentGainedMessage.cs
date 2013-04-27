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

namespace Emulator.Common.Protocol.Net.Messages.Game.Tinsel
{
    public class OrnamentGainedMessage : NetworkMessage
    {
        public const uint Id = 6368;

        public short ornamentId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public OrnamentGainedMessage()
        {
        }

        public OrnamentGainedMessage(short ornamentId)
        {
            this.ornamentId = ornamentId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ornamentId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ornamentId = reader.ReadShort();
            if (ornamentId < 0)
                throw new Exception("Forbidden value on ornamentId = " + ornamentId + ", it doesn't respect the following condition : ornamentId < 0");
        }
    }
}