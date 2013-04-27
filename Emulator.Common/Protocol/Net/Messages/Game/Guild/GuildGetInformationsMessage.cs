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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildGetInformationsMessage : NetworkMessage
    {
        public const uint Id = 5550;

        public sbyte infoType;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildGetInformationsMessage()
        {
        }

        public GuildGetInformationsMessage(sbyte infoType)
        {
            this.infoType = infoType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(infoType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            infoType = reader.ReadSByte();
            if (infoType < 0)
                throw new Exception("Forbidden value on infoType = " + infoType + ", it doesn't respect the following condition : infoType < 0");
        }
    }
}