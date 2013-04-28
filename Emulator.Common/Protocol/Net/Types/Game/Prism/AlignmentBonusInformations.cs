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

namespace Emulator.Common.Protocol.Net.Types.Game.Prism
{
    public class AlignmentBonusInformations
    {
        public const short ID = 135;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Pctbonus { get; set; }
        public double Grademult { get; set; }


        public AlignmentBonusInformations()
        {
        }

        public AlignmentBonusInformations(int pctbonus, double grademult)
        {
            Pctbonus = pctbonus;
            Grademult = grademult;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Pctbonus);
            writer.WriteDouble(Grademult);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Pctbonus = reader.ReadInt();
            Grademult = reader.ReadDouble();
        }
    }
}