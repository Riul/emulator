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
    public class SpellForgottenMessage : NetworkMessage
    {
        public const uint Id = 5834;

        public short boostPoint;
        public short[] spellsId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public SpellForgottenMessage()
        {
        }

        public SpellForgottenMessage(short[] spellsId, short boostPoint)
        {
            this.spellsId = spellsId;
            this.boostPoint = boostPoint;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) spellsId.Length);
            foreach (var entry in spellsId)
            {
                writer.WriteShort(entry);
            }
            writer.WriteShort(boostPoint);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            spellsId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                spellsId[i] = reader.ReadShort();
            }
            boostPoint = reader.ReadShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
        }
    }
}