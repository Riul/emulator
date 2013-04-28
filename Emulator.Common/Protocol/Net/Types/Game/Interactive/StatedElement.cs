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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive
{
    public class StatedElement
    {
        public const short ID = 108;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int ElementId { get; set; }
        public short ElementCellId { get; set; }
        public int ElementState { get; set; }


        public StatedElement()
        {
        }

        public StatedElement(int elementId, short elementCellId, int elementState)
        {
            ElementId = elementId;
            ElementCellId = elementCellId;
            ElementState = elementState;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteShort(ElementCellId);
            writer.WriteInt(ElementState);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ElementId = reader.ReadInt();
            ElementCellId = reader.ReadShort();
            ElementState = reader.ReadInt();
        }
    }
}