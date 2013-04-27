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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const uint Id = 5642;

        public int mapId;
        public int[] npcsIdsWithQuest;
        public int[] npcsIdsWithoutQuest;
        public GameRolePlayNpcQuestFlag[] questFlags;

        public override uint MessageId
        {
            get { return Id; }
        }


        public MapNpcsQuestStatusUpdateMessage()
        {
        }

        public MapNpcsQuestStatusUpdateMessage(int mapId, int[] npcsIdsWithQuest, GameRolePlayNpcQuestFlag[] questFlags, int[] npcsIdsWithoutQuest)
        {
            this.mapId = mapId;
            this.npcsIdsWithQuest = npcsIdsWithQuest;
            this.questFlags = questFlags;
            this.npcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(mapId);
            writer.WriteUShort((ushort) npcsIdsWithQuest.Length);
            foreach (var entry in npcsIdsWithQuest)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) questFlags.Length);
            foreach (var entry in questFlags)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) npcsIdsWithoutQuest.Length);
            foreach (var entry in npcsIdsWithoutQuest)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            mapId = reader.ReadInt();
            var limit = reader.ReadUShort();
            npcsIdsWithQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                npcsIdsWithQuest[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            questFlags = new GameRolePlayNpcQuestFlag[limit];
            for (int i = 0; i < limit; i++)
            {
                questFlags[i] = new GameRolePlayNpcQuestFlag();
                questFlags[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            npcsIdsWithoutQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                npcsIdsWithoutQuest[i] = reader.ReadInt();
            }
        }
    }
}