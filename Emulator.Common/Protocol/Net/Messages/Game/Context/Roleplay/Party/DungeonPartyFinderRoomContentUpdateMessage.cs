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
    public class DungeonPartyFinderRoomContentUpdateMessage : NetworkMessage
    {
        public const uint Id = 6250;

        public DungeonPartyFinderPlayer[] addedPlayers;
        public short dungeonId;
        public int[] removedPlayersIds;

        public override uint MessageId
        {
            get { return Id; }
        }


        public DungeonPartyFinderRoomContentUpdateMessage()
        {
        }

        public DungeonPartyFinderRoomContentUpdateMessage(short dungeonId, DungeonPartyFinderPlayer[] addedPlayers, int[] removedPlayersIds)
        {
            this.dungeonId = dungeonId;
            this.addedPlayers = addedPlayers;
            this.removedPlayersIds = removedPlayersIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(dungeonId);
            writer.WriteUShort((ushort) addedPlayers.Length);
            foreach (var entry in addedPlayers)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) removedPlayersIds.Length);
            foreach (var entry in removedPlayersIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            var limit = reader.ReadUShort();
            addedPlayers = new DungeonPartyFinderPlayer[limit];
            for (int i = 0; i < limit; i++)
            {
                addedPlayers[i] = new DungeonPartyFinderPlayer();
                addedPlayers[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            removedPlayersIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                removedPlayersIds[i] = reader.ReadInt();
            }
        }
    }
}