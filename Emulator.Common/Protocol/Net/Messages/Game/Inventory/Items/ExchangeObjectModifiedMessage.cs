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
using Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges;
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class ExchangeObjectModifiedMessage : ExchangeObjectMessage
    {
        public const uint ID = 5519;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ObjectItem @object { get; set; }


        public ExchangeObjectModifiedMessage()
        {
        }

        public ExchangeObjectModifiedMessage(bool remote, ObjectItem @object)
                : base(remote)
        {
            this.@object = @object;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            @object.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            @object = new ObjectItem();
            @object.Deserialize(reader);
        }
    }
}