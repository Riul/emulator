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
using Emulator.Common.Protocol.Net.Types.Game.Guild.Tax;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class TaxCollectorMovementMessage : NetworkMessage
    {
        public const uint ID = 5633;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool HireOrFire { get; set; }
        public TaxCollectorBasicInformations BasicInfos { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }


        public TaxCollectorMovementMessage()
        {
        }

        public TaxCollectorMovementMessage(bool hireOrFire, TaxCollectorBasicInformations basicInfos, int playerId, string playerName)
        {
            HireOrFire = hireOrFire;
            BasicInfos = basicInfos;
            PlayerId = playerId;
            PlayerName = playerName;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(HireOrFire);
            BasicInfos.Serialize(writer);
            writer.WriteInt(PlayerId);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            HireOrFire = reader.ReadBoolean();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            PlayerId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
        }
    }
}