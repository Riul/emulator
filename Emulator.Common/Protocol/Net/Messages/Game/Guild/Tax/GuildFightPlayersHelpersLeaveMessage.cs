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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersHelpersLeaveMessage : NetworkMessage
    {
        public const uint Id = 5719;

        public double fightId;
        public int playerId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildFightPlayersHelpersLeaveMessage()
        {
        }

        public GuildFightPlayersHelpersLeaveMessage(double fightId, int playerId)
        {
            this.fightId = fightId;
            this.playerId = playerId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteInt(playerId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
        }
    }
}