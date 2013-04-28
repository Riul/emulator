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
    public class AccountHouseMessage : NetworkMessage
    {
        public const uint ID = 6315;

        public override uint MessageId
        {
            get { return ID; }
        }

        public AccountHouseInformations[] Houses { get; set; }


        public AccountHouseMessage()
        {
        }

        public AccountHouseMessage(AccountHouseInformations[] houses)
        {
            Houses = houses;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Houses.Length);
            foreach (var entry in Houses)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Houses = new AccountHouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Houses[i] = new AccountHouseInformations();
                Houses[i].Deserialize(reader);
            }
        }
    }
}