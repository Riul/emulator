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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
    {
        public const uint Id = 6276;

        public int[] alliesId;
        public short duration;
        public int fightId;


        public GameRolePlayArenaFightPropositionMessage()
        {
        }

        public GameRolePlayArenaFightPropositionMessage(int fightId, int[] alliesId, short duration)
        {
            this.fightId = fightId;
            this.alliesId = alliesId;
            this.duration = duration;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteUShort((ushort) alliesId.Length);
            foreach (var entry in alliesId)
            {
                writer.WriteInt(entry);
            }
            writer.WriteShort(duration);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadUShort();
            alliesId = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                alliesId[i] = reader.ReadInt();
            }
            duration = reader.ReadShort();
            if (duration < 0)
                throw new Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0");
        }
    }
}