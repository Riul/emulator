#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:45
// */
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


        public DungeonPartyFinderRoomContentUpdateMessage()
        {
        }

        public DungeonPartyFinderRoomContentUpdateMessage(short dungeonId, DungeonPartyFinderPlayer[] addedPlayers, int[] removedPlayersIds)
        {
            this.dungeonId = dungeonId;
            this.addedPlayers = addedPlayers;
            this.removedPlayersIds = removedPlayersIds;
        }

        public override uint MessageId
        {
            get { return Id; }
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