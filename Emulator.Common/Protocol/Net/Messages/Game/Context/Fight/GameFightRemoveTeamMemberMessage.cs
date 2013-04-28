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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightRemoveTeamMemberMessage : NetworkMessage
    {
        public const uint ID = 711;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short FightId { get; set; }
        public sbyte TeamId { get; set; }
        public int CharId { get; set; }


        public GameFightRemoveTeamMemberMessage()
        {
        }

        public GameFightRemoveTeamMemberMessage(short fightId, sbyte teamId, int charId)
        {
            FightId = fightId;
            TeamId = teamId;
            CharId = charId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(FightId);
            writer.WriteSByte(TeamId);
            writer.WriteInt(CharId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadShort();
            TeamId = reader.ReadSByte();
            CharId = reader.ReadInt();
        }
    }
}