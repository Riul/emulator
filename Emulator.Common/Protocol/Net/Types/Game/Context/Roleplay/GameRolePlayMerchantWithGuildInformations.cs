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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GameRolePlayMerchantWithGuildInformations : GameRolePlayMerchantInformations
    {
        public const short Id = 146;

        public GuildInformations guildInformations;

        public override short TypeId
        {
            get { return Id; }
        }


        public GameRolePlayMerchantWithGuildInformations()
        {
        }

        public GameRolePlayMerchantWithGuildInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, int sellType, GuildInformations guildInformations)
            : base(contextualId, look, disposition, name, sellType)
        {
            this.guildInformations = guildInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            guildInformations.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            guildInformations = new GuildInformations();
            guildInformations.Deserialize(reader);
        }
    }
}