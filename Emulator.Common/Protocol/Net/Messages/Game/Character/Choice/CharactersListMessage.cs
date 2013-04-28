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
    public class CharactersListMessage : NetworkMessage
    {
        public const uint ID = 151;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool HasStartupActions { get; set; }
        public CharacterBaseInformations[] Characters { get; set; }


        public CharactersListMessage()
        {
        }

        public CharactersListMessage(bool hasStartupActions, CharacterBaseInformations[] characters)
        {
            HasStartupActions = hasStartupActions;
            Characters = characters;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(HasStartupActions);
            writer.WriteUShort((ushort) Characters.Length);
            foreach (var entry in Characters)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            HasStartupActions = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Characters = new CharacterBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Characters[i] = Types.ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
                Characters[i].Deserialize(reader);
            }
        }
    }
}