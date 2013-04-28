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
    public class CharactersListWithModificationsMessage : CharactersListMessage
    {
        public const uint ID = 6120;

        public override uint MessageId
        {
            get { return ID; }
        }

        public CharacterToRecolorInformation[] CharactersToRecolor { get; set; }
        public int[] CharactersToRename { get; set; }
        public int[] UnusableCharacters { get; set; }
        public CharacterToRelookInformation[] CharactersToRelook { get; set; }


        public CharactersListWithModificationsMessage()
        {
        }

        public CharactersListWithModificationsMessage(bool hasStartupActions, CharacterBaseInformations[] characters, CharacterToRecolorInformation[] charactersToRecolor, int[] charactersToRename, int[] unusableCharacters, CharacterToRelookInformation[] charactersToRelook)
                : base(hasStartupActions, characters)
        {
            CharactersToRecolor = charactersToRecolor;
            CharactersToRename = charactersToRename;
            UnusableCharacters = unusableCharacters;
            CharactersToRelook = charactersToRelook;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) CharactersToRecolor.Length);
            foreach (var entry in CharactersToRecolor)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) CharactersToRename.Length);
            foreach (var entry in CharactersToRename)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) UnusableCharacters.Length);
            foreach (var entry in UnusableCharacters)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) CharactersToRelook.Length);
            foreach (var entry in CharactersToRelook)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            CharactersToRecolor = new CharacterToRecolorInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                CharactersToRecolor[i] = new CharacterToRecolorInformation();
                CharactersToRecolor[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            CharactersToRename = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                CharactersToRename[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            UnusableCharacters = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                UnusableCharacters[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            CharactersToRelook = new CharacterToRelookInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                CharactersToRelook[i] = new CharacterToRelookInformation();
                CharactersToRelook[i].Deserialize(reader);
            }
        }
    }
}