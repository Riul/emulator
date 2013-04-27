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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const uint Id = 5715;

        public int characterId;
        public int taxCollectorId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildFightLeaveRequestMessage()
        {
        }

        public GuildFightLeaveRequestMessage(int taxCollectorId, int characterId)
        {
            this.taxCollectorId = taxCollectorId;
            this.characterId = characterId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(taxCollectorId);
            writer.WriteInt(characterId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            taxCollectorId = reader.ReadInt();
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
        }
    }
}