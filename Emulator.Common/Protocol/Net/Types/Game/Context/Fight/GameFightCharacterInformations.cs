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
using Emulator.Common.Protocol.Net.Types.Game.Character.Alignment;
using Emulator.Common.Protocol.Net.Types.Game.Character.Status;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public const short ID = 46;

        public override short TypeId
        {
            get { return ID; }
        }

        public short Level { get; set; }
        public ActorAlignmentInformations AlignmentInfos { get; set; }
        public sbyte Breed { get; set; }


        public GameFightCharacterInformations()
        {
        }

        public GameFightCharacterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, string name, PlayerStatus status, short level, ActorAlignmentInformations alignmentInfos, sbyte breed)
                : base(contextualId, look, disposition, teamId, alive, stats, name, status)
        {
            Level = level;
            AlignmentInfos = alignmentInfos;
            Breed = breed;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Level);
            AlignmentInfos.Serialize(writer);
            writer.WriteSByte(Breed);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadShort();
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            Breed = reader.ReadSByte();
        }
    }
}