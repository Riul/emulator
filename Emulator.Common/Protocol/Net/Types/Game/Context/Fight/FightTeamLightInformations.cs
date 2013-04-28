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
    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public const short ID = 115;

        public override short TypeId
        {
            get { return ID; }
        }

        public bool HasFriend { get; set; }
        public bool HasGuildMember { get; set; }
        public bool HasGroupMember { get; set; }
        public bool HasMyTaxCollector { get; set; }
        public sbyte TeamMembersCount { get; set; }
        public int MeanLevel { get; set; }


        public FightTeamLightInformations()
        {
        }

        public FightTeamLightInformations(sbyte teamId, int leaderId, sbyte teamSide, sbyte teamTypeId, bool hasFriend, bool hasGuildMember, bool hasGroupMember, bool hasMyTaxCollector, sbyte teamMembersCount, int meanLevel)
                : base(teamId, leaderId, teamSide, teamTypeId)
        {
            HasFriend = hasFriend;
            HasGuildMember = hasGuildMember;
            HasGroupMember = hasGroupMember;
            HasMyTaxCollector = hasMyTaxCollector;
            TeamMembersCount = teamMembersCount;
            MeanLevel = meanLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, HasFriend);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, HasGuildMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, HasGroupMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, HasMyTaxCollector);
            writer.WriteByte(flag1);
            writer.WriteSByte(TeamMembersCount);
            writer.WriteInt(MeanLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            HasFriend = BooleanByteWrapper.GetFlag(flag1, 0);
            HasGuildMember = BooleanByteWrapper.GetFlag(flag1, 1);
            HasGroupMember = BooleanByteWrapper.GetFlag(flag1, 2);
            HasMyTaxCollector = BooleanByteWrapper.GetFlag(flag1, 3);
            TeamMembersCount = reader.ReadSByte();
            MeanLevel = reader.ReadInt();
        }
    }
}