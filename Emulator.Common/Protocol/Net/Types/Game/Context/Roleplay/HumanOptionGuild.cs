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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class HumanOptionGuild : HumanOption
    {
        public const short ID = 409;

        public override short TypeId
        {
            get { return ID; }
        }

        public GuildInformations GuildInformations { get; set; }


        public HumanOptionGuild()
        {
        }

        public HumanOptionGuild(GuildInformations guildInformations)
        {
            GuildInformations = guildInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            GuildInformations.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            GuildInformations = new GuildInformations();
            GuildInformations.Deserialize(reader);
        }
    }
}