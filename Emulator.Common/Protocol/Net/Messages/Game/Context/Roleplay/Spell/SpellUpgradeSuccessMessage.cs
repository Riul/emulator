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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Spell
{
    public class SpellUpgradeSuccessMessage : NetworkMessage
    {
        public const uint Id = 1201;

        public int spellId;
        public sbyte spellLevel;

        public override uint MessageId
        {
            get { return Id; }
        }


        public SpellUpgradeSuccessMessage()
        {
        }

        public SpellUpgradeSuccessMessage(int spellId, sbyte spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(spellId);
            writer.WriteSByte(spellLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            spellId = reader.ReadInt();
            spellLevel = reader.ReadSByte();
            if (spellLevel < 1 || spellLevel > 6)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 6");
        }
    }
}