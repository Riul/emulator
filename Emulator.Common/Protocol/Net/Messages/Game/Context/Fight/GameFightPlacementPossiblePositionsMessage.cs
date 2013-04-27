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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightPlacementPossiblePositionsMessage : NetworkMessage
    {
        public const uint Id = 703;

        public short[] positionsForChallengers;
        public short[] positionsForDefenders;
        public sbyte teamNumber;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameFightPlacementPossiblePositionsMessage()
        {
        }

        public GameFightPlacementPossiblePositionsMessage(short[] positionsForChallengers, short[] positionsForDefenders, sbyte teamNumber)
        {
            this.positionsForChallengers = positionsForChallengers;
            this.positionsForDefenders = positionsForDefenders;
            this.teamNumber = teamNumber;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) positionsForChallengers.Length);
            foreach (var entry in positionsForChallengers)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) positionsForDefenders.Length);
            foreach (var entry in positionsForDefenders)
            {
                writer.WriteShort(entry);
            }
            writer.WriteSByte(teamNumber);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            positionsForChallengers = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                positionsForChallengers[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            positionsForDefenders = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                positionsForDefenders[i] = reader.ReadShort();
            }
            teamNumber = reader.ReadSByte();
            if (teamNumber < 0)
                throw new Exception("Forbidden value on teamNumber = " + teamNumber + ", it doesn't respect the following condition : teamNumber < 0");
        }
    }
}