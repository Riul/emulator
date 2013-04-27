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

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Creation
{
    public class CharacterNameSuggestionFailureMessage : NetworkMessage
    {
        public const uint Id = 164;

        public sbyte reason;

        public override uint MessageId
        {
            get { return Id; }
        }


        public CharacterNameSuggestionFailureMessage()
        {
        }

        public CharacterNameSuggestionFailureMessage(sbyte reason)
        {
            this.reason = reason;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(reason);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            reason = reader.ReadSByte();
            if (reason < 0)
                throw new Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
        }
    }
}