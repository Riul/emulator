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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildModificationStartedMessage : NetworkMessage
    {
        public const uint ID = 6324;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool CanChangeName { get; set; }
        public bool CanChangeEmblem { get; set; }


        public GuildModificationStartedMessage()
        {
        }

        public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
        {
            CanChangeName = canChangeName;
            CanChangeEmblem = canChangeEmblem;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, CanChangeName);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, CanChangeEmblem);
            writer.WriteByte(flag1);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            CanChangeName = BooleanByteWrapper.GetFlag(flag1, 0);
            CanChangeEmblem = BooleanByteWrapper.GetFlag(flag1, 1);
        }
    }
}