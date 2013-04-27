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
using Emulator.Common.Protocol.Net.Types.Game.Context;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context
{
    public class GameContextMoveMultipleElementsMessage : NetworkMessage
    {
        public const uint Id = 254;

        public EntityMovementInformations[] movements;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameContextMoveMultipleElementsMessage()
        {
        }

        public GameContextMoveMultipleElementsMessage(EntityMovementInformations[] movements)
        {
            this.movements = movements;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) movements.Length);
            foreach (var entry in movements)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            movements = new EntityMovementInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                movements[i] = new EntityMovementInformations();
                movements[i].Deserialize(reader);
            }
        }
    }
}