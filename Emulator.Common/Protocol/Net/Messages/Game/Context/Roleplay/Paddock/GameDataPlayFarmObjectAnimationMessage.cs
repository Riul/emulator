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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Paddock
{
    public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
    {
        public const uint Id = 6026;

        public short[] cellId;


        public GameDataPlayFarmObjectAnimationMessage()
        {
        }

        public GameDataPlayFarmObjectAnimationMessage(short[] cellId)
        {
            this.cellId = cellId;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) cellId.Length);
            foreach (var entry in cellId)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            cellId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                cellId[i] = reader.ReadShort();
            }
        }
    }
}