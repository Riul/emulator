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

namespace Emulator.Common.Protocol.Net.Messages.Game.Pvp
{
    public class AlignmentSubAreaUpdateMessage : NetworkMessage
    {
        public const uint Id = 6057;

        public bool quiet;
        public sbyte side;
        public short subAreaId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AlignmentSubAreaUpdateMessage()
        {
        }

        public AlignmentSubAreaUpdateMessage(short subAreaId, sbyte side, bool quiet)
        {
            this.subAreaId = subAreaId;
            this.side = side;
            this.quiet = quiet;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(subAreaId);
            writer.WriteSByte(side);
            writer.WriteBoolean(quiet);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            side = reader.ReadSByte();
            quiet = reader.ReadBoolean();
        }
    }
}