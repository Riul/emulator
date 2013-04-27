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
// Created on 26/04/2013 at 16:45
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

        public override uint MessageId
        {
            get { return Id; }
        }


        public HouseToSellListMessage()
        {
        }

        public HouseToSellListMessage(short pageIndex, short totalPage, HouseInformationsForSell[] houseList)
        {
            this.pageIndex = pageIndex;
            this.totalPage = totalPage;
            this.houseList = houseList;
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