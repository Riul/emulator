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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
    {
        public const uint Id = 6276;

        public int[] alliesId;
        public short duration;
        public int fightId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameRolePlayArenaFightPropositionMessage()
        {
        }

        public GameRolePlayArenaFightPropositionMessage(int fightId, int[] alliesId, short duration)
        {
            this.fightId = fightId;
            this.alliesId = alliesId;
            this.duration = duration;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteUShort((ushort) alliesId.Length);
            foreach (var entry in alliesId)
            {
                writer.WriteInt(entry);
            }
            writer.WriteShort(duration);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadUShort();
            alliesId = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                alliesId[i] = reader.ReadInt();
            }
            duration = reader.ReadShort();
            if (duration < 0)
                throw new Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0");
        }
    }
}