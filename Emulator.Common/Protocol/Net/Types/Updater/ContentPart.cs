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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Updater
{
    public class ContentPart
    {
        public const short Id = 350;

        public string id;
        public sbyte state;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public ContentPart()
        {
        }

        public ContentPart(string id, sbyte state)
        {
            this.id = id;
            this.state = state;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(id);
            writer.WriteSByte(state);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            id = reader.ReadUTF();
            state = reader.ReadSByte();
            if (state < 0)
                throw new Exception("Forbidden value on state = " + state + ", it doesn't respect the following condition : state < 0");
        }
    }
}