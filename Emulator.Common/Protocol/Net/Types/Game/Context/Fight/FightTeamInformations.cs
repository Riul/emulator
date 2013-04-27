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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public const short Id = 33;

        public FightTeamMemberInformations[] teamMembers;


        public FightTeamInformations()
        {
        }

        public FightTeamInformations(sbyte teamId, int leaderId, sbyte teamSide, sbyte teamTypeId, FightTeamMemberInformations[] teamMembers)
            : base(teamId, leaderId, teamSide, teamTypeId)
        {
            this.teamMembers = teamMembers;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) teamMembers.Length);
            foreach (var entry in teamMembers)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            teamMembers = new FightTeamMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                teamMembers[i] = Types.ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadShort());
                teamMembers[i].Deserialize(reader);
            }
        }
    }
}