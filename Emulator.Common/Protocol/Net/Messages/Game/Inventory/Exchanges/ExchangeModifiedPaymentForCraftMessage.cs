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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeModifiedPaymentForCraftMessage : NetworkMessage
    {
        public const uint Id = 5832;

        public ObjectItemNotInContainer @object;
        public bool onlySuccess;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeModifiedPaymentForCraftMessage()
        {
        }

        public ExchangeModifiedPaymentForCraftMessage(bool onlySuccess, ObjectItemNotInContainer @object)
        {
            this.onlySuccess = onlySuccess;
            this.@object = @object;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(onlySuccess);
            @object.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            onlySuccess = reader.ReadBoolean();
            @object = new ObjectItemNotInContainer();
            @object.Deserialize(reader);
        }
    }
}