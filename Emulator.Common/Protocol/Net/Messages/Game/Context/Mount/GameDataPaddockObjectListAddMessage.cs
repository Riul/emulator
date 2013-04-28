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
using Emulator.Common.Protocol.Net.Types.Game.Paddock;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Mount
{
    public class GameDataPaddockObjectListAddMessage : NetworkMessage
    {
        public const uint ID = 5992;

        public override uint MessageId
        {
            get { return ID; }
        }

        public PaddockItem[] PaddockItemDescription { get; set; }


        public GameDataPaddockObjectListAddMessage()
        {
        }

        public GameDataPaddockObjectListAddMessage(PaddockItem[] paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) PaddockItemDescription.Length);
            foreach (var entry in PaddockItemDescription)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            PaddockItemDescription = new PaddockItem[limit];
            for (int i = 0; i < limit; i++)
            {
                PaddockItemDescription[i] = new PaddockItem();
                PaddockItemDescription[i].Deserialize(reader);
            }
        }
    }
}