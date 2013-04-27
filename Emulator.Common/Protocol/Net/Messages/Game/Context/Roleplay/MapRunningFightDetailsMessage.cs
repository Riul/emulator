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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        public const uint Id = 5751;
        public bool[] alives;

        public int fightId;
        public short[] levels;
        public string[] names;
        public sbyte teamSwap;


        public MapRunningFightDetailsMessage()
        {
        }

        public MapRunningFightDetailsMessage(int fightId, string[] names, short[] levels, sbyte teamSwap, bool[] alives)
        {
            this.fightId = fightId;
            this.names = names;
            this.levels = levels;
            this.teamSwap = teamSwap;
            this.alives = alives;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteUShort((ushort) names.Length);
            foreach (var entry in names)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) levels.Length);
            foreach (var entry in levels)
            {
                writer.WriteShort(entry);
            }
            writer.WriteSByte(teamSwap);
            writer.WriteUShort((ushort) alives.Length);
            foreach (var entry in alives)
            {
                writer.WriteBoolean(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadUShort();
            names = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                names[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            levels = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                levels[i] = reader.ReadShort();
            }
            teamSwap = reader.ReadSByte();
            if (teamSwap < 0)
                throw new Exception("Forbidden value on teamSwap = " + teamSwap + ", it doesn't respect the following condition : teamSwap < 0");
            limit = reader.ReadUShort();
            alives = new bool[limit];
            for (int i = 0; i < limit; i++)
            {
                alives[i] = reader.ReadBoolean();
            }
        }
    }
}