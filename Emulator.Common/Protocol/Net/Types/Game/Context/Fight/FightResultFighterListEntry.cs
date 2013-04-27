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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultFighterListEntry : FightResultListEntry
    {
        public const short Id = 189;

        public bool alive;
        public int id;


        public FightResultFighterListEntry()
        {
        }

        public FightResultFighterListEntry(short outcome, FightLoot rewards, int id, bool alive)
            : base(outcome, rewards)
        {
            this.id = id;
            this.alive = alive;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(id);
            writer.WriteBoolean(alive);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            id = reader.ReadInt();
            alive = reader.ReadBoolean();
        }
    }
}