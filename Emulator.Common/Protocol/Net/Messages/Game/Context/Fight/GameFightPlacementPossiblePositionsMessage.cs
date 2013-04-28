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
    public class GameFightPlacementPossiblePositionsMessage : NetworkMessage
    {
        public const uint ID = 703;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] PositionsForChallengers { get; set; }
        public short[] PositionsForDefenders { get; set; }
        public sbyte TeamNumber { get; set; }


        public GameFightPlacementPossiblePositionsMessage()
        {
        }

        public GameFightPlacementPossiblePositionsMessage(short[] positionsForChallengers, short[] positionsForDefenders, sbyte teamNumber)
        {
            PositionsForChallengers = positionsForChallengers;
            PositionsForDefenders = positionsForDefenders;
            TeamNumber = teamNumber;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) PositionsForChallengers.Length);
            foreach (var entry in PositionsForChallengers)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) PositionsForDefenders.Length);
            foreach (var entry in PositionsForDefenders)
            {
                writer.WriteShort(entry);
            }
            writer.WriteSByte(TeamNumber);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            PositionsForChallengers = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                PositionsForChallengers[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            PositionsForDefenders = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                PositionsForDefenders[i] = reader.ReadShort();
            }
            TeamNumber = reader.ReadSByte();
        }
    }
}