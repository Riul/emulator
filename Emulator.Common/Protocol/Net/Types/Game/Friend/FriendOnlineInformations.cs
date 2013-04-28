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
using Emulator.Common.Protocol.Net.Types.Game.Character.Status;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;

namespace Emulator.Common.Protocol.Net.Types.Game.Friend
{
    public class FriendOnlineInformations : FriendInformations
    {
        public const short ID = 92;

        public override short TypeId
        {
            get { return ID; }
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public short Level { get; set; }
        public sbyte AlignmentSide { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }
        public sbyte MoodSmileyId { get; set; }
        public PlayerStatus Status { get; set; }


        public FriendOnlineInformations()
        {
        }

        public FriendOnlineInformations(int accountId, string accountName, sbyte playerState, int lastConnection, int achievementPoints, int playerId, string playerName, short level, sbyte alignmentSide, sbyte breed, bool sex, BasicGuildInformations guildInfo, sbyte moodSmileyId, PlayerStatus status)
                : base(accountId, accountName, playerState, lastConnection, achievementPoints)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Level = level;
            AlignmentSide = alignmentSide;
            Breed = breed;
            Sex = sex;
            GuildInfo = guildInfo;
            MoodSmileyId = moodSmileyId;
            Status = status;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteShort(Level);
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            GuildInfo.Serialize(writer);
            writer.WriteSByte(MoodSmileyId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            Level = reader.ReadShort();
            AlignmentSide = reader.ReadSByte();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
            MoodSmileyId = reader.ReadSByte();
            Status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
        }
    }
}