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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public const short Id = 84;

        public int experienceForGuild;
        public BasicGuildInformations guildInfo;
        public byte level;


        public FightResultTaxCollectorListEntry()
        {
        }

        public FightResultTaxCollectorListEntry(short outcome, FightLoot rewards, int id, bool alive, byte level, BasicGuildInformations guildInfo, int experienceForGuild)
            : base(outcome, rewards, id, alive)
        {
            this.level = level;
            this.guildInfo = guildInfo;
            this.experienceForGuild = experienceForGuild;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(level);
            guildInfo.Serialize(writer);
            writer.WriteInt(experienceForGuild);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
            guildInfo = new BasicGuildInformations();
            guildInfo.Deserialize(reader);
            experienceForGuild = reader.ReadInt();
        }
    }
}