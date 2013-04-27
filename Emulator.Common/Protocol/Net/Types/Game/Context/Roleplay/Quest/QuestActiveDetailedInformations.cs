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
//     Created on 26/04/2013 at 16:46
// */
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest
{
    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public const short Id = 382;

        public QuestObjectiveInformations[] objectives;
        public short stepId;


        public QuestActiveDetailedInformations()
        {
        }

        public QuestActiveDetailedInformations(short questId, short stepId, QuestObjectiveInformations[] objectives)
            : base(questId)
        {
            this.stepId = stepId;
            this.objectives = objectives;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(stepId);
            writer.WriteUShort((ushort) objectives.Length);
            foreach (var entry in objectives)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            stepId = reader.ReadShort();
            if (stepId < 0)
                throw new Exception("Forbidden value on stepId = " + stepId + ", it doesn't respect the following condition : stepId < 0");
            var limit = reader.ReadUShort();
            objectives = new QuestObjectiveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                objectives[i] = Types.ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadShort());
                objectives[i].Deserialize(reader);
            }
        }
    }
}