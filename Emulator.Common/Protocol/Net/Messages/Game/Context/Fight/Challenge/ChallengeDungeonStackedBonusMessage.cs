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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeDungeonStackedBonusMessage : NetworkMessage
    {
        public const uint Id = 6151;
        public int dropBonus;

        public int dungeonId;
        public int xpBonus;


        public ChallengeDungeonStackedBonusMessage()
        {
        }

        public ChallengeDungeonStackedBonusMessage(int dungeonId, int xpBonus, int dropBonus)
        {
            this.dungeonId = dungeonId;
            this.xpBonus = xpBonus;
            this.dropBonus = dropBonus;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(dungeonId);
            writer.WriteInt(xpBonus);
            writer.WriteInt(dropBonus);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            dungeonId = reader.ReadInt();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            xpBonus = reader.ReadInt();
            if (xpBonus < 0)
                throw new Exception("Forbidden value on xpBonus = " + xpBonus + ", it doesn't respect the following condition : xpBonus < 0");
            dropBonus = reader.ReadInt();
            if (dropBonus < 0)
                throw new Exception("Forbidden value on dropBonus = " + dropBonus + ", it doesn't respect the following condition : dropBonus < 0");
        }
    }
}