using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
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
            if (totalFor == "dealer") return dealer.GetTotal();
            return 0;
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

            if (dealer.Standing && player.Standing)
            {
                if (dealer.Busted() && player.Busted() || player.GetTotal() == dealer.GetTotal())
                {
                    Winner = "Draw ";
                }
                else if (dealer.Busted() || (!player.Busted() && player.GetTotal() > dealer.GetTotal()))
                {
                    Winner = "Player";
                }
                else if (player.Busted() || (!dealer.Busted() && dealer.GetTotal() > player.GetTotal())) Winner = "Dealer";
            }
        }
    }
}
