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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public const short ID = 84;

        public override short TypeId
        {
            get { return ID; }
        }

        public byte Level { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }
        public int ExperienceForGuild { get; set; }


        public FightResultTaxCollectorListEntry()
        {
        }

        public FightResultTaxCollectorListEntry(short outcome, FightLoot rewards, int id, bool alive, byte level, BasicGuildInformations guildInfo, int experienceForGuild)
                : base(outcome, rewards, id, alive)
        {
            Level = level;
            GuildInfo = guildInfo;
            ExperienceForGuild = experienceForGuild;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
            GuildInfo.Serialize(writer);
            writer.WriteInt(ExperienceForGuild);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
            ExperienceForGuild = reader.ReadInt();
        }
    }
}