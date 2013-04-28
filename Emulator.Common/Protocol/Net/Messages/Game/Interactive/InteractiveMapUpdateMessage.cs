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
using Emulator.Common.Protocol.Net.Types.Game.Interactive;

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive
{
    public class InteractiveMapUpdateMessage : NetworkMessage
    {
        public const uint ID = 5002;

        public override uint MessageId
        {
            get { return ID; }
        }

        public InteractiveElement[] InteractiveElements { get; set; }


        public InteractiveMapUpdateMessage()
        {
        }

        public InteractiveMapUpdateMessage(InteractiveElement[] interactiveElements)
        {
            InteractiveElements = interactiveElements;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) InteractiveElements.Length);
            foreach (var entry in InteractiveElements)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            InteractiveElements = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                InteractiveElements[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
                InteractiveElements[i].Deserialize(reader);
            }
        }
    }
}