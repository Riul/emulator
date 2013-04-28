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
    public class GameRolePlayArenaFighterStatusMessage : NetworkMessage
    {
        public const uint ID = 6281;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int FightId { get; set; }
        public int PlayerId { get; set; }
        public bool Accepted { get; set; }


        public GameRolePlayArenaFighterStatusMessage()
        {
        }

        public GameRolePlayArenaFighterStatusMessage(int fightId, int playerId, bool accepted)
        {
            FightId = fightId;
            PlayerId = playerId;
            Accepted = accepted;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteInt(PlayerId);
            writer.WriteBoolean(Accepted);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadInt();
            PlayerId = reader.ReadInt();
            Accepted = reader.ReadBoolean();
        }
    }
}