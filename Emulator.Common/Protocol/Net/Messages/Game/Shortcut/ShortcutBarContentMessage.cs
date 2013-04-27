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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Shortcut
{
    public class ShortcutBarContentMessage : NetworkMessage
    {
        public const uint Id = 6231;

        public sbyte barType;
        public Types.Game.Shortcut.Shortcut[] shortcuts;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ShortcutBarContentMessage()
        {
        }

        public ShortcutBarContentMessage(sbyte barType, Types.Game.Shortcut.Shortcut[] shortcuts)
        {
            this.barType = barType;
            this.shortcuts = shortcuts;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(barType);
            writer.WriteUShort((ushort) shortcuts.Length);
            foreach (var entry in shortcuts)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            barType = reader.ReadSByte();
            if (barType < 0)
                throw new Exception("Forbidden value on barType = " + barType + ", it doesn't respect the following condition : barType < 0");
            var limit = reader.ReadUShort();
            shortcuts = new Types.Game.Shortcut.Shortcut[limit];
            for (int i = 0; i < limit; i++)
            {
                shortcuts[i] = Types.ProtocolTypeManager.GetInstance<Types.Game.Shortcut.Shortcut>(reader.ReadShort());
                shortcuts[i].Deserialize(reader);
            }
        }
    }
}