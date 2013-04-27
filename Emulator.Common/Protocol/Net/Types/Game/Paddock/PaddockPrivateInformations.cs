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

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class PaddockPrivateInformations : PaddockAbandonnedInformations
    {
        public const short Id = 131;

        public GuildInformations guildInfo;

        public override short TypeId
        {
            get { return Id; }
        }


        public PaddockPrivateInformations()
        {
        }

        public PaddockPrivateInformations(short maxOutdoorMount, short maxItems, int price, bool locked, int guildId, GuildInformations guildInfo)
            : base(maxOutdoorMount, maxItems, price, locked, guildId)
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