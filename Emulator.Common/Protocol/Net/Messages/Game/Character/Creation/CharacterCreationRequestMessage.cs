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

using System.Collections.Generic;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Creation
{
    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const uint Id = 160;

        public int breed = 0;
        public List<int> colors;
        public int cosmeticId = 0;
        public string name = "";
        public bool sex = false;

        public CharacterCreationRequestMessage()
        {
            colors = new List<int>();
        }

        public CharacterCreationRequestMessage(string name, int breed, bool sex, List<int> colors, int cosmeticId)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
            this.cosmeticId = cosmeticId;
        }

        public override uint MessageId
        {
            get { return 160; }
        }

        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteByte((byte)breed);
            writer.WriteBoolean(sex);
            foreach (var color in colors)
            {
                writer.WriteInt(color);
            }
            writer.WriteInt(cosmeticId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            name = reader.ReadUTF();
            breed = reader.ReadByte();
            sex = reader.ReadBoolean();
            colors = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                colors.Add(reader.ReadInt());
            }
            cosmeticId = reader.ReadInt();
        }
    }
}
