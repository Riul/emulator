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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public const short ID = 143;

        public override short TypeId
        {
            get { return ID; }
        }

        public sbyte TeamId { get; set; }
        public bool Alive { get; set; }
        public GameFightMinimalStats Stats { get; set; }


        public GameFightFighterInformations()
        {
        }

        public GameFightFighterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats)
                : base(contextualId, look, disposition)
        {
            TeamId = teamId;
            Alive = alive;
            Stats = stats;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(TeamId);
            writer.WriteBoolean(Alive);
            writer.WriteShort(Stats.TypeId);
            Stats.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            TeamId = reader.ReadSByte();
            Alive = reader.ReadBoolean();
            Stats = Types.ProtocolTypeManager.GetInstance<GameFightMinimalStats>(reader.ReadShort());
            Stats.Deserialize(reader);
        }
    }
}