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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest
{
    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public const short ID = 382;

        public override short TypeId
        {
            get { return ID; }
        }

        public short StepId { get; set; }
        public QuestObjectiveInformations[] Objectives { get; set; }


        public QuestActiveDetailedInformations()
        {
        }

        public QuestActiveDetailedInformations(short questId, short stepId, QuestObjectiveInformations[] objectives)
                : base(questId)
        {
            StepId = stepId;
            Objectives = objectives;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(StepId);
            writer.WriteUShort((ushort) Objectives.Length);
            foreach (var entry in Objectives)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            StepId = reader.ReadShort();
            var limit = reader.ReadUShort();
            Objectives = new QuestObjectiveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Objectives[i] = Types.ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadShort());
                Objectives[i].Deserialize(reader);
            }
        }
    }
}