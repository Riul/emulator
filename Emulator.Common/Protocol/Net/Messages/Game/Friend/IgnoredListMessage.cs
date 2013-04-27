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
    public class IgnoredListMessage : NetworkMessage
    {
        public const uint Id = 5674;

        public IgnoredInformations[] ignoredList;

        public override uint MessageId
        {
            get { return Id; }
        }


        public IgnoredListMessage()
        {
        }

        public IgnoredListMessage(IgnoredInformations[] ignoredList)
        {
            this.ignoredList = ignoredList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ignoredList.Length);
            foreach (var entry in ignoredList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ignoredList = new IgnoredInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                ignoredList[i] = Types.ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
                ignoredList[i].Deserialize(reader);
            }
        }
    }
}