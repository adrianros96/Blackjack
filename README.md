### TODO

1. Implement Game::Stand - look at sequence diagram -> then game is playable - DONE


2. Remove bad hidden dependency between controller/view -> about new game, hit and stand - DONE


3. Check the Ace value functionality - DONE


4. RULESET hard/soft, values, types, ranks - DONE


5. Look for duplicate code against DRY - 

The code for getting a card from the deck, show the card and give it to a player is duplicated in a number of places. Make a refactoring to remove this duplication and that supports low coupling/high cohesion (i.e. check how you can evaluate different solutions to the problem and select the one that gives the best result according to low coupling/high cohesion). The code that is duplicated is similar to this:

        Card c = deck.GetCard();
        c.Show(true/false)
        player.DealCard(c);


6. Observer pattern - DONE
6,1. - As we look at the above implementation we can see that Observer and Subject know about each other, 
which means to some extent they are coupled (not completely loosely coupled). To overcome this problem, 
.NET Framework provides a generic System.IObservable<T> and System.IObserver<T> interfaces which can be -> 
-> implemented by Subject and Observer to apply Observer pattern.



Added: 
SoftHitStrategy.cs
checkAces - function - Player
getInput function in Simple & Swedish view.
Enum UserChoice added for getInput and the hidden dependencies between controller and view.

