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
    public class GameFightOptionStateUpdateMessage : NetworkMessage
    {
        public const uint ID = 5927;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short FightId { get; set; }
        public sbyte TeamId { get; set; }
        public sbyte Option { get; set; }
        public bool State { get; set; }


        public GameFightOptionStateUpdateMessage()
        {
        }

        public GameFightOptionStateUpdateMessage(short fightId, sbyte teamId, sbyte option, bool state)
        {
            FightId = fightId;
            TeamId = teamId;
            Option = option;
            State = state;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(FightId);
            writer.WriteSByte(TeamId);
            writer.WriteSByte(Option);
            writer.WriteBoolean(State);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadShort();
            TeamId = reader.ReadSByte();
            Option = reader.ReadSByte();
            State = reader.ReadBoolean();
        }
    }
}