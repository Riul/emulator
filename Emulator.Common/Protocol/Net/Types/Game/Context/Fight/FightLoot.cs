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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightLoot
    {
        public const short Id = 41;

        public int kamas;
        public short[] objects;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public FightLoot()
        {
        }

        public FightLoot(short[] objects, int kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) objects.Length);
            foreach (var entry in objects)
            {
                writer.WriteShort(entry);
            }
            writer.WriteInt(kamas);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            objects = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                objects[i] = reader.ReadShort();
            }
            kamas = reader.ReadInt();
            if (kamas < 0)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
        }
    }
}