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
using Emulator.Common.Protocol.Net.Types.Game.Paddock;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockToSellListMessage : NetworkMessage
    {
        public const uint ID = 6138;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short PageIndex { get; set; }
        public short TotalPage { get; set; }
        public PaddockInformationsForSell[] PaddockList { get; set; }


        public PaddockToSellListMessage()
        {
        }

        public PaddockToSellListMessage(short pageIndex, short totalPage, PaddockInformationsForSell[] paddockList)
        {
            PageIndex = pageIndex;
            TotalPage = totalPage;
            PaddockList = paddockList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(PageIndex);
            writer.WriteShort(TotalPage);
            writer.WriteUShort((ushort) PaddockList.Length);
            foreach (var entry in PaddockList)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PageIndex = reader.ReadShort();
            TotalPage = reader.ReadShort();
            var limit = reader.ReadUShort();
            PaddockList = new PaddockInformationsForSell[limit];
            for (int i = 0; i < limit; i++)
            {
                PaddockList[i] = new PaddockInformationsForSell();
                PaddockList[i].Deserialize(reader);
            }
        }
    }
}