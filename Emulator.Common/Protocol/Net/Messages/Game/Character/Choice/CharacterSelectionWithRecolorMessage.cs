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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Choice
{
    public class CharacterSelectionWithRecolorMessage : CharacterSelectionMessage
    {
        public const uint Id = 6075;

        public int[] indexedColor;

        public override uint MessageId
        {
            get { return Id; }
        }


        public CharacterSelectionWithRecolorMessage()
        {
        }

        public CharacterSelectionWithRecolorMessage(int id, int[] indexedColor)
            : base(id)
        {
            this.indexedColor = indexedColor;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) indexedColor.Length);
            foreach (var entry in indexedColor)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            indexedColor = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                indexedColor[i] = reader.ReadInt();
            }
        }
    }
}