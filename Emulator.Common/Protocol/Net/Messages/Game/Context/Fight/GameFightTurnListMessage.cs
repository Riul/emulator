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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightTurnListMessage : NetworkMessage
    {
        public const uint Id = 713;

        public int[] deadsIds;
        public int[] ids;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameFightTurnListMessage()
        {
        }

        public GameFightTurnListMessage(int[] ids, int[] deadsIds)
        {
            this.ids = ids;
            this.deadsIds = deadsIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ids.Length);
            foreach (var entry in ids)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) deadsIds.Length);
            foreach (var entry in deadsIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ids = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                ids[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            deadsIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                deadsIds[i] = reader.ReadInt();
            }
        }
    }
}