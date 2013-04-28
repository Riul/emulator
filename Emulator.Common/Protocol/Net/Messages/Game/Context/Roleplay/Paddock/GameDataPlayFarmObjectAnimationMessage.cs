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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Paddock
{
    public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
    {
        public const uint ID = 6026;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] CellId { get; set; }


        public GameDataPlayFarmObjectAnimationMessage()
        {
        }

        public GameDataPlayFarmObjectAnimationMessage(short[] cellId)
        {
            CellId = cellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) CellId.Length);
            foreach (var entry in CellId)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            CellId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                CellId[i] = reader.ReadShort();
            }
        }
    }
}