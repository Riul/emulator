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

namespace Emulator.Common.Protocol.Net.Types.Game.Look
{
    public class IndexedEntityLook
    {
        public const short ID = 405;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public EntityLook Look { get; set; }
        public sbyte Index { get; set; }


        public IndexedEntityLook()
        {
        }

        public IndexedEntityLook(EntityLook look, sbyte index)
        {
            Look = look;
            Index = index;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            Look.Serialize(writer);
            writer.WriteSByte(Index);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
            Index = reader.ReadSByte();
        }
    }
}