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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
    {
        public const uint ID = 6337;

        public override uint MessageId
        {
            get { return ID; }
        }


        public ExchangeBidHouseInListUpdatedMessage()
        {
        }

        public ExchangeBidHouseInListUpdatedMessage(int itemUID, int objGenericId, short powerRate, bool overMax, ObjectEffect[] effects, int[] prices)
                : base(itemUID, objGenericId, powerRate, overMax, effects, prices)
        {
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
        }
    }
}