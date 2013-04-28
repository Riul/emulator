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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightLoot
    {
        public const short ID = 41;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short[] Objects { get; set; }
        public int Kamas { get; set; }


        public FightLoot()
        {
        }

        public FightLoot(short[] objects, int kamas)
        {
            Objects = objects;
            Kamas = kamas;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Objects.Length);
            foreach (var entry in Objects)
            {
                writer.WriteShort(entry);
            }
            writer.WriteInt(Kamas);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Objects = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Objects[i] = reader.ReadShort();
            }
            Kamas = reader.ReadInt();
        }
    }
}