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
    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public const short ID = 29;

        public override short TypeId
        {
            get { return ID; }
        }

        public short CreatureGenericId { get; set; }
        public sbyte CreatureGrade { get; set; }


        public GameFightMonsterInformations()
        {
        }

        public GameFightMonsterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, short creatureGenericId, sbyte creatureGrade)
                : base(contextualId, look, disposition, teamId, alive, stats)
        {
            CreatureGenericId = creatureGenericId;
            CreatureGrade = creatureGrade;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(CreatureGenericId);
            writer.WriteSByte(CreatureGrade);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadShort();
            CreatureGrade = reader.ReadSByte();
        }
    }
}