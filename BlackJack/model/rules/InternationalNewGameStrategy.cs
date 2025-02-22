﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_dealer.DealerDealsCard(a_deck, a_player, true);
            a_dealer.DealerDealsCard(a_deck, a_dealer, true);
            a_dealer.DealerDealsCard(a_deck, a_player, true);

            return true;
        }
    }
}
