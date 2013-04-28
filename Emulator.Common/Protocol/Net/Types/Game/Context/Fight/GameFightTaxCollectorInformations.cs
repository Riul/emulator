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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public const short ID = 48;

        public override short TypeId
        {
            get { return ID; }
        }

        public short FirstNameId { get; set; }
        public short LastNameId { get; set; }
        public short Level { get; set; }


        public GameFightTaxCollectorInformations()
        {
        }

        public GameFightTaxCollectorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, short firstNameId, short lastNameId, short level)
                : base(contextualId, look, disposition, teamId, alive, stats)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(FirstNameId);
            writer.WriteShort(LastNameId);
            writer.WriteShort(Level);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadShort();
            LastNameId = reader.ReadShort();
            Level = reader.ReadShort();
        }
    }
}