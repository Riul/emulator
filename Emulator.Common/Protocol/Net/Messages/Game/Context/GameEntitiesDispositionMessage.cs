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
using Emulator.Common.Protocol.Net.Types.Game.Context;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context
{
    public class GameEntitiesDispositionMessage : NetworkMessage
    {
        public const uint ID = 5696;

        public override uint MessageId
        {
            get { return ID; }
        }

        public IdentifiedEntityDispositionInformations[] Dispositions { get; set; }


        public GameEntitiesDispositionMessage()
        {
        }

        public GameEntitiesDispositionMessage(IdentifiedEntityDispositionInformations[] dispositions)
        {
            Dispositions = dispositions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Dispositions.Length);
            foreach (var entry in Dispositions)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Dispositions = new IdentifiedEntityDispositionInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Dispositions[i] = new IdentifiedEntityDispositionInformations();
                Dispositions[i].Deserialize(reader);
            }
        }
    }
}