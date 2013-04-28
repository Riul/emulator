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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public const short ID = 3;

        public override short TypeId
        {
            get { return ID; }
        }

        public int MonsterId { get; set; }
        public sbyte PowerLevel { get; set; }


        public GameRolePlayMutantInformations()
        {
        }

        public GameRolePlayMutantInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId, int monsterId, sbyte powerLevel)
                : base(contextualId, look, disposition, name, humanoidInfo, accountId)
        {
            MonsterId = monsterId;
            PowerLevel = powerLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MonsterId);
            writer.WriteSByte(PowerLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadInt();
            PowerLevel = reader.ReadSByte();
        }
    }
}