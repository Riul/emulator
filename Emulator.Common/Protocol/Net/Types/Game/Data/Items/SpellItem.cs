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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items
{
    public class SpellItem : Item
    {
        public const short ID = 49;

        public override short TypeId
        {
            get { return ID; }
        }

        public byte Position { get; set; }
        public int SpellId { get; set; }
        public sbyte SpellLevel { get; set; }


        public SpellItem()
        {
        }

        public SpellItem(byte position, int spellId, sbyte spellLevel)
        {
            Position = position;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Position);
            writer.WriteInt(SpellId);
            writer.WriteSByte(SpellLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Position = reader.ReadByte();
            SpellId = reader.ReadInt();
            SpellLevel = reader.ReadSByte();
        }
    }
}