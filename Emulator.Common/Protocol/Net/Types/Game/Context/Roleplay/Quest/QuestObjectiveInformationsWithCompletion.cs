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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest
{
    public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
    {
        public const short Id = 386;

        public short curCompletion;
        public short maxCompletion;

        public override short TypeId
        {
            get { return Id; }
        }


        public QuestObjectiveInformationsWithCompletion()
        {
        }

        public QuestObjectiveInformationsWithCompletion(short objectiveId, bool objectiveStatus, short curCompletion, short maxCompletion)
            : base(objectiveId, objectiveStatus)
        {
            this.curCompletion = curCompletion;
            this.maxCompletion = maxCompletion;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(curCompletion);
            writer.WriteShort(maxCompletion);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            curCompletion = reader.ReadShort();
            if (curCompletion < 0)
                throw new Exception("Forbidden value on curCompletion = " + curCompletion + ", it doesn't respect the following condition : curCompletion < 0");
            maxCompletion = reader.ReadShort();
            if (maxCompletion < 0)
                throw new Exception("Forbidden value on maxCompletion = " + maxCompletion + ", it doesn't respect the following condition : maxCompletion < 0");
        }
    }
}