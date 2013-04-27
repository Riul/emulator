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
    public class MoodSmileyResultMessage : NetworkMessage
    {
        public const uint Id = 6196;

        public sbyte resultCode;
        public sbyte smileyId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public MoodSmileyResultMessage()
        {
        }

        public MoodSmileyResultMessage(sbyte resultCode, sbyte smileyId)
        {
            this.resultCode = resultCode;
            this.smileyId = smileyId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(resultCode);
            writer.WriteSByte(smileyId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            resultCode = reader.ReadSByte();
            if (resultCode < 0)
                throw new Exception("Forbidden value on resultCode = " + resultCode + ", it doesn't respect the following condition : resultCode < 0");
            smileyId = reader.ReadSByte();
        }
    }
}