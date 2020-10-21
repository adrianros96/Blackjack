using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
        

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_softRule;
        
        private rules.IDecidingWinnerStrategy m_winnerRule;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_softRule = a_rulesFactory.SoftHitRule();
            m_winnerRule = a_rulesFactory.GetGameWinnerRule();
        }


        // TODO fix dry
        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;
            }
            return false;
        }
        // TODO fix dry
        public bool Stand() {
            if(m_deck != null)
            {
                ShowHand();
                foreach (Card card in this.GetHand())
                {
                    GetHand();
                    card.Show(true);
                }

                while (m_softRule.DoHit(this))
                {
                    m_softRule.DoHit(this);
                    Card card = m_deck.GetCard();
                    card.Show(true);
                    DealCard(card);
                }
                return true;
            } 
            return false;
        }

        public void DealerDealsCard(Deck a_deck, Player a_player, bool show) {
            Card c;
            c = a_deck.GetCard();
            c.Show(show);
            a_player.DealCard(c);
        }

        public bool IsDealerWinner(Player a_player)
        {
           return m_winnerRule.IsDealerWinner(this, a_player, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_softRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
