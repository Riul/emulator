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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive
{
    public class InteractiveUseEndedMessage : NetworkMessage
    {
        public const uint Id = 6112;

        public int elemId;
        public short skillId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public InteractiveUseEndedMessage()
        {
        }

        public InteractiveUseEndedMessage(int elemId, short skillId)
        {
            this.elemId = elemId;
            this.skillId = skillId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(elemId);
            writer.WriteShort(skillId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            elemId = reader.ReadInt();
            if (elemId < 0)
                throw new Exception("Forbidden value on elemId = " + elemId + ", it doesn't respect the following condition : elemId < 0");
            skillId = reader.ReadShort();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
        }
    }
}