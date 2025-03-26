using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {

        public Player player = new Player(500);
        public Dealer dealer = new Dealer(500);
        Deck deck = new Deck();
        public string Winner { get; private set; } = "";

        public void StartGame()
        {
            deck.Shuffle(4);
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
                if (dealer.Busted() && player.Busted())
                {
                    Winner = "No one";
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
