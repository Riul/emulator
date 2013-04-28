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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Friend
{
    public class IgnoredDeleteResultMessage : NetworkMessage
    {
        public const uint ID = 5677;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Success { get; set; }
        public bool Session { get; set; }
        public string Name { get; set; }


        public IgnoredDeleteResultMessage()
        {
        }

        public IgnoredDeleteResultMessage(bool success, bool session, string name)
        {
            Success = success;
            Session = session;
            Name = name;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Success);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, Session);
            writer.WriteByte(flag1);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(flag1, 0);
            Session = BooleanByteWrapper.GetFlag(flag1, 1);
            Name = reader.ReadUTF();
        }
    }
}