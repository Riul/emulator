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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightCommonInformations
    {
        public const short ID = 43;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int FightId { get; set; }
        public sbyte FightType { get; set; }
        public FightTeamInformations[] FightTeams { get; set; }
        public short[] FightTeamsPositions { get; set; }
        public FightOptionsInformations[] FightTeamsOptions { get; set; }


        public FightCommonInformations()
        {
        }

        public FightCommonInformations(int fightId, sbyte fightType, FightTeamInformations[] fightTeams, short[] fightTeamsPositions, FightOptionsInformations[] fightTeamsOptions)
        {
            FightId = fightId;
            FightType = fightType;
            FightTeams = fightTeams;
            FightTeamsPositions = fightTeamsPositions;
            FightTeamsOptions = fightTeamsOptions;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteSByte(FightType);
            writer.WriteUShort((ushort) FightTeams.Length);
            foreach (var entry in FightTeams)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) FightTeamsPositions.Length);
            foreach (var entry in FightTeamsPositions)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) FightTeamsOptions.Length);
            foreach (var entry in FightTeamsOptions)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadInt();
            FightType = reader.ReadSByte();
            var limit = reader.ReadUShort();
            FightTeams = new FightTeamInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                FightTeams[i] = new FightTeamInformations();
                FightTeams[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            FightTeamsPositions = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                FightTeamsPositions[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            FightTeamsOptions = new FightOptionsInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                FightTeamsOptions[i] = new FightOptionsInformations();
                FightTeamsOptions[i].Deserialize(reader);
            }
        }
    }
}