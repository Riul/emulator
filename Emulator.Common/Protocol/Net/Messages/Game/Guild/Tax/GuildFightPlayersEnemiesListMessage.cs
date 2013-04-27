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

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersEnemiesListMessage : NetworkMessage
    {
        public const uint Id = 5928;

        public double fightId;
        public CharacterMinimalPlusLookInformations[] playerInfo;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildFightPlayersEnemiesListMessage()
        {
        }

        public GuildFightPlayersEnemiesListMessage(double fightId, CharacterMinimalPlusLookInformations[] playerInfo)
        {
            this.fightId = fightId;
            this.playerInfo = playerInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort) playerInfo.Length);
            foreach (var entry in playerInfo)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadUShort();
            playerInfo = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                playerInfo[i] = new CharacterMinimalPlusLookInformations();
                playerInfo[i].Deserialize(reader);
            }
        }
    }
}