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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Quest
{
    public class QuestListMessage : NetworkMessage
    {
        public const uint Id = 5626;

        public QuestActiveInformations[] activeQuests;
        public short[] finishedQuestsCounts;
        public short[] finishedQuestsIds;

        public override uint MessageId
        {
            get { return Id; }
        }


        public QuestListMessage()
        {
        }

        public QuestListMessage(short[] finishedQuestsIds, short[] finishedQuestsCounts, QuestActiveInformations[] activeQuests)
        {
            this.finishedQuestsIds = finishedQuestsIds;
            this.finishedQuestsCounts = finishedQuestsCounts;
            this.activeQuests = activeQuests;
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