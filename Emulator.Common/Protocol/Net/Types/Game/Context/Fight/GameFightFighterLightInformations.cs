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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightFighterLightInformations
    {
        public const short ID = 413;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public bool Sex { get; set; }
        public bool Alive { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
        public sbyte Breed { get; set; }


        public GameFightFighterLightInformations()
        {
        }

        public GameFightFighterLightInformations(bool sex, bool alive, int id, string name, short level, sbyte breed)
        {
            Sex = sex;
            Alive = alive;
            Id = id;
            Name = name;
            Level = level;
            Breed = breed;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, Alive);
            writer.WriteByte(flag1);
            writer.WriteInt(Id);
            writer.WriteUTF(Name);
            writer.WriteShort(Level);
            writer.WriteSByte(Breed);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(flag1, 0);
            Alive = BooleanByteWrapper.GetFlag(flag1, 1);
            Id = reader.ReadInt();
            Name = reader.ReadUTF();
            Level = reader.ReadShort();
            Breed = reader.ReadSByte();
        }
    }
}