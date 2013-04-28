using System;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Net.Messages.Game.Character.Creation;
using Emulator.Game.Network;

namespace Emulator.Game.Approach.Character
{
    public class CharacterCreationManager
    {
        private readonly GameClient client;

        public CharacterCreationManager(GameClient client)
        {
            this.client = client;
            client.Dispatcher.Register(this);
        }

        [MessageHandler(CharacterNameSuggestionRequestMessage.ID)]
        public void HandleCharacterNameSuggestionRequestMessage(CharacterNameSuggestionRequestMessage message)
        {
            //todo
            client.Send(new CharacterNameSuggestionFailureMessage(0));
        }

        [MessageHandler(CharacterCreationRequestMessage.ID)]
        public void HandleCharacterCreationRequestMessage(CharacterCreationRequestMessage message)
        {
            Console.WriteLine(message);
        }
    }
}
