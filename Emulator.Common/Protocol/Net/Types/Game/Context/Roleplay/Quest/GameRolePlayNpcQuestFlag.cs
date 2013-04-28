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
    public class GameRolePlayNpcQuestFlag
    {
        public const short ID = 384;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short[] QuestsToValidId { get; set; }
        public short[] QuestsToStartId { get; set; }


        public GameRolePlayNpcQuestFlag()
        {
        }

        public GameRolePlayNpcQuestFlag(short[] questsToValidId, short[] questsToStartId)
        {
            QuestsToValidId = questsToValidId;
            QuestsToStartId = questsToStartId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) QuestsToValidId.Length);
            foreach (var entry in QuestsToValidId)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) QuestsToStartId.Length);
            foreach (var entry in QuestsToStartId)
            {
                writer.WriteShort(entry);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            QuestsToValidId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                QuestsToValidId[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            QuestsToStartId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                QuestsToStartId[i] = reader.ReadShort();
            }
        }
    }
}