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
using Emulator.Common.Protocol.Net.Types.Game.Mount;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class UpdateMountBoostMessage : NetworkMessage
    {
        public const uint Id = 6179;

        public UpdateMountBoost[] boostToUpdateList;
        public double rideId;


        public UpdateMountBoostMessage()
        {
        }

        public UpdateMountBoostMessage(double rideId, UpdateMountBoost[] boostToUpdateList)
        {
            this.rideId = rideId;
            this.boostToUpdateList = boostToUpdateList;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(rideId);
            writer.WriteUShort((ushort) boostToUpdateList.Length);
            foreach (var entry in boostToUpdateList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            rideId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            boostToUpdateList = new UpdateMountBoost[limit];
            for (int i = 0; i < limit; i++)
            {
                boostToUpdateList[i] = Types.ProtocolTypeManager.GetInstance<UpdateMountBoost>(reader.ReadShort());
                boostToUpdateList[i].Deserialize(reader);
            }
        }
    }
}