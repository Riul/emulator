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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects
{
    public class ObjectEffectDice : ObjectEffect
    {
        public const short Id = 73;
        public short diceConst;

        public short diceNum;
        public short diceSide;

        public override short TypeId
        {
            get { return Id; }
        }


        public ObjectEffectDice()
        {
        }

        public ObjectEffectDice(short actionId, short diceNum, short diceSide, short diceConst)
            : base(actionId)
        {
            this.diceNum = diceNum;
            this.diceSide = diceSide;
            this.diceConst = diceConst;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(diceNum);
            writer.WriteShort(diceSide);
            writer.WriteShort(diceConst);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            diceNum = reader.ReadShort();
            if (diceNum < 0)
                throw new Exception("Forbidden value on diceNum = " + diceNum + ", it doesn't respect the following condition : diceNum < 0");
            diceSide = reader.ReadShort();
            if (diceSide < 0)
                throw new Exception("Forbidden value on diceSide = " + diceSide + ", it doesn't respect the following condition : diceSide < 0");
            diceConst = reader.ReadShort();
            if (diceConst < 0)
                throw new Exception("Forbidden value on diceConst = " + diceConst + ", it doesn't respect the following condition : diceConst < 0");
        }
    }
}