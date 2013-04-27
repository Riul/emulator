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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public const short Id = 143;

        public bool alive;
        public GameFightMinimalStats stats;
        public sbyte teamId;

        public override short TypeId
        {
            get { return Id; }
        }


        public GameFightFighterInformations()
        {
        }

        public GameFightFighterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats)
            : base(contextualId, look, disposition)
        {
            this.teamId = teamId;
            this.alive = alive;
            this.stats = stats;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(teamId);
            writer.WriteBoolean(alive);
            writer.WriteShort(stats.TypeId);
            stats.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            teamId = reader.ReadSByte();
            if (teamId < 0)
                throw new Exception("Forbidden value on teamId = " + teamId + ", it doesn't respect the following condition : teamId < 0");
            alive = reader.ReadBoolean();
            stats = Types.ProtocolTypeManager.GetInstance<GameFightMinimalStats>(reader.ReadShort());
            stats.Deserialize(reader);
        }
    }
}