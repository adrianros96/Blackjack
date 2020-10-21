using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : IObserver
    {
        private model.Game c_game;
        private view.IView c_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            c_game = a_game;
            c_view = a_view;
            c_game.AddSubscriber(this);
        }

        public void RenderGame()
        {
            c_view.DisplayWelcomeMessage();
            
            c_view.DisplayDealerHand(c_game.GetDealerHand(), c_game.GetDealerScore());
            c_view.DisplayPlayerHand(c_game.GetPlayerHand(), c_game.GetPlayerScore());

            if (c_game.IsGameOver())
            {
                c_view.DisplayGameOver(c_game.IsDealerWinner());
            }
        }

        public void Update(model.Card a_card) {
            Console.WriteLine("Dealing card...");
            // Thread.Sleep();
        }

        public bool Play()
        {
            RenderGame();

            view.UserChoice input = c_view.GetInput();

            if (view.UserChoice.PLAY.Equals(input))
            {
                c_game.NewGame();
            }
            else if (view.UserChoice.HIT.Equals(input))
            {
                c_game.Hit();
            }
            else if (view.UserChoice.STAND.Equals(input))
            {
                c_game.Stand();
            }

            return !view.UserChoice.QUIT.Equals(input);
        }
    }
}
