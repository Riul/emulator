#region License

//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.House;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Houses
{
    public class HouseToSellListMessage : NetworkMessage
    {
        public const uint ID = 6140;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short PageIndex { get; set; }
        public short TotalPage { get; set; }
        public HouseInformationsForSell[] HouseList { get; set; }


        public HouseToSellListMessage()
        {
        }

        public HouseToSellListMessage(short pageIndex, short totalPage, HouseInformationsForSell[] houseList)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            HouseList = houseList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(PageIndex);
            writer.WriteShort(TotalPage);
            writer.WriteUShort((ushort) HouseList.Length);
            foreach (var entry in HouseList)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PageIndex = reader.ReadShort();
            TotalPage = reader.ReadShort();
            var limit = reader.ReadUShort();
            HouseList = new HouseInformationsForSell[limit];
            for (int i = 0; i < limit; i++)
            {
                HouseList[i] = new HouseInformationsForSell();
                HouseList[i].Deserialize(reader);
            }
        }
    }
}