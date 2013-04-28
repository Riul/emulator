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
using Emulator.Common.Protocol.Net.Types.Game.Actions.Fight;

namespace Emulator.Common.Protocol.Net.Types.Game.Action.Fight
{
    public class FightDispellableEffectExtendedInformations
    {
        public const short ID = 208;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short ActionId { get; set; }
        public int SourceId { get; set; }
        public AbstractFightDispellableEffect Effect { get; set; }


        public FightDispellableEffectExtendedInformations()
        {
        }

        public FightDispellableEffectExtendedInformations(short actionId, int sourceId, AbstractFightDispellableEffect effect)
        {
            ActionId = actionId;
            SourceId = sourceId;
            Effect = effect;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ActionId);
            writer.WriteInt(SourceId);
            writer.WriteShort(Effect.TypeId);
            Effect.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ActionId = reader.ReadShort();
            SourceId = reader.ReadInt();
            Effect = Types.ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadShort());
            Effect.Deserialize(reader);
        }
    }
}