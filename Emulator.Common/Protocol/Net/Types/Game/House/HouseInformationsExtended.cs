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
// Created on 26/04/2013 at 16:46
#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;

namespace Emulator.Common.Protocol.Net.Types.Game.House
{
    public class HouseInformationsExtended : HouseInformations
    {
        public const short Id = 112;

        public GuildInformations guildInfo;

        public override short TypeId
        {
            get { return Id; }
        }


        public HouseInformationsExtended()
        {
        }

        public HouseInformationsExtended(bool isOnSale, bool isSaleLocked, int houseId, int[] doorsOnMap, string ownerName, short modelId, GuildInformations guildInfo)
            : base(isOnSale, isSaleLocked, houseId, doorsOnMap, ownerName, modelId)
        {
            this.guildInfo = guildInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            guildInfo.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            guildInfo = new GuildInformations();
            guildInfo.Deserialize(reader);
        }
    }
}