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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightTurnListMessage : NetworkMessage
    {
        public const uint ID = 713;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int[] Ids { get; set; }
        public int[] DeadsIds { get; set; }


        public GameFightTurnListMessage()
        {
        }

        public GameFightTurnListMessage(int[] ids, int[] deadsIds)
        {
            Ids = ids;
            DeadsIds = deadsIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Ids.Length);
            foreach (var entry in Ids)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) DeadsIds.Length);
            foreach (var entry in DeadsIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Ids = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Ids[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            DeadsIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                DeadsIds[i] = reader.ReadInt();
            }
        }
    }
}