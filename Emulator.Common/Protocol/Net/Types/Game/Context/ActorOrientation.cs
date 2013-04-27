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

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class ActorOrientation
    {
        public const short Id = 353;

        public sbyte direction;
        public int id;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public ActorOrientation()
        {
        }

        public ActorOrientation(int id, sbyte direction)
        {
            this.id = id;
            this.direction = direction;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteSByte(direction);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            id = reader.ReadInt();
            direction = reader.ReadSByte();
            if (direction < 0)
                throw new Exception("Forbidden value on direction = " + direction + ", it doesn't respect the following condition : direction < 0");
        }
    }
}