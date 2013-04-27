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

namespace Emulator.Common.Protocol.Net.Types.Game.Achievement
{
    public class Achievement
    {
        public const short Id = 363;

        public AchievementObjective[] finishedObjective;
        public short id;
        public AchievementStartedObjective[] startedObjectives;


        public Achievement()
        {
        }

        public Achievement(short id, AchievementObjective[] finishedObjective, AchievementStartedObjective[] startedObjectives)
        {
            this.id = id;
            this.finishedObjective = finishedObjective;
            this.startedObjectives = startedObjectives;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(id);
            writer.WriteUShort((ushort) finishedObjective.Length);
            foreach (var entry in finishedObjective)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) startedObjectives.Length);
            foreach (var entry in startedObjectives)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            id = reader.ReadShort();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            var limit = reader.ReadUShort();
            finishedObjective = new AchievementObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedObjective[i] = new AchievementObjective();
                finishedObjective[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            startedObjectives = new AchievementStartedObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                startedObjectives[i] = new AchievementStartedObjective();
                startedObjectives[i].Deserialize(reader);
            }
        }
    }
}