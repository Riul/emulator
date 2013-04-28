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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightOptionsInformations
    {
        public const short ID = 20;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public bool IsSecret { get; set; }
        public bool IsRestrictedToPartyOnly { get; set; }
        public bool IsClosed { get; set; }
        public bool IsAskingForHelp { get; set; }


        public FightOptionsInformations()
        {
        }

        public FightOptionsInformations(bool isSecret, bool isRestrictedToPartyOnly, bool isClosed, bool isAskingForHelp)
        {
            IsSecret = isSecret;
            IsRestrictedToPartyOnly = isRestrictedToPartyOnly;
            IsClosed = isClosed;
            IsAskingForHelp = isAskingForHelp;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, IsSecret);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, IsRestrictedToPartyOnly);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, IsClosed);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, IsAskingForHelp);
            writer.WriteByte(flag1);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            IsSecret = BooleanByteWrapper.GetFlag(flag1, 0);
            IsRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag1, 1);
            IsClosed = BooleanByteWrapper.GetFlag(flag1, 2);
            IsAskingForHelp = BooleanByteWrapper.GetFlag(flag1, 3);
        }
    }
}