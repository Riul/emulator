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

namespace Emulator.Common.Protocol.Net.Types
{
    public class GameServerInformations
    {
        public const short ID = 25;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public ushort Id { get; set; }
        public sbyte Status { get; set; }
        public sbyte Completion { get; set; }
        public bool IsSelectable { get; set; }
        public sbyte CharactersCount { get; set; }
        public double Date { get; set; }


        public GameServerInformations()
        {
        }

        public GameServerInformations(ushort id, sbyte status, sbyte completion, bool isSelectable, sbyte charactersCount, double date)
        {
            Id = id;
            Status = status;
            Completion = completion;
            IsSelectable = isSelectable;
            CharactersCount = charactersCount;
            Date = date;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort(Id);
            writer.WriteSByte(Status);
            writer.WriteSByte(Completion);
            writer.WriteBoolean(IsSelectable);
            writer.WriteSByte(CharactersCount);
            writer.WriteDouble(Date);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadUShort();
            Status = reader.ReadSByte();
            Completion = reader.ReadSByte();
            IsSelectable = reader.ReadBoolean();
            CharactersCount = reader.ReadSByte();
            Date = reader.ReadDouble();
        }
    }
}