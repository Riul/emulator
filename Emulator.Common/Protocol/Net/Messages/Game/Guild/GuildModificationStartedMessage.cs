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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildModificationStartedMessage : NetworkMessage
    {
        public const uint Id = 6324;

        public bool canChangeEmblem;
        public bool canChangeName;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildModificationStartedMessage()
        {
        }

        public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
        {
            this.canChangeName = canChangeName;
            this.canChangeEmblem = canChangeEmblem;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, canChangeName);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, canChangeEmblem);
            writer.WriteByte(flag1);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            canChangeName = BooleanByteWrapper.GetFlag(flag1, 0);
            canChangeEmblem = BooleanByteWrapper.GetFlag(flag1, 1);
        }
    }
}