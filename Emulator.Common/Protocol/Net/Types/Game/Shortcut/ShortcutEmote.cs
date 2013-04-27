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

namespace Emulator.Common.Protocol.Net.Types.Game.Shortcut
{
    public class ShortcutEmote : Shortcut
    {
        public const short Id = 389;

        public sbyte emoteId;

        public override short TypeId
        {
            get { return Id; }
        }


        public ShortcutEmote()
        {
        }

        public ShortcutEmote(int slot, sbyte emoteId)
            : base(slot)
        {
            this.emoteId = emoteId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(emoteId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            emoteId = reader.ReadSByte();
            if (emoteId < 0)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0");
        }
    }
}