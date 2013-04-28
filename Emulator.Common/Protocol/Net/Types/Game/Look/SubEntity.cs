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
    public class SubEntity
    {
        public const short ID = 54;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte BindingPointCategory { get; set; }
        public sbyte BindingPointIndex { get; set; }
        public EntityLook SubEntityLook { get; set; }


        public SubEntity()
        {
        }

        public SubEntity(sbyte bindingPointCategory, sbyte bindingPointIndex, EntityLook subEntityLook)
        {
            BindingPointCategory = bindingPointCategory;
            BindingPointIndex = bindingPointIndex;
            SubEntityLook = subEntityLook;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(BindingPointCategory);
            writer.WriteSByte(BindingPointIndex);
            SubEntityLook.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            BindingPointCategory = reader.ReadSByte();
            BindingPointIndex = reader.ReadSByte();
            SubEntityLook = new EntityLook();
            SubEntityLook.Deserialize(reader);
        }
    }
}