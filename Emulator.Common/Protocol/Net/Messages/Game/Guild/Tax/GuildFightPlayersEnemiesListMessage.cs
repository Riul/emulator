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
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersEnemiesListMessage : NetworkMessage
    {
        public const uint ID = 5928;

        public override uint MessageId
        {
            get { return ID; }
        }

        public double FightId { get; set; }
        public CharacterMinimalPlusLookInformations[] PlayerInfo { get; set; }


        public GuildFightPlayersEnemiesListMessage()
        {
        }

        public GuildFightPlayersEnemiesListMessage(double fightId, CharacterMinimalPlusLookInformations[] playerInfo)
        {
            FightId = fightId;
            PlayerInfo = playerInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteUShort((ushort) PlayerInfo.Length);
            foreach (var entry in PlayerInfo)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            PlayerInfo = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                PlayerInfo[i] = new CharacterMinimalPlusLookInformations();
                PlayerInfo[i].Deserialize(reader);
            }
        }
    }
}