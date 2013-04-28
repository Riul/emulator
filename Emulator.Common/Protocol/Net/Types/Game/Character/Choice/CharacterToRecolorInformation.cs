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

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Choice
{
    public class CharacterToRecolorInformation : AbstractCharacterInformation
    {
        public const short ID = 212;

        public override short TypeId
        {
            get { return ID; }
        }

        public int[] Colors { get; set; }


        public CharacterToRecolorInformation()
        {
        }

        public CharacterToRecolorInformation(int id, int[] colors)
                : base(id)
        {
            Colors = colors;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) Colors.Length);
            foreach (var entry in Colors)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            Colors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Colors[i] = reader.ReadInt();
            }
        }
    }
}