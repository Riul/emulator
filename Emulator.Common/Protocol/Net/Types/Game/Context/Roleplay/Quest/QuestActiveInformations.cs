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
    public class QuestActiveInformations
    {
        public const short ID = 381;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short QuestId { get; set; }


        public QuestActiveInformations()
        {
        }

        public QuestActiveInformations(short questId)
        {
            QuestId = questId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(QuestId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            QuestId = reader.ReadShort();
        }
    }
}