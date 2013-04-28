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
    public class AbstractFightTeamInformations
    {
        public const short ID = 116;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte TeamId { get; set; }
        public int LeaderId { get; set; }
        public sbyte TeamSide { get; set; }
        public sbyte TeamTypeId { get; set; }


        public AbstractFightTeamInformations()
        {
        }

        public AbstractFightTeamInformations(sbyte teamId, int leaderId, sbyte teamSide, sbyte teamTypeId)
        {
            TeamId = teamId;
            LeaderId = leaderId;
            TeamSide = teamSide;
            TeamTypeId = teamTypeId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(TeamId);
            writer.WriteInt(LeaderId);
            writer.WriteSByte(TeamSide);
            writer.WriteSByte(TeamTypeId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            TeamId = reader.ReadSByte();
            LeaderId = reader.ReadInt();
            TeamSide = reader.ReadSByte();
            TeamTypeId = reader.ReadSByte();
        }
    }
}