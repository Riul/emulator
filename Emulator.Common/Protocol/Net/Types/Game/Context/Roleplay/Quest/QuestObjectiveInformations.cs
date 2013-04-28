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
    public class QuestObjectiveInformations
    {
        public const short ID = 385;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short ObjectiveId { get; set; }
        public bool ObjectiveStatus { get; set; }
        public string[] DialogParams { get; set; }


        public QuestObjectiveInformations()
        {
        }

        public QuestObjectiveInformations(short objectiveId, bool objectiveStatus, string[] dialogParams)
        {
            ObjectiveId = objectiveId;
            ObjectiveStatus = objectiveStatus;
            DialogParams = dialogParams;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ObjectiveId);
            writer.WriteBoolean(ObjectiveStatus);
            writer.WriteUShort((ushort) DialogParams.Length);
            foreach (var entry in DialogParams)
            {
                writer.WriteUTF(entry);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ObjectiveId = reader.ReadShort();
            ObjectiveStatus = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            DialogParams = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                DialogParams[i] = reader.ReadUTF();
            }
        }
    }
}