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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightTurnStartSlaveMessage : GameFightTurnStartMessage
    {
        public const uint Id = 6213;

        public int idSummoner;


        public GameFightTurnStartSlaveMessage()
        {
        }

        public GameFightTurnStartSlaveMessage(int id, int waitTime, int idSummoner)
            : base(id, waitTime)
        {
            this.idSummoner = idSummoner;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(idSummoner);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            idSummoner = reader.ReadInt();
        }
    }
}