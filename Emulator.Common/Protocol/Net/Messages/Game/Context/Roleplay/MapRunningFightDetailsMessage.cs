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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        public const uint ID = 5751;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int FightId { get; set; }
        public GameFightFighterLightInformations[] Attackers { get; set; }
        public GameFightFighterLightInformations[] Defenders { get; set; }


        public MapRunningFightDetailsMessage()
        {
        }

        public MapRunningFightDetailsMessage(int fightId, GameFightFighterLightInformations[] attackers, GameFightFighterLightInformations[] defenders)
        {
            FightId = fightId;
            Attackers = attackers;
            Defenders = defenders;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteUShort((ushort) Attackers.Length);
            foreach (var entry in Attackers)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Defenders.Length);
            foreach (var entry in Defenders)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadInt();
            var limit = reader.ReadUShort();
            Attackers = new GameFightFighterLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Attackers[i] = new GameFightFighterLightInformations();
                Attackers[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Defenders = new GameFightFighterLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Defenders[i] = new GameFightFighterLightInformations();
                Defenders[i].Deserialize(reader);
            }
        }
    }
}