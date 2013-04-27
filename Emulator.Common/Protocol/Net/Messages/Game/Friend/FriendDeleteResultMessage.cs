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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Friend
{
    public class FriendDeleteResultMessage : NetworkMessage
    {
        public const uint Id = 5601;

        public string name;
        public bool success;

        public override uint MessageId
        {
            get { return Id; }
        }


        public FriendDeleteResultMessage()
        {
        }

        public FriendDeleteResultMessage(bool success, string name)
        {
            this.success = success;
            this.name = name;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(success);
            writer.WriteUTF(name);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            success = reader.ReadBoolean();
            name = reader.ReadUTF();
        }
    }
}