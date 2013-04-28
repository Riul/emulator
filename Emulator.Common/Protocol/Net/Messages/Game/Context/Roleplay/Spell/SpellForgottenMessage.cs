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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Spell
{
    public class SpellForgottenMessage : NetworkMessage
    {
        public const uint ID = 5834;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] SpellsId { get; set; }
        public short BoostPoint { get; set; }


        public SpellForgottenMessage()
        {
        }

        public SpellForgottenMessage(short[] spellsId, short boostPoint)
        {
            SpellsId = spellsId;
            BoostPoint = boostPoint;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) SpellsId.Length);
            foreach (var entry in SpellsId)
            {
                writer.WriteShort(entry);
            }
            writer.WriteShort(BoostPoint);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            SpellsId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                SpellsId[i] = reader.ReadShort();
            }
            BoostPoint = reader.ReadShort();
        }
    }
}