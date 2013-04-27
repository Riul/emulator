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
using Emulator.Common.Protocol.Net.Types.Game.Mount;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeMountPaddockAddMessage : NetworkMessage
    {
        public const uint Id = 6049;

        public MountClientData mountDescription;


        public ExchangeMountPaddockAddMessage()
        {
        }

        public ExchangeMountPaddockAddMessage(MountClientData mountDescription)
        {
            this.mountDescription = mountDescription;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            mountDescription.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            mountDescription = new MountClientData();
            mountDescription.Deserialize(reader);
        }
    }
}