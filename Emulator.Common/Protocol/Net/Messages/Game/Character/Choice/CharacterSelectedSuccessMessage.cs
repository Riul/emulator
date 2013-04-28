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
using Emulator.Common.Protocol.Net.Types.Game.Character.Choice;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Choice
{
    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const uint ID = 153;

        public override uint MessageId
        {
            get { return ID; }
        }

        public CharacterBaseInformations Infos { get; set; }


        public CharacterSelectedSuccessMessage()
        {
        }

        public CharacterSelectedSuccessMessage(CharacterBaseInformations infos)
        {
            Infos = infos;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            Infos.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Infos = new CharacterBaseInformations();
            Infos.Deserialize(reader);
        }
    }
}