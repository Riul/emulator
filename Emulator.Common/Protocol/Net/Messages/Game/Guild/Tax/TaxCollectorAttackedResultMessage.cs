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
using Emulator.Common.Protocol.Net.Types.Game.Guild.Tax;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class TaxCollectorAttackedResultMessage : NetworkMessage
    {
        public const uint Id = 5635;

        public TaxCollectorBasicInformations basicInfos;
        public bool deadOrAlive;

        public override uint MessageId
        {
            get { return Id; }
        }


        public TaxCollectorAttackedResultMessage()
        {
        }

        public TaxCollectorAttackedResultMessage(bool deadOrAlive, TaxCollectorBasicInformations basicInfos)
        {
            this.deadOrAlive = deadOrAlive;
            this.basicInfos = basicInfos;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(deadOrAlive);
            basicInfos.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            deadOrAlive = reader.ReadBoolean();
            basicInfos = new TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
        }
    }
}