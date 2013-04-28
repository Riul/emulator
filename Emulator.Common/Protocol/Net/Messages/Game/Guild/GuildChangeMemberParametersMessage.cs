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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildChangeMemberParametersMessage : NetworkMessage
    {
        public const uint ID = 5549;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int MemberId { get; set; }
        public short Rank { get; set; }
        public sbyte ExperienceGivenPercent { get; set; }
        public uint Rights { get; set; }


        public GuildChangeMemberParametersMessage()
        {
        }

        public GuildChangeMemberParametersMessage(int memberId, short rank, sbyte experienceGivenPercent, uint rights)
        {
            MemberId = memberId;
            Rank = rank;
            ExperienceGivenPercent = experienceGivenPercent;
            Rights = rights;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(MemberId);
            writer.WriteShort(Rank);
            writer.WriteSByte(ExperienceGivenPercent);
            writer.WriteUInt(Rights);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            MemberId = reader.ReadInt();
            Rank = reader.ReadShort();
            ExperienceGivenPercent = reader.ReadSByte();
            Rights = reader.ReadUInt();
        }
    }
}