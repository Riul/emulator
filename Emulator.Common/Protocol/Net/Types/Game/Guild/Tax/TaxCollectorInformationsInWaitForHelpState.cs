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
// Created on 26/04/2013 at 16:46
#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class TaxCollectorInformationsInWaitForHelpState : TaxCollectorInformations
    {
        public const short Id = 166;

        public ProtectedEntityWaitingForHelpInfo waitingForHelpInfo;

        public override short TypeId
        {
            get { return Id; }
        }


        public TaxCollectorInformationsInWaitForHelpState()
        {
        }

        public TaxCollectorInformationsInWaitForHelpState(int uniqueId, short firtNameId, short lastNameId, AdditionalTaxCollectorInformations additionalInfos, short worldX, short worldY, short subAreaId, sbyte state, EntityLook look, int kamas, double experience, int pods, int itemsValue, ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
            : base(uniqueId, firtNameId, lastNameId, additionalInfos, worldX, worldY, subAreaId, state, look, kamas, experience, pods, itemsValue)
        {
            this.waitingForHelpInfo = waitingForHelpInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            waitingForHelpInfo.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            waitingForHelpInfo.Deserialize(reader);
        }
    }
}