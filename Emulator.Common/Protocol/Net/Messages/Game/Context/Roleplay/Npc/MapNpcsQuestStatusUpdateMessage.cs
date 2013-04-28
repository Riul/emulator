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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const uint ID = 5642;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int MapId { get; set; }
        public int[] NpcsIdsWithQuest { get; set; }
        public GameRolePlayNpcQuestFlag[] QuestFlags { get; set; }
        public int[] NpcsIdsWithoutQuest { get; set; }


        public MapNpcsQuestStatusUpdateMessage()
        {
        }

        public MapNpcsQuestStatusUpdateMessage(int mapId, int[] npcsIdsWithQuest, GameRolePlayNpcQuestFlag[] questFlags, int[] npcsIdsWithoutQuest)
        {
            MapId = mapId;
            NpcsIdsWithQuest = npcsIdsWithQuest;
            QuestFlags = questFlags;
            NpcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(MapId);
            writer.WriteUShort((ushort) NpcsIdsWithQuest.Length);
            foreach (var entry in NpcsIdsWithQuest)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) QuestFlags.Length);
            foreach (var entry in QuestFlags)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) NpcsIdsWithoutQuest.Length);
            foreach (var entry in NpcsIdsWithoutQuest)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            MapId = reader.ReadInt();
            var limit = reader.ReadUShort();
            NpcsIdsWithQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                NpcsIdsWithQuest[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            QuestFlags = new GameRolePlayNpcQuestFlag[limit];
            for (int i = 0; i < limit; i++)
            {
                QuestFlags[i] = new GameRolePlayNpcQuestFlag();
                QuestFlags[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            NpcsIdsWithoutQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                NpcsIdsWithoutQuest[i] = reader.ReadInt();
            }
        }
    }
}