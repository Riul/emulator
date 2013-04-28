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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat
{
    public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage
    {
        public const uint ID = 862;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ObjectItem[] Objects { get; set; }


        public ChatClientMultiWithObjectMessage()
        {
        }

        public ChatClientMultiWithObjectMessage(string content, sbyte channel, ObjectItem[] objects)
                : base(content, channel)
        {
            Objects = objects;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) Objects.Length);
            foreach (var entry in Objects)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            Objects = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                Objects[i] = new ObjectItem();
                Objects[i].Deserialize(reader);
            }
        }
    }
}