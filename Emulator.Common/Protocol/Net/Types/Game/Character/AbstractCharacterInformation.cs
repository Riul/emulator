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

namespace Emulator.Common.Protocol.Net.Types.Game.Character
{
    public class AbstractCharacterInformation
    {
        public const short ID = 400;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Id { get; set; }


        public AbstractCharacterInformation()
        {
        }

        public AbstractCharacterInformation(int id)
        {
            Id = id;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Id);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadInt();
        }
    }
}