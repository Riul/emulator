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
    public class FightExternalInformations
    {
        public const short ID = 117;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int FightId { get; set; }
        public sbyte FightType { get; set; }
        public int FightStart { get; set; }
        public bool FightSpectatorLocked { get; set; }
        public FightTeamLightInformations[] FightTeams { get; set; }
        public FightOptionsInformations[] FightTeamsOptions { get; set; }


        public FightExternalInformations()
        {
        }

        public FightExternalInformations(int fightId, sbyte fightType, int fightStart, bool fightSpectatorLocked, FightTeamLightInformations[] fightTeams, FightOptionsInformations[] fightTeamsOptions)
        {
            FightId = fightId;
            FightType = fightType;
            FightStart = fightStart;
            FightSpectatorLocked = fightSpectatorLocked;
            FightTeams = fightTeams;
            FightTeamsOptions = fightTeamsOptions;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteSByte(FightType);
            writer.WriteInt(FightStart);
            writer.WriteBoolean(FightSpectatorLocked);
            writer.WriteUShort((ushort) FightTeams.Length);
            foreach (var entry in FightTeams)
            {
                entry.Serialize(writer);
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
            FightStart = reader.ReadInt();
            FightSpectatorLocked = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            FightTeams = new FightTeamLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                FightTeams[i] = new FightTeamLightInformations();
                FightTeams[i].Deserialize(reader);
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