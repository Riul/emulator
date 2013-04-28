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
    public class EntityMovementInformations
    {
        public const short ID = 63;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Id { get; set; }
        public sbyte[] Steps { get; set; }


        public EntityMovementInformations()
        {
        }

        public EntityMovementInformations(int id, sbyte[] steps)
        {
            Id = id;
            Steps = steps;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Id);
            writer.WriteUShort((ushort) Steps.Length);
            foreach (var entry in Steps)
            {
                writer.WriteSByte(entry);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadInt();
            var limit = reader.ReadUShort();
            Steps = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                Steps[i] = reader.ReadSByte();
            }
        }
    }
}