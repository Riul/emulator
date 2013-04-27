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
    public class AbstractFightTeamInformations
    {
        public const short Id = 116;

        public int leaderId;
        public sbyte teamId;
        public sbyte teamSide;
        public sbyte teamTypeId;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public AbstractFightTeamInformations()
        {
        }

        public AbstractFightTeamInformations(sbyte teamId, int leaderId, sbyte teamSide, sbyte teamTypeId)
        {
            this.teamId = teamId;
            this.leaderId = leaderId;
            this.teamSide = teamSide;
            this.teamTypeId = teamTypeId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(teamId);
            writer.WriteInt(leaderId);
            writer.WriteSByte(teamSide);
            writer.WriteSByte(teamTypeId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            teamId = reader.ReadSByte();
            if (teamId < 0)
                throw new Exception("Forbidden value on teamId = " + teamId + ", it doesn't respect the following condition : teamId < 0");
            leaderId = reader.ReadInt();
            teamSide = reader.ReadSByte();
            teamTypeId = reader.ReadSByte();
            if (teamTypeId < 0)
                throw new Exception("Forbidden value on teamTypeId = " + teamTypeId + ", it doesn't respect the following condition : teamTypeId < 0");
        }
    }
}