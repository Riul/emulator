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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class ObjectUseOnCellMessage : ObjectUseMessage
    {
        public const uint Id = 3013;

        public short cells;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ObjectUseOnCellMessage()
        {
        }

        public ObjectUseOnCellMessage(int objectUID, short cells)
            : base(objectUID)
        {
            this.cells = cells;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(cells);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            cells = reader.ReadShort();
            if (cells < 0 || cells > 559)
                throw new Exception("Forbidden value on cells = " + cells + ", it doesn't respect the following condition : cells < 0 || cells > 559");
        }
    }
}