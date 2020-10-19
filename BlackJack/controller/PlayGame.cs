using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            view.UserChoice input = a_view.GetInput();

            if (view.UserChoice.PLAY.Equals(input))
            {
                a_game.NewGame();
            }
            else if (view.UserChoice.HIT.Equals(input))
            {
                a_game.Hit();
            }
            else if (view.UserChoice.STAND.Equals(input))
            {
                a_game.Stand();
            }

            return !view.UserChoice.QUIT.Equals(input);
        }
    }
}
