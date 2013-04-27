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
    public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
    {
        public const uint Id = 5999;

        public ObjectItemNotInContainer objectInfo;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeCraftResultWithObjectDescMessage()
        {
        }

        public ExchangeCraftResultWithObjectDescMessage(sbyte craftResult, ObjectItemNotInContainer objectInfo)
            : base(craftResult)
        {
            this.objectInfo = objectInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            objectInfo.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            objectInfo = new ObjectItemNotInContainer();
            objectInfo.Deserialize(reader);
        }
    }
}