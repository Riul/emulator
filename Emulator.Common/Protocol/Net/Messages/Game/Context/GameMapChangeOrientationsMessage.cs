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
using Emulator.Common.Protocol.Net.Types.Game.Context;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context
{
    public class GameMapChangeOrientationsMessage : NetworkMessage
    {
        public const uint Id = 6155;

        public ActorOrientation[] orientations;


        public GameMapChangeOrientationsMessage()
        {
        }

        public GameMapChangeOrientationsMessage(ActorOrientation[] orientations)
        {
            this.orientations = orientations;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) orientations.Length);
            foreach (var entry in orientations)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            orientations = new ActorOrientation[limit];
            for (int i = 0; i < limit; i++)
            {
                orientations[i] = new ActorOrientation();
                orientations[i].Deserialize(reader);
            }
        }
    }
}