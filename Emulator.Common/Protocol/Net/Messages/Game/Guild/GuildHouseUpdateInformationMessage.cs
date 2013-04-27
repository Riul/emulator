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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildHouseUpdateInformationMessage : NetworkMessage
    {
        public const uint Id = 6181;

        public HouseInformationsForGuild housesInformations;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildHouseUpdateInformationMessage()
        {
        }

        public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
        {
            this.housesInformations = housesInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            housesInformations.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            housesInformations = new HouseInformationsForGuild();
            housesInformations.Deserialize(reader);
        }
    }
}