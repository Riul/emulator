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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const uint Id = 5642;

        public int mapId;
        public int[] npcsIdsWithQuest;
        public int[] npcsIdsWithoutQuest;
        public GameRolePlayNpcQuestFlag[] questFlags;


        public MapNpcsQuestStatusUpdateMessage()
        {
        }

        public MapNpcsQuestStatusUpdateMessage(int mapId, int[] npcsIdsWithQuest, GameRolePlayNpcQuestFlag[] questFlags, int[] npcsIdsWithoutQuest)
        {
            this.mapId = mapId;
            this.npcsIdsWithQuest = npcsIdsWithQuest;
            this.questFlags = questFlags;
            this.npcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(mapId);
            writer.WriteUShort((ushort) npcsIdsWithQuest.Length);
            foreach (var entry in npcsIdsWithQuest)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) questFlags.Length);
            foreach (var entry in questFlags)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) npcsIdsWithoutQuest.Length);
            foreach (var entry in npcsIdsWithoutQuest)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            mapId = reader.ReadInt();
            var limit = reader.ReadUShort();
            npcsIdsWithQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                npcsIdsWithQuest[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            questFlags = new GameRolePlayNpcQuestFlag[limit];
            for (int i = 0; i < limit; i++)
            {
                questFlags[i] = new GameRolePlayNpcQuestFlag();
                questFlags[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            npcsIdsWithoutQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                npcsIdsWithoutQuest[i] = reader.ReadInt();
            }
        }
    }
}