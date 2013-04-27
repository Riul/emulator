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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightExternalInformations
    {
        public const short Id = 117;

        public int fightId;
        public bool fightSpectatorLocked;
        public int fightStart;
        public FightTeamLightInformations[] fightTeams;
        public FightOptionsInformations[] fightTeamsOptions;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public FightExternalInformations()
        {
        }

        public FightExternalInformations(int fightId, int fightStart, bool fightSpectatorLocked, FightTeamLightInformations[] fightTeams, FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightStart = fightStart;
            this.fightSpectatorLocked = fightSpectatorLocked;
            this.fightTeams = fightTeams;
            this.fightTeamsOptions = fightTeamsOptions;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteInt(fightStart);
            writer.WriteBoolean(fightSpectatorLocked);
            foreach (var entry in fightTeams)
            {
                entry.Serialize(writer);
            }
            foreach (var entry in fightTeamsOptions)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadInt();
            fightStart = reader.ReadInt();
            if (fightStart < 0)
                throw new Exception("Forbidden value on fightStart = " + fightStart + ", it doesn't respect the following condition : fightStart < 0");
            fightSpectatorLocked = reader.ReadBoolean();
            fightTeams = new FightTeamLightInformations[2];
            for (int i = 0; i < 2; i++)
            {
                fightTeams[i] = new FightTeamLightInformations();
                fightTeams[i].Deserialize(reader);
            }
            fightTeamsOptions = new FightOptionsInformations[2];
            for (int i = 0; i < 2; i++)
            {
                fightTeamsOptions[i] = new FightOptionsInformations();
                fightTeamsOptions[i].Deserialize(reader);
            }
        }
    }
}