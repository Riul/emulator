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
    public class QuestObjectiveInformations
    {
        public const short Id = 385;

        public short objectiveId;
        public bool objectiveStatus;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public QuestObjectiveInformations()
        {
        }

        public QuestObjectiveInformations(short objectiveId, bool objectiveStatus)
        {
            this.objectiveId = objectiveId;
            this.objectiveStatus = objectiveStatus;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(objectiveId);
            writer.WriteBoolean(objectiveStatus);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            objectiveId = reader.ReadShort();
            if (objectiveId < 0)
                throw new Exception("Forbidden value on objectiveId = " + objectiveId + ", it doesn't respect the following condition : objectiveId < 0");
            objectiveStatus = reader.ReadBoolean();
        }
    }
}