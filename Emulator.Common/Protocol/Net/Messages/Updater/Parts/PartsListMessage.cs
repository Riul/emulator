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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Updater;

namespace Emulator.Common.Protocol.Net.Messages.Updater.Parts
{
    public class PartsListMessage : NetworkMessage
    {
        public const uint ID = 1502;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ContentPart[] Parts { get; set; }


        public PartsListMessage()
        {
        }

        public PartsListMessage(ContentPart[] parts)
        {
            Parts = parts;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Parts.Length);
            foreach (var entry in Parts)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Parts = new ContentPart[limit];
            for (int i = 0; i < limit; i++)
            {
                Parts[i] = new ContentPart();
                Parts[i].Deserialize(reader);
            }
        }
    }
}