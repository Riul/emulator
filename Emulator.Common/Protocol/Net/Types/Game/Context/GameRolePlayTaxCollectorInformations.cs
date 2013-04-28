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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public const short ID = 148;

        public override short TypeId
        {
            get { return ID; }
        }

        public short FirstNameId { get; set; }
        public short LastNameId { get; set; }
        public GuildInformations GuildIdentity { get; set; }
        public byte GuildLevel { get; set; }
        public int TaxCollectorAttack { get; set; }


        public GameRolePlayTaxCollectorInformations()
        {
        }

        public GameRolePlayTaxCollectorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, short firstNameId, short lastNameId, GuildInformations guildIdentity, byte guildLevel, int taxCollectorAttack)
                : base(contextualId, look, disposition)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            GuildIdentity = guildIdentity;
            GuildLevel = guildLevel;
            TaxCollectorAttack = taxCollectorAttack;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(FirstNameId);
            writer.WriteShort(LastNameId);
            GuildIdentity.Serialize(writer);
            writer.WriteByte(GuildLevel);
            writer.WriteInt(TaxCollectorAttack);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadShort();
            LastNameId = reader.ReadShort();
            GuildIdentity = new GuildInformations();
            GuildIdentity.Deserialize(reader);
            GuildLevel = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
        }
    }
}