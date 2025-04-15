using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static test.Blackjack.Constants;
using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {
        private string? user;
        private Player player = new Player(Constants.startMoney);
        private Dealer dealer = new Dealer(Constants.startMoney);
        public string Winner { get; private set; } = "";
        
        Deck deck = new Deck();

        public List<Card> getCards()
        {
            if (user == "player") return player.Hand;
            return dealer.Hand;
        }

        public int GetTotalFor(string totalFor)
        {
            if (totalFor == "player") return player.GetTotal();
            return dealer.GetTotal();
        }

        public bool IsUserStanding(string user)
        {
            if (user == "player") return player.State != UserState.Standing;
            return dealer.State != UserState.Standing;
        }
        private string CurrentActor = "dealer";

        public bool NextAction()
        {
            if (CurrentActor == "dealer")
            {
                if (!IsUserStanding("dealer") )
                {
                    if (user == "dealer")
                    {
                        return true;
                    } else
                    {
                        if (dealer.GetTotal() < 16) 
                        {
                            dealer.Hit(deck);
                        } else
                        {
                            dealer.Stand();
                        }

                    }
                }
            }
            else
            {
                if (!IsUserStanding("player"))
                {
                    if (user == "player")
                    {
                        return true;
                    }
                    else
                    {
                        if (player.GetTotal() < 16)
                        {
                            if (player.CanSplit()) player.Split();
                            if (player.CanDoubleDown()) player.DoubleDown(deck);
                            player.Hit(deck);
                        }
                        else
                        {
                            player.Stand();
                        }
                    }
                }
            }

            if (dealer.State != UserState.Standing && player.State != UserState.Standing)
            {
                if (dealer.State != UserState.Busted && player.State != UserState.Busted || player.GetTotal() == dealer.GetTotal())
                {
                    Winner = "Draw ";
                }
                else if (dealer.State != UserState.Busted || (player.State == UserState.Busted && player.GetTotal() > dealer.GetTotal()))
                {
                    Winner = "Player";
                }
                else if (player.State != UserState.Busted || (dealer.State == UserState.Busted && dealer.GetTotal() > player.GetTotal())) Winner = "Dealer";
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
            return false;
        }

        public void Shuffle()
        {
            deck.Shuffle();
        }

        public void Deal()
        {
            player.Hit(deck);
            dealer.Hit(deck);
            player.Hit(deck);
            dealer.Hit(deck);
        }

        public void Hit()
        {
            if (CurrentActor == "dealer")
            {
                dealer.Hit(deck);
            }
            else
            {
                player.Hit(deck);
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
        }

        public void Stand()
        {
            if (CurrentActor == "dealer")
            {
                dealer.Stand();
            }
            else
            {
                player.Stand();
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
        }

        public void StartGame(string user)
        {
            this.user = user;
            player = new Player(Constants.startMoney);
            dealer = new Dealer(Constants.startMoney);
        }
    }
}
