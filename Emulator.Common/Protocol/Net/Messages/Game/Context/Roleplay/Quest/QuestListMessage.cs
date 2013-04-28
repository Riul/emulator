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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Quest
{
    public class QuestListMessage : NetworkMessage
    {
        public const uint ID = 5626;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] FinishedQuestsIds { get; set; }
        public short[] FinishedQuestsCounts { get; set; }
        public QuestActiveInformations[] ActiveQuests { get; set; }


        public QuestListMessage()
        {
        }

        public QuestListMessage(short[] finishedQuestsIds, short[] finishedQuestsCounts, QuestActiveInformations[] activeQuests)
        {
            FinishedQuestsIds = finishedQuestsIds;
            FinishedQuestsCounts = finishedQuestsCounts;
            ActiveQuests = activeQuests;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) FinishedQuestsIds.Length);
            foreach (var entry in FinishedQuestsIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) FinishedQuestsCounts.Length);
            foreach (var entry in FinishedQuestsCounts)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) ActiveQuests.Length);
            foreach (var entry in ActiveQuests)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            FinishedQuestsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                FinishedQuestsIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            FinishedQuestsCounts = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                FinishedQuestsCounts[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            ActiveQuests = new QuestActiveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                ActiveQuests[i] = Types.ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
                ActiveQuests[i].Deserialize(reader);
            }
        }
    }
}