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
using Emulator.Common.Protocol.Net.Types.Game.Paddock;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildPaddockBoughtMessage : NetworkMessage
    {
        public const uint ID = 5952;

        public override uint MessageId
        {
            get { return ID; }
        }

        public PaddockContentInformations PaddockInfo { get; set; }


        public GuildPaddockBoughtMessage()
        {
        }

        public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
        {
            PaddockInfo = paddockInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            PaddockInfo.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PaddockInfo = new PaddockContentInformations();
            PaddockInfo.Deserialize(reader);
        }
    }
}