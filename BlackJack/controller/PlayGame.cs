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
        // public void RenderGame(model.Game a_game, view.IView a_view)
        // {
        //     a_view.DisplayWelcomeMessage();
            
        //     a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
        //     a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
        //     a_game.AddSubscriber();

        //     if (a_game.IsGameOver())
        //     {
        //         a_view.DisplayGameOver(a_game.IsDealerWinner());
        //     }
        // }
        public void Update(model.Card a_card) {
            Console.WriteLine("Sleep for 2 seconds.");
            Thread.Sleep(2000);
        }

        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
            a_game.AddSubscriber(this);

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
               // a_view.Pause();
            }
            else if (view.UserChoice.STAND.Equals(input))
            {
                a_game.Stand();
            }

            return !view.UserChoice.QUIT.Equals(input);
        }
    }
}
