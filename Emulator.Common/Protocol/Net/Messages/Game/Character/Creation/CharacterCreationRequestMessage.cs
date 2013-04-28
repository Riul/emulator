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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Creation
{
    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const uint ID = 160;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public int[] Colors { get; set; }
        public int CosmeticId { get; set; }


        public CharacterCreationRequestMessage()
        {
        }

        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, int[] colors, int cosmeticId)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            Colors = colors;
            CosmeticId = cosmeticId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteUShort((ushort) Colors.Length);
            foreach (var entry in Colors)
            {
                writer.WriteInt(entry);
            }
            writer.WriteInt(CosmeticId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Colors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Colors[i] = reader.ReadInt();
            }
            CosmeticId = reader.ReadInt();
        }
    }
}