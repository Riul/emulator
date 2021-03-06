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

namespace Emulator.Common.Protocol.Net.Messages.Game.Achievement
{
    public class AchievementFinishedInformationMessage : AchievementFinishedMessage
    {
        public const uint ID = 6381;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Name { get; set; }
        public int PlayerId { get; set; }


        public AchievementFinishedInformationMessage()
        {
        }

        public AchievementFinishedInformationMessage(short id, short finishedlevel, string name, int playerId)
                : base(id, finishedlevel)
        {
            Name = name;
            PlayerId = playerId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteInt(PlayerId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            PlayerId = reader.ReadInt();
        }
    }
}