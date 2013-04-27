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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightSpellCooldown
    {
        public const short Id = 205;

        public sbyte cooldown;
        public int spellId;


        public GameFightSpellCooldown()
        {
        }

        public GameFightSpellCooldown(int spellId, sbyte cooldown)
        {
            this.spellId = spellId;
            this.cooldown = cooldown;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(spellId);
            writer.WriteSByte(cooldown);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            spellId = reader.ReadInt();
            cooldown = reader.ReadSByte();
            if (cooldown < 0)
                throw new Exception("Forbidden value on cooldown = " + cooldown + ", it doesn't respect the following condition : cooldown < 0");
        }
    }
}