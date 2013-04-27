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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Quest
{
    public class QuestListMessage : NetworkMessage
    {
        public const uint Id = 5626;

        public QuestActiveInformations[] activeQuests;
        public short[] finishedQuestsCounts;
        public short[] finishedQuestsIds;


        public QuestListMessage()
        {
        }

        public QuestListMessage(short[] finishedQuestsIds, short[] finishedQuestsCounts, QuestActiveInformations[] activeQuests)
        {
            this.finishedQuestsIds = finishedQuestsIds;
            this.finishedQuestsCounts = finishedQuestsCounts;
            this.activeQuests = activeQuests;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) finishedQuestsIds.Length);
            foreach (var entry in finishedQuestsIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) finishedQuestsCounts.Length);
            foreach (var entry in finishedQuestsCounts)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) activeQuests.Length);
            foreach (var entry in activeQuests)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            finishedQuestsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedQuestsIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            finishedQuestsCounts = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedQuestsCounts[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            activeQuests = new QuestActiveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                activeQuests[i] = Types.ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
                activeQuests[i].Deserialize(reader);
            }
        }
    }
}