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

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public const short Id = 148;

        public short firstNameId;
        public GuildInformations guildIdentity;
        public byte guildLevel;
        public short lastNameId;
        public int taxCollectorAttack;

        public override short TypeId
        {
            get { return Id; }
        }


        public GameRolePlayTaxCollectorInformations()
        {
        }

        public GameRolePlayTaxCollectorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, short firstNameId, short lastNameId, GuildInformations guildIdentity, byte guildLevel, int taxCollectorAttack)
            : base(contextualId, look, disposition)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.guildIdentity = guildIdentity;
            this.guildLevel = guildLevel;
            this.taxCollectorAttack = taxCollectorAttack;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(firstNameId);
            writer.WriteShort(lastNameId);
            guildIdentity.Serialize(writer);
            writer.WriteByte(guildLevel);
            writer.WriteInt(taxCollectorAttack);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            firstNameId = reader.ReadShort();
            if (firstNameId < 0)
                throw new Exception("Forbidden value on firstNameId = " + firstNameId + ", it doesn't respect the following condition : firstNameId < 0");
            lastNameId = reader.ReadShort();
            if (lastNameId < 0)
                throw new Exception("Forbidden value on lastNameId = " + lastNameId + ", it doesn't respect the following condition : lastNameId < 0");
            guildIdentity = new GuildInformations();
            guildIdentity.Deserialize(reader);
            guildLevel = reader.ReadByte();
            if (guildLevel < 0 || guildLevel > 255)
                throw new Exception("Forbidden value on guildLevel = " + guildLevel + ", it doesn't respect the following condition : guildLevel < 0 || guildLevel > 255");
            taxCollectorAttack = reader.ReadInt();
        }
    }
}