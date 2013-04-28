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

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class EntityDispositionInformations
    {
        public const short ID = 60;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short CellId { get; set; }
        public sbyte Direction { get; set; }


        public EntityDispositionInformations()
        {
        }

        public EntityDispositionInformations(short cellId, sbyte direction)
        {
            CellId = cellId;
            Direction = direction;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(CellId);
            writer.WriteSByte(Direction);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            CellId = reader.ReadShort();
            Direction = reader.ReadSByte();
        }
    }
}