using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory 
    {
        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
        }

        public IHitStrategy SoftHitRule() 
        {
            return new SoftHitStrategy();
        }

        public IDecidingWinnerStrategy GetGameWinnerRule()
        {
            // return new DealerEqualsRule();
            return new PlayerEqualsRule();
        }

        public INewGameStrategy GetNewGameRule()
        {
            // return new InternationalNewGameStrategy();
            return new AmericanNewGameStrategy();
        }
    }
}
