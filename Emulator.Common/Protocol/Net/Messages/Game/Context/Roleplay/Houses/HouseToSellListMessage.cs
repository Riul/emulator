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
using Emulator.Common.Protocol.Net.Types.Game.House;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Houses
{
    public class HouseToSellListMessage : NetworkMessage
    {
        public const uint Id = 6140;
        public HouseInformationsForSell[] houseList;

        public short pageIndex;
        public short totalPage;


        public HouseToSellListMessage()
        {
        }

        public HouseToSellListMessage(short pageIndex, short totalPage, HouseInformationsForSell[] houseList)
        {
            this.pageIndex = pageIndex;
            this.totalPage = totalPage;
            this.houseList = houseList;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(pageIndex);
            writer.WriteShort(totalPage);
            writer.WriteUShort((ushort) houseList.Length);
            foreach (var entry in houseList)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            pageIndex = reader.ReadShort();
            if (pageIndex < 0)
                throw new Exception("Forbidden value on pageIndex = " + pageIndex + ", it doesn't respect the following condition : pageIndex < 0");
            totalPage = reader.ReadShort();
            if (totalPage < 0)
                throw new Exception("Forbidden value on totalPage = " + totalPage + ", it doesn't respect the following condition : totalPage < 0");
            var limit = reader.ReadUShort();
            houseList = new HouseInformationsForSell[limit];
            for (int i = 0; i < limit; i++)
            {
                houseList[i] = new HouseInformationsForSell();
                houseList[i].Deserialize(reader);
            }
        }
    }
}