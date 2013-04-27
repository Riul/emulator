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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context
{
    public class GameContextRemoveMultipleElementsMessage : NetworkMessage
    {
        public const uint Id = 252;

        public int[] id;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameContextRemoveMultipleElementsMessage()
        {
        }

        public GameContextRemoveMultipleElementsMessage(int[] id)
        {
            this.id = id;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) id.Length);
            foreach (var entry in id)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            id = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                id[i] = reader.ReadInt();
            }
        }
    }
}