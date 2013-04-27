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

namespace Emulator.Common.Protocol.Net.Messages.Game.Basic
{
    public class BasicSetAwayModeRequestMessage : NetworkMessage
    {
        public const uint Id = 5665;

        public bool enable;
        public bool invisible;

        public override uint MessageId
        {
            get { return Id; }
        }


        public BasicSetAwayModeRequestMessage()
        {
        }

        public BasicSetAwayModeRequestMessage(bool enable, bool invisible)
        {
            this.enable = enable;
            this.invisible = invisible;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, enable);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, invisible);
            writer.WriteByte(flag1);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            enable = BooleanByteWrapper.GetFlag(flag1, 0);
            invisible = BooleanByteWrapper.GetFlag(flag1, 1);
        }
    }
}