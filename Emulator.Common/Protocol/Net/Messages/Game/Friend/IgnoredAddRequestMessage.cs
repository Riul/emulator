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
    public class IgnoredAddRequestMessage : NetworkMessage
    {
        public const uint ID = 5673;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Name { get; set; }
        public bool Session { get; set; }


        public IgnoredAddRequestMessage()
        {
        }

        public IgnoredAddRequestMessage(string name, bool session)
        {
            Name = name;
            Session = session;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Name = reader.ReadUTF();
            Session = reader.ReadBoolean();
        }
    }
}