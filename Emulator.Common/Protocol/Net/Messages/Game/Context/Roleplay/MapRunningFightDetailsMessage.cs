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
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        public const uint Id = 5751;
        public bool[] alives;

        public int fightId;
        public short[] levels;
        public string[] names;
        public sbyte teamSwap;

        public override uint MessageId
        {
            get { return Id; }
        }


        public MapRunningFightDetailsMessage()
        {
        }

        public MapRunningFightDetailsMessage(int fightId, string[] names, short[] levels, sbyte teamSwap, bool[] alives)
        {
            this.fightId = fightId;
            this.names = names;
            this.levels = levels;
            this.teamSwap = teamSwap;
            this.alives = alives;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteUShort((ushort) names.Length);
            foreach (var entry in names)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) levels.Length);
            foreach (var entry in levels)
            {
                writer.WriteShort(entry);
            }
            writer.WriteSByte(teamSwap);
            writer.WriteUShort((ushort) alives.Length);
            foreach (var entry in alives)
            {
                writer.WriteBoolean(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadUShort();
            names = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                names[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            levels = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                levels[i] = reader.ReadShort();
            }
            teamSwap = reader.ReadSByte();
            if (teamSwap < 0)
                throw new Exception("Forbidden value on teamSwap = " + teamSwap + ", it doesn't respect the following condition : teamSwap < 0");
            limit = reader.ReadUShort();
            alives = new bool[limit];
            for (int i = 0; i < limit; i++)
            {
                alives[i] = reader.ReadBoolean();
            }
        }
    }
}