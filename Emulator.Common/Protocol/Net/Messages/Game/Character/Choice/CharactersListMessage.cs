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
using Emulator.Common.Protocol.Net.Types.Game.Character.Choice;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Choice
{
    public class CharactersListMessage : NetworkMessage
    {
        public const uint Id = 151;

        public CharacterBaseInformations[] characters;
        public bool hasStartupActions;


        public CharactersListMessage()
        {
        }

        public CharactersListMessage(bool hasStartupActions, CharacterBaseInformations[] characters)
        {
            this.hasStartupActions = hasStartupActions;
            this.characters = characters;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(hasStartupActions);
            writer.WriteUShort((ushort) characters.Length);
            foreach (var entry in characters)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            hasStartupActions = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            characters = new CharacterBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                characters[i] = Types.ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
                characters[i].Deserialize(reader);
            }
        }
    }
}