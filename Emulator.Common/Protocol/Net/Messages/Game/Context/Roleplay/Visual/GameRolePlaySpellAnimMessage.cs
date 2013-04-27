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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Visual
{
    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        public const uint Id = 6114;

        public int casterId;
        public short spellId;
        public sbyte spellLevel;
        public short targetCellId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameRolePlaySpellAnimMessage()
        {
        }

        public GameRolePlaySpellAnimMessage(int casterId, short targetCellId, short spellId, sbyte spellLevel)
        {
            this.casterId = casterId;
            this.targetCellId = targetCellId;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(casterId);
            writer.WriteShort(targetCellId);
            writer.WriteShort(spellId);
            writer.WriteSByte(spellLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            casterId = reader.ReadInt();
            targetCellId = reader.ReadShort();
            if (targetCellId < 0 || targetCellId > 559)
                throw new Exception("Forbidden value on targetCellId = " + targetCellId + ", it doesn't respect the following condition : targetCellId < 0 || targetCellId > 559");
            spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            spellLevel = reader.ReadSByte();
            if (spellLevel < 1 || spellLevel > 6)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 6");
        }
    }
}