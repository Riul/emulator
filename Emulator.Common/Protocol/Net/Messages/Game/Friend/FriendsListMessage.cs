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
    public class FriendsListMessage : NetworkMessage
    {
        public const uint ID = 4002;

        public override uint MessageId
        {
            get { return ID; }
        }

        public FriendInformations[] FriendsList { get; set; }


        public FriendsListMessage()
        {
        }

        public FriendsListMessage(FriendInformations[] friendsList)
        {
            FriendsList = friendsList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) FriendsList.Length);
            foreach (var entry in FriendsList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            FriendsList = new FriendInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                FriendsList[i] = Types.ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
                FriendsList[i].Deserialize(reader);
            }
        }
    }
}