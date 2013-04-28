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
    public class StatedElementUpdatedMessage : NetworkMessage
    {
        public const uint ID = 5709;

        public override uint MessageId
        {
            get { return ID; }
        }

        public StatedElement StatedElement { get; set; }


        public StatedElementUpdatedMessage()
        {
        }

        public StatedElementUpdatedMessage(StatedElement statedElement)
        {
            StatedElement = statedElement;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            StatedElement.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            StatedElement = new StatedElement();
            StatedElement.Deserialize(reader);
        }
    }
}