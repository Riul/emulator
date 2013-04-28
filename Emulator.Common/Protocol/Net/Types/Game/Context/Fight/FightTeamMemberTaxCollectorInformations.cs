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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
    {
        public const short ID = 177;

        public override short TypeId
        {
            get { return ID; }
        }

        public short FirstNameId { get; set; }
        public short LastNameId { get; set; }
        public byte Level { get; set; }
        public int GuildId { get; set; }
        public int Uid { get; set; }


        public FightTeamMemberTaxCollectorInformations()
        {
        }

        public FightTeamMemberTaxCollectorInformations(int id, short firstNameId, short lastNameId, byte level, int guildId, int uid)
                : base(id)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
            GuildId = guildId;
            Uid = uid;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(FirstNameId);
            writer.WriteShort(LastNameId);
            writer.WriteByte(Level);
            writer.WriteInt(GuildId);
            writer.WriteInt(Uid);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadShort();
            LastNameId = reader.ReadShort();
            Level = reader.ReadByte();
            GuildId = reader.ReadInt();
            Uid = reader.ReadInt();
        }
    }
}