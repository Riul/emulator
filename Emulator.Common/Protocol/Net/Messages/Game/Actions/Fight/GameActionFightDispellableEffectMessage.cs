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
using Emulator.Common.Protocol.Net.Types.Game.Actions.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public const uint Id = 6070;

        public AbstractFightDispellableEffect effect;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameActionFightDispellableEffectMessage()
        {
        }

        public GameActionFightDispellableEffectMessage(short actionId, int sourceId, AbstractFightDispellableEffect effect)
            : base(actionId, sourceId)
        {
            this.effect = effect;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(effect.TypeId);
            effect.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            effect = Types.ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadShort());
            effect.Deserialize(reader);
        }
    }
}