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

namespace Emulator.Common.Protocol.Net.Types.Game.Friend
{
    public class IgnoredOnlineInformations : IgnoredInformations
    {
        public const short Id = 105;

        public sbyte breed;
        public string playerName;
        public bool sex;

        public override short TypeId
        {
            get { return Id; }
        }


        public IgnoredOnlineInformations()
        {
        }

        public IgnoredOnlineInformations(int accountId, string accountName, string playerName, sbyte breed, bool sex)
            : base(accountId, accountName)
        {
            this.playerName = playerName;
            this.breed = breed;
            this.sex = sex;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(playerName);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            playerName = reader.ReadUTF();
            breed = reader.ReadSByte();
            if (breed < (byte) Enums.PlayableBreedEnum.Feca || breed > (byte) Enums.PlayableBreedEnum.Steamer)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Steamer");
            sex = reader.ReadBoolean();
        }
    }
}