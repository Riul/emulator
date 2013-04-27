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
    public class GuildSpellUpgradeRequestMessage : NetworkMessage
    {
        public const uint Id = 5699;

        public int spellId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildSpellUpgradeRequestMessage()
        {
        }

        public GuildSpellUpgradeRequestMessage(int spellId)
        {
            this.spellId = spellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(spellId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            spellId = reader.ReadInt();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
        }
    }
}