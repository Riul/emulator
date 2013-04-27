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
    public class IgnoredDeleteResultMessage : NetworkMessage
    {
        public const uint Id = 5677;

        public string name;
        public bool session;
        public bool success;

        public override uint MessageId
        {
            get { return Id; }
        }


        public IgnoredDeleteResultMessage()
        {
        }

        public IgnoredDeleteResultMessage(bool success, bool session, string name)
        {
            this.success = success;
            this.session = session;
            this.name = name;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, success);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, session);
            writer.WriteByte(flag1);
            writer.WriteUTF(name);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            success = BooleanByteWrapper.GetFlag(flag1, 0);
            session = BooleanByteWrapper.GetFlag(flag1, 1);
            name = reader.ReadUTF();
        }
    }
}