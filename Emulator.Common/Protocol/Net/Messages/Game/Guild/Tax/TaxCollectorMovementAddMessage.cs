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
    public class TaxCollectorMovementAddMessage : NetworkMessage
    {
        public const uint Id = 5917;

        public TaxCollectorInformations informations;


        public TaxCollectorMovementAddMessage()
        {
        }

        public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
        {
            this.informations = informations;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(informations.TypeId);
            informations.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            informations = Types.ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
            informations.Deserialize(reader);
        }
    }
}