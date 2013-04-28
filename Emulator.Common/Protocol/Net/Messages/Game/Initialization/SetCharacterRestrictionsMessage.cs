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
using Emulator.Common.Protocol.Net.Types.Game.Character.Restriction;

namespace Emulator.Common.Protocol.Net.Messages.Game.Initialization
{
    public class SetCharacterRestrictionsMessage : NetworkMessage
    {
        public const uint ID = 170;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ActorRestrictionsInformations Restrictions { get; set; }


        public SetCharacterRestrictionsMessage()
        {
        }

        public SetCharacterRestrictionsMessage(ActorRestrictionsInformations restrictions)
        {
            Restrictions = restrictions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            Restrictions.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
        }
    }
}