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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Visual
{
    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        public const uint ID = 6114;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int CasterId { get; set; }
        public short TargetCellId { get; set; }
        public short SpellId { get; set; }
        public sbyte SpellLevel { get; set; }


        public GameRolePlaySpellAnimMessage()
        {
        }

        public GameRolePlaySpellAnimMessage(int casterId, short targetCellId, short spellId, sbyte spellLevel)
        {
            CasterId = casterId;
            TargetCellId = targetCellId;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(CasterId);
            writer.WriteShort(TargetCellId);
            writer.WriteShort(SpellId);
            writer.WriteSByte(SpellLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            CasterId = reader.ReadInt();
            TargetCellId = reader.ReadShort();
            SpellId = reader.ReadShort();
            SpellLevel = reader.ReadSByte();
        }
    }
}