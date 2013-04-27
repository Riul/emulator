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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat
{
    public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
    {
        public const uint Id = 852;

        public ObjectItem[] objects;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ChatClientPrivateWithObjectMessage()
        {
        }

        public ChatClientPrivateWithObjectMessage(string content, string receiver, ObjectItem[] objects)
            : base(content, receiver)
        {
            this.objects = objects;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) objects.Length);
            foreach (var entry in objects)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            objects = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                objects[i] = new ObjectItem();
                objects[i].Deserialize(reader);
            }
        }
    }
}