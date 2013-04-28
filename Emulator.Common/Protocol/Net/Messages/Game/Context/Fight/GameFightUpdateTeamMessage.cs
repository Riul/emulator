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
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightUpdateTeamMessage : NetworkMessage
    {
        public const uint ID = 5572;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short FightId { get; set; }
        public FightTeamInformations Team { get; set; }


        public GameFightUpdateTeamMessage()
        {
        }

        public GameFightUpdateTeamMessage(short fightId, FightTeamInformations team)
        {
            FightId = fightId;
            Team = team;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(FightId);
            Team.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadShort();
            Team = new FightTeamInformations();
            Team.Deserialize(reader);
        }
    }
}