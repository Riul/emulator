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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightEndMessage : NetworkMessage
    {
        public const uint ID = 720;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int Duration { get; set; }
        public short AgeBonus { get; set; }
        public short LootShareLimitMalus { get; set; }
        public FightResultListEntry[] Results { get; set; }


        public GameFightEndMessage()
        {
        }

        public GameFightEndMessage(int duration, short ageBonus, short lootShareLimitMalus, FightResultListEntry[] results)
        {
            Duration = duration;
            AgeBonus = ageBonus;
            LootShareLimitMalus = lootShareLimitMalus;
            Results = results;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Duration);
            writer.WriteShort(AgeBonus);
            writer.WriteShort(LootShareLimitMalus);
            writer.WriteUShort((ushort) Results.Length);
            foreach (var entry in Results)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Duration = reader.ReadInt();
            AgeBonus = reader.ReadShort();
            LootShareLimitMalus = reader.ReadShort();
            var limit = reader.ReadUShort();
            Results = new FightResultListEntry[limit];
            for (int i = 0; i < limit; i++)
            {
                Results[i] = Types.ProtocolTypeManager.GetInstance<FightResultListEntry>(reader.ReadShort());
                Results[i].Deserialize(reader);
            }
        }
    }
}