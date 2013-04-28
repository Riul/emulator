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
    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public const short ID = 33;

        public override short TypeId
        {
            get { return ID; }
        }

        public FightTeamMemberInformations[] TeamMembers { get; set; }


        public FightTeamInformations()
        {
        }

        public FightTeamInformations(sbyte teamId, int leaderId, sbyte teamSide, sbyte teamTypeId, FightTeamMemberInformations[] teamMembers)
                : base(teamId, leaderId, teamSide, teamTypeId)
        {
            TeamMembers = teamMembers;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) TeamMembers.Length);
            foreach (var entry in TeamMembers)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            TeamMembers = new FightTeamMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                TeamMembers[i] = Types.ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadShort());
                TeamMembers[i].Deserialize(reader);
            }
        }
    }
}