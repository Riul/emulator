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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightCastRequestMessage : NetworkMessage
    {
        public const uint ID = 1005;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short SpellId { get; set; }
        public short CellId { get; set; }


        public GameActionFightCastRequestMessage()
        {
        }

        public GameActionFightCastRequestMessage(short spellId, short cellId)
        {
            SpellId = spellId;
            CellId = cellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(SpellId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SpellId = reader.ReadShort();
            CellId = reader.ReadShort();
        }
    }
}