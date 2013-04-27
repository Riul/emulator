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
using Emulator.Common.Protocol.Net.Types.Game.Friend;

namespace Emulator.Common.Protocol.Net.Messages.Game.Friend
{
    public class IgnoredAddedMessage : NetworkMessage
    {
        public const uint Id = 5678;

        public IgnoredInformations ignoreAdded;
        public bool session;

        public override uint MessageId
        {
            get { return Id; }
        }


        public IgnoredAddedMessage()
        {
        }

        public IgnoredAddedMessage(IgnoredInformations ignoreAdded, bool session)
        {
            this.ignoreAdded = ignoreAdded;
            this.session = session;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ignoreAdded.TypeId);
            ignoreAdded.Serialize(writer);
            writer.WriteBoolean(session);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ignoreAdded = Types.ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
            ignoreAdded.Deserialize(reader);
            session = reader.ReadBoolean();
        }
    }
}