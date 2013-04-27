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
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightUpdateTeamMessage : NetworkMessage
    {
        public const uint Id = 5572;

        public short fightId;
        public FightTeamInformations team;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameFightUpdateTeamMessage()
        {
        }

        public GameFightUpdateTeamMessage(short fightId, FightTeamInformations team)
        {
            this.fightId = fightId;
            this.team = team;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(fightId);
            team.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadShort();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            team = new FightTeamInformations();
            team.Deserialize(reader);
        }
    }
}