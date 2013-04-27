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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Houses.Guild
{
    public class HouseGuildShareRequestMessage : NetworkMessage
    {
        public const uint Id = 5704;

        public bool enable;
        public uint rights;

        public override uint MessageId
        {
            get { return Id; }
        }


        public HouseGuildShareRequestMessage()
        {
        }

        public HouseGuildShareRequestMessage(bool enable, uint rights)
        {
            this.enable = enable;
            this.rights = rights;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(enable);
            writer.WriteUInt(rights);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            enable = reader.ReadBoolean();
            rights = reader.ReadUInt();
            if (rights < 0 || rights > 4294967295)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0 || rights > 4294967295");
        }
    }
}