#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:46
// */
#endregion

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;

namespace Emulator.Common.Protocol.Net.Types.Game.Friend
{
    public class FriendOnlineInformations : FriendInformations
    {
        public const short Id = 92;

        public sbyte alignmentSide;
        public sbyte breed;
        public BasicGuildInformations guildInfo;
        public short level;
        public sbyte moodSmileyId;
        public string playerName;
        public bool sex;


        public FriendOnlineInformations()
        {
        }

        public FriendOnlineInformations(int accountId, string accountName, sbyte playerState, int lastConnection, int achievementPoints, string playerName, short level, sbyte alignmentSide, sbyte breed, bool sex, BasicGuildInformations guildInfo, sbyte moodSmileyId)
            : base(accountId, accountName, playerState, lastConnection, achievementPoints)
        {
            this.playerName = playerName;
            this.level = level;
            this.alignmentSide = alignmentSide;
            this.breed = breed;
            this.sex = sex;
            this.guildInfo = guildInfo;
            this.moodSmileyId = moodSmileyId;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(playerName);
            writer.WriteShort(level);
            writer.WriteSByte(alignmentSide);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            guildInfo.Serialize(writer);
            writer.WriteSByte(moodSmileyId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            playerName = reader.ReadUTF();
            level = reader.ReadShort();
            if (level < 0 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 200");
            alignmentSide = reader.ReadSByte();
            breed = reader.ReadSByte();
            if (breed < (byte) Enums.PlayableBreedEnum.Feca || breed > (byte) Enums.PlayableBreedEnum.Steamer)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Steamer");
            sex = reader.ReadBoolean();
            guildInfo = new BasicGuildInformations();
            guildInfo.Deserialize(reader);
            moodSmileyId = reader.ReadSByte();
        }
    }
}