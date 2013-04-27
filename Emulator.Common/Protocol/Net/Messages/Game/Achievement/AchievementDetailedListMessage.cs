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
//     Created on 26/04/2013 at 16:45
// */
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Achievement
{
    public class AchievementDetailedListMessage : NetworkMessage
    {
        public const uint Id = 6358;

        public Types.Game.Achievement.Achievement[] finishedAchievements;
        public Types.Game.Achievement.Achievement[] startedAchievements;


        public AchievementDetailedListMessage()
        {
        }

        public AchievementDetailedListMessage(Types.Game.Achievement.Achievement[] startedAchievements, Types.Game.Achievement.Achievement[] finishedAchievements)
        {
            this.startedAchievements = startedAchievements;
            this.finishedAchievements = finishedAchievements;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) startedAchievements.Length);
            foreach (var entry in startedAchievements)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) finishedAchievements.Length);
            foreach (var entry in finishedAchievements)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            startedAchievements = new Types.Game.Achievement.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                startedAchievements[i] = new Types.Game.Achievement.Achievement();
                startedAchievements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            finishedAchievements = new Types.Game.Achievement.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedAchievements[i] = new Types.Game.Achievement.Achievement();
                finishedAchievements[i].Deserialize(reader);
            }
        }
    }
}