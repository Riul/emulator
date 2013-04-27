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

namespace Emulator.Common.Protocol.Net.Types.Game.Shortcut
{
    public class Shortcut
    {
        public const short Id = 369;

        public int slot;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public Shortcut()
        {
        }

        public Shortcut(int slot)
        {
            this.slot = slot;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(slot);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            slot = reader.ReadInt();
            if (slot < 0 || slot > 99)
                throw new Exception("Forbidden value on slot = " + slot + ", it doesn't respect the following condition : slot < 0 || slot > 99");
        }
    }
}