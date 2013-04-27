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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class EntityMovementInformations
    {
        public const short Id = 63;

        public int id;
        public sbyte[] steps;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public EntityMovementInformations()
        {
        }

        public EntityMovementInformations(int id, sbyte[] steps)
        {
            this.id = id;
            this.steps = steps;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteUShort((ushort) steps.Length);
            foreach (var entry in steps)
            {
                writer.WriteSByte(entry);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            id = reader.ReadInt();
            var limit = reader.ReadUShort();
            steps = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                steps[i] = reader.ReadSByte();
            }
        }
    }
}