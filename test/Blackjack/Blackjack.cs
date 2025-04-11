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

        public void NextAction()
        {
            if (CurrentActor == "dealer")
            {
                if (IsUserStanding("dealer") )
                {

                }
                else
                {
                    CurrentActor = "player";
                }
            }
            else
            {

                if (IsUserStanding("player"))
                {

                }
                else
                {
                    CurrentActor = "dealer";
                }
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
        }

        public void StartGame(string user)
        {
            this.user = user;
            player = new Player(500);
            dealer = new Dealer(500);

            deck = new Deck();
            for (int i = 0; i < Constants.DeckShuffles; i++)
            {
                deck.Shuffle();
            }
            player.Hit(deck);
            dealer.Hit(deck);
            player.Hit(deck);
            dealer.Hit(deck);

            while (dealer.GetTotal() < 16)
            {
                dealer.Hit(deck);
            }
            while (player.GetTotal() < 16)
            {
                if (player.CanSplit()) player.Split();
                if (player.CanDoubleDown()) player.DoubleDown(deck);
                player.Hit(deck);
            }
            while (player.HasSplit && player.GetTotal(true) < 16)
            {
                player.Hit(deck, true);
            }
            if (player.GetTotal() >= 16) player.Stand();
            if (dealer.GetTotal() >= 16) dealer.Stand();

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
        }
    }
}
