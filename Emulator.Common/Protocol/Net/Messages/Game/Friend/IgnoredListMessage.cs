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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Friend;

namespace Emulator.Common.Protocol.Net.Messages.Game.Friend
{
    public class IgnoredListMessage : NetworkMessage
    {
        public const uint ID = 5674;

        public override uint MessageId
        {
            get { return ID; }
        }

        public IgnoredInformations[] IgnoredList { get; set; }


        public IgnoredListMessage()
        {
        }

        public IgnoredListMessage(IgnoredInformations[] ignoredList)
        {
            IgnoredList = ignoredList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) IgnoredList.Length);
            foreach (var entry in IgnoredList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            IgnoredList = new IgnoredInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                IgnoredList[i] = Types.ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
                IgnoredList[i].Deserialize(reader);
            }
        }
    }
}