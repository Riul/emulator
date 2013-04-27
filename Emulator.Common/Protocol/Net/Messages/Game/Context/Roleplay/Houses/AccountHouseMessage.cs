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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.House;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Houses
{
    public class AccountHouseMessage : NetworkMessage
    {
        public const uint Id = 6315;

        public AccountHouseInformations[] houses;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AccountHouseMessage()
        {
        }

        public AccountHouseMessage(AccountHouseInformations[] houses)
        {
            this.houses = houses;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) houses.Length);
            foreach (var entry in houses)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            houses = new AccountHouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                houses[i] = new AccountHouseInformations();
                houses[i].Deserialize(reader);
            }
        }
    }
}