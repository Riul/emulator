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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
    {
        public const short Id = 6;

        public sbyte grade;
        public int monsterId;

        public override short TypeId
        {
            get { return Id; }
        }


        public FightTeamMemberMonsterInformations()
        {
        }

        public FightTeamMemberMonsterInformations(int id, int monsterId, sbyte grade)
            : base(id)
        {
            this.monsterId = monsterId;
            this.grade = grade;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(monsterId);
            writer.WriteSByte(grade);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            monsterId = reader.ReadInt();
            grade = reader.ReadSByte();
            if (grade < 0)
                throw new Exception("Forbidden value on grade = " + grade + ", it doesn't respect the following condition : grade < 0");
        }
    }
}