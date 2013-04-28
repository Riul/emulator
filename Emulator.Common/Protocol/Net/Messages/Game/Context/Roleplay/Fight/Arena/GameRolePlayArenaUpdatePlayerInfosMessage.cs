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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
    {
        public const uint ID = 6301;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short Rank { get; set; }
        public short BestDailyRank { get; set; }
        public short BestRank { get; set; }
        public short VictoryCount { get; set; }
        public short ArenaFightcount { get; set; }


        public GameRolePlayArenaUpdatePlayerInfosMessage()
        {
        }

        public GameRolePlayArenaUpdatePlayerInfosMessage(short rank, short bestDailyRank, short bestRank, short victoryCount, short arenaFightcount)
        {
            Rank = rank;
            BestDailyRank = bestDailyRank;
            BestRank = bestRank;
            VictoryCount = victoryCount;
            ArenaFightcount = arenaFightcount;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(Rank);
            writer.WriteShort(BestDailyRank);
            writer.WriteShort(BestRank);
            writer.WriteShort(VictoryCount);
            writer.WriteShort(ArenaFightcount);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Rank = reader.ReadShort();
            BestDailyRank = reader.ReadShort();
            BestRank = reader.ReadShort();
            VictoryCount = reader.ReadShort();
            ArenaFightcount = reader.ReadShort();
        }
    }
}