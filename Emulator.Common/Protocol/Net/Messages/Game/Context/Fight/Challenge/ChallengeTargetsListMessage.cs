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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeTargetsListMessage : NetworkMessage
    {
        public const uint ID = 5613;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int[] TargetIds { get; set; }
        public short[] TargetCells { get; set; }


        public ChallengeTargetsListMessage()
        {
        }

        public ChallengeTargetsListMessage(int[] targetIds, short[] targetCells)
        {
            TargetIds = targetIds;
            TargetCells = targetCells;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) TargetIds.Length);
            foreach (var entry in TargetIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) TargetCells.Length);
            foreach (var entry in TargetCells)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            TargetIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                TargetIds[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            TargetCells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                TargetCells[i] = reader.ReadShort();
            }
        }
    }
}