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
    public class InteractiveUseRequestMessage : NetworkMessage
    {
        public const uint Id = 5001;

        public int elemId;
        public int skillInstanceUid;

        public override uint MessageId
        {
            get { return Id; }
        }


        public InteractiveUseRequestMessage()
        {
        }

        public InteractiveUseRequestMessage(int elemId, int skillInstanceUid)
        {
            this.elemId = elemId;
            this.skillInstanceUid = skillInstanceUid;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(elemId);
            writer.WriteInt(skillInstanceUid);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            elemId = reader.ReadInt();
            if (elemId < 0)
                throw new Exception("Forbidden value on elemId = " + elemId + ", it doesn't respect the following condition : elemId < 0");
            skillInstanceUid = reader.ReadInt();
            if (skillInstanceUid < 0)
                throw new Exception("Forbidden value on skillInstanceUid = " + skillInstanceUid + ", it doesn't respect the following condition : skillInstanceUid < 0");
        }
    }
}