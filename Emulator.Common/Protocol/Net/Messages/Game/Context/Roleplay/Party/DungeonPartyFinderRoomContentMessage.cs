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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class DungeonPartyFinderRoomContentMessage : NetworkMessage
    {
        public const uint ID = 6247;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short DungeonId { get; set; }
        public DungeonPartyFinderPlayer[] Players { get; set; }


        public DungeonPartyFinderRoomContentMessage()
        {
        }

        public DungeonPartyFinderRoomContentMessage(short dungeonId, DungeonPartyFinderPlayer[] players)
        {
            DungeonId = dungeonId;
            Players = players;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(DungeonId);
            writer.WriteUShort((ushort) Players.Length);
            foreach (var entry in Players)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            DungeonId = reader.ReadShort();
            var limit = reader.ReadUShort();
            Players = new DungeonPartyFinderPlayer[limit];
            for (int i = 0; i < limit; i++)
            {
                Players[i] = new DungeonPartyFinderPlayer();
                Players[i].Deserialize(reader);
            }
        }
    }
}