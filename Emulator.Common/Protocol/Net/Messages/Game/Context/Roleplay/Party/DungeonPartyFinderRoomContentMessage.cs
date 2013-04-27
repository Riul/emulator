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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class DungeonPartyFinderRoomContentMessage : NetworkMessage
    {
        public const uint Id = 6247;

        public short dungeonId;
        public DungeonPartyFinderPlayer[] players;

        public override uint MessageId
        {
            get { return Id; }
        }


        public DungeonPartyFinderRoomContentMessage()
        {
        }

        public DungeonPartyFinderRoomContentMessage(short dungeonId, DungeonPartyFinderPlayer[] players)
        {
            this.dungeonId = dungeonId;
            this.players = players;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(dungeonId);
            writer.WriteUShort((ushort) players.Length);
            foreach (var entry in players)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            var limit = reader.ReadUShort();
            players = new DungeonPartyFinderPlayer[limit];
            for (int i = 0; i < limit; i++)
            {
                players[i] = new DungeonPartyFinderPlayer();
                players[i].Deserialize(reader);
            }
        }
    }
}