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
    public class CharactersListWithModificationsMessage : CharactersListMessage
    {
        public const uint Id = 6120;

        public CharacterToRecolorInformation[] charactersToRecolor;
        public CharacterToRelookInformation[] charactersToRelook;
        public int[] charactersToRename;
        public int[] unusableCharacters;


        public CharactersListWithModificationsMessage()
        {
        }

        public CharactersListWithModificationsMessage(bool hasStartupActions, CharacterBaseInformations[] characters, CharacterToRecolorInformation[] charactersToRecolor, int[] charactersToRename, int[] unusableCharacters, CharacterToRelookInformation[] charactersToRelook)
            : base(hasStartupActions, characters)
        {
            this.charactersToRecolor = charactersToRecolor;
            this.charactersToRename = charactersToRename;
            this.unusableCharacters = unusableCharacters;
            this.charactersToRelook = charactersToRelook;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) charactersToRecolor.Length);
            foreach (var entry in charactersToRecolor)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) charactersToRename.Length);
            foreach (var entry in charactersToRename)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) unusableCharacters.Length);
            foreach (var entry in unusableCharacters)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) charactersToRelook.Length);
            foreach (var entry in charactersToRelook)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            charactersToRecolor = new CharacterToRecolorInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                charactersToRecolor[i] = new CharacterToRecolorInformation();
                charactersToRecolor[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            charactersToRename = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                charactersToRename[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            unusableCharacters = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                unusableCharacters[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            charactersToRelook = new CharacterToRelookInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                charactersToRelook[i] = new CharacterToRelookInformation();
                charactersToRelook[i].Deserialize(reader);
            }
        }
    }
}