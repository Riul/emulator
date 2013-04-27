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

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat.Smiley
{
    public class LocalizedChatSmileyMessage : ChatSmileyMessage
    {
        public const uint Id = 6185;

        public short cellId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public LocalizedChatSmileyMessage()
        {
        }

        public LocalizedChatSmileyMessage(int entityId, sbyte smileyId, int accountId, short cellId)
            : base(entityId, smileyId, accountId)
        {
            this.cellId = cellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(cellId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
        }
    }
}