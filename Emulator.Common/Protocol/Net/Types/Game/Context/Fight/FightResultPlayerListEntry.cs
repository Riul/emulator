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
    public class FightResultPlayerListEntry : FightResultFighterListEntry
    {
        public const short ID = 24;

        public override short TypeId
        {
            get { return ID; }
        }

        public byte Level { get; set; }
        public FightResultAdditionalData[] Additional { get; set; }


        public FightResultPlayerListEntry()
        {
        }

        public FightResultPlayerListEntry(short outcome, FightLoot rewards, int id, bool alive, byte level, FightResultAdditionalData[] additional)
                : base(outcome, rewards, id, alive)
        {
            Level = level;
            Additional = additional;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
            writer.WriteUShort((ushort) Additional.Length);
            foreach (var entry in Additional)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
            var limit = reader.ReadUShort();
            Additional = new FightResultAdditionalData[limit];
            for (int i = 0; i < limit; i++)
            {
                Additional[i] = Types.ProtocolTypeManager.GetInstance<FightResultAdditionalData>(reader.ReadShort());
                Additional[i].Deserialize(reader);
            }
        }
    }
}