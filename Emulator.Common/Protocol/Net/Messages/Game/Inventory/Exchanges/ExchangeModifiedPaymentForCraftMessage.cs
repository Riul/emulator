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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeModifiedPaymentForCraftMessage : NetworkMessage
    {
        public const uint ID = 5832;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool OnlySuccess { get; set; }
        public ObjectItemNotInContainer @object { get; set; }


        public ExchangeModifiedPaymentForCraftMessage()
        {
        }

        public ExchangeModifiedPaymentForCraftMessage(bool onlySuccess, ObjectItemNotInContainer @object)
        {
            OnlySuccess = onlySuccess;
            this.@object = @object;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(OnlySuccess);
            @object.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            OnlySuccess = reader.ReadBoolean();
            @object = new ObjectItemNotInContainer();
            @object.Deserialize(reader);
        }
    }
}