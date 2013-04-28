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

namespace Emulator.Common.Protocol.Net.Types.Updater
{
    public class ContentPart
    {
        public const short ID = 350;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public string Id { get; set; }
        public sbyte State { get; set; }


        public ContentPart()
        {
        }

        public ContentPart(string id, sbyte state)
        {
            Id = id;
            State = state;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Id);
            writer.WriteSByte(State);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadUTF();
            State = reader.ReadSByte();
        }
    }
}