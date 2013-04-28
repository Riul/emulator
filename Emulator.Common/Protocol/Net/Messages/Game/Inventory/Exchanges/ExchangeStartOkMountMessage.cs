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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Mount;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
    {
        public const uint ID = 5979;

        public override uint MessageId
        {
            get { return ID; }
        }

        public MountClientData[] PaddockedMountsDescription { get; set; }


        public ExchangeStartOkMountMessage()
        {
        }

        public ExchangeStartOkMountMessage(MountClientData[] stabledMountsDescription, MountClientData[] paddockedMountsDescription)
                : base(stabledMountsDescription)
        {
            PaddockedMountsDescription = paddockedMountsDescription;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) PaddockedMountsDescription.Length);
            foreach (var entry in PaddockedMountsDescription)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            PaddockedMountsDescription = new MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                PaddockedMountsDescription[i] = new MountClientData();
                PaddockedMountsDescription[i].Deserialize(reader);
            }
        }
    }
}