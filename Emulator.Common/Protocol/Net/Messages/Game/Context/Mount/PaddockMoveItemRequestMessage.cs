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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Mount
{
    public class PaddockMoveItemRequestMessage : NetworkMessage
    {
        public const uint Id = 6052;

        public short newCellId;
        public short oldCellId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PaddockMoveItemRequestMessage()
        {
        }

        public PaddockMoveItemRequestMessage(short oldCellId, short newCellId)
        {
            this.oldCellId = oldCellId;
            this.newCellId = newCellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(oldCellId);
            writer.WriteShort(newCellId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            oldCellId = reader.ReadShort();
            if (oldCellId < 0 || oldCellId > 559)
                throw new Exception("Forbidden value on oldCellId = " + oldCellId + ", it doesn't respect the following condition : oldCellId < 0 || oldCellId > 559");
            newCellId = reader.ReadShort();
            if (newCellId < 0 || newCellId > 559)
                throw new Exception("Forbidden value on newCellId = " + newCellId + ", it doesn't respect the following condition : newCellId < 0 || newCellId > 559");
        }
    }
}