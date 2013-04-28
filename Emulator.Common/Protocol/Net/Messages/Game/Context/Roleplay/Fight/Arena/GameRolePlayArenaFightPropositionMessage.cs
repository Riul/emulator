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
    public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
    {
        public const uint ID = 6276;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int FightId { get; set; }
        public int[] AlliesId { get; set; }
        public short Duration { get; set; }


        public GameRolePlayArenaFightPropositionMessage()
        {
        }

        public GameRolePlayArenaFightPropositionMessage(int fightId, int[] alliesId, short duration)
        {
            FightId = fightId;
            AlliesId = alliesId;
            Duration = duration;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteUShort((ushort) AlliesId.Length);
            foreach (var entry in AlliesId)
            {
                writer.WriteInt(entry);
            }
            writer.WriteShort(Duration);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadInt();
            var limit = reader.ReadUShort();
            AlliesId = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                AlliesId[i] = reader.ReadInt();
            }
            Duration = reader.ReadShort();
        }
    }
}