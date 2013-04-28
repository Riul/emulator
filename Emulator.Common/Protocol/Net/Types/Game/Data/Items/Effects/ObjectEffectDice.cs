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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects
{
    public class ObjectEffectDice : ObjectEffect
    {
        public const short ID = 73;

        public override short TypeId
        {
            get { return ID; }
        }

        public short DiceNum { get; set; }
        public short DiceSide { get; set; }
        public short DiceConst { get; set; }


        public ObjectEffectDice()
        {
        }

        public ObjectEffectDice(short actionId, short diceNum, short diceSide, short diceConst)
                : base(actionId)
        {
            DiceNum = diceNum;
            DiceSide = diceSide;
            DiceConst = diceConst;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(DiceNum);
            writer.WriteShort(DiceSide);
            writer.WriteShort(DiceConst);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            DiceNum = reader.ReadShort();
            DiceSide = reader.ReadShort();
            DiceConst = reader.ReadShort();
        }
    }
}