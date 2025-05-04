using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static test.Blackjack.Constants;
using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {
        private int user = 5;

        private Player[] players = [new Player(Constants.startMoney)];
        private Dealer dealer = new Dealer(Constants.startMoney);
        private int CurrentPlayer = 0;
        public string Winner { get; private set; } = "";

        Deck deck = new Deck();

        private User GetUser(int i)
        {
            if (i == 5) return dealer;
            return players[i];
        }

        public List<Card> GetCards(int user)
        {
            if (Winner != "" || this.user == user) return GetUser(user).Hand;
            return new List<Card> { };
        }

        public int GetCardCount(int user)
        {
            return GetUser(user).Hand.Count;
        }
        public int GetTotalFor(int user)
        {
            if (Winner != "" || this.user ==user) return GetUser(user).GetTotal();
            return 0;
        }

        private string CurrentActor = "dealer";

        public void UpdateBusted()
        {
            foreach (Player player in players)
            {
                if (player.GetTotal() > 21) player.SetState(UserState.Busted);
            }
            if (dealer.GetTotal() > 21) dealer.SetState(UserState.Busted);
        }

        public bool NextAction()
        {
            if (CurrentActor == "dealer")
            {
                if (dealer.State != UserState.Standing )
                {
                    if (user == 5 && dealer.State != UserState.Busted && dealer.State != UserState.Standing)
                    {
                        return true;
                    } else
                    {
                        if (dealer.GetTotal() < 16) 
                        {
                            dealer.SetState(UserState.RequestingCard);
                        } else
                        {
                            dealer.Stand();
                        }

                    }
                }
            }
            else
            {
                if (players[CurrentPlayer].State != UserState.Standing)
                {
                    if (user != 5 && players[CurrentPlayer].State != UserState.Busted && players[CurrentPlayer].State != UserState.Standing)
                    {
                        return true;
                    }
                    else
                    {
                        if (players[CurrentPlayer].GetTotal() < 16)
                        {
                            if (players[CurrentPlayer].CanSplit()) players[CurrentPlayer].Split();
                            if (players[CurrentPlayer].CanDoubleDown()) players[CurrentPlayer].DoubleDown(deck);
                            players[CurrentPlayer].SetState(UserState.RequestingCard);
                        }
                        else
                        {
                            players[CurrentPlayer].Stand();
                        }
                    }
                }
            }
            if ((dealer.State == UserState.Standing || dealer.State == UserState.Busted) && (players[CurrentPlayer].State == UserState.Standing || players[CurrentPlayer].State == UserState.Busted))
            {
                if ((dealer.State == UserState.Busted && players[CurrentPlayer].State == UserState.Busted) || (players[CurrentPlayer].GetTotal() == dealer.GetTotal()))
                {
                    Winner = "Draw ";
                }
                else if (dealer.State == UserState.Busted && players[CurrentPlayer].State != UserState.Busted || players[CurrentPlayer].State != UserState.Busted && players[CurrentPlayer].GetTotal() > dealer.GetTotal())
                {
                    Winner = "Player";
                }
                else if (players[CurrentPlayer].State == UserState.Busted && dealer.State != UserState.Busted || dealer.State != UserState.Busted && dealer.GetTotal() > players[CurrentPlayer].GetTotal()) Winner = "Dealer";
            }
            CycleActor();
            return false;
        }

        public void CycleActor()
        {
            if (CurrentActor == "dealer")
            {
                CurrentActor = "player";
                CurrentPlayer = 0;
            }
            else if (CurrentPlayer >= players.Length - 1)
            {
                CurrentActor = "dealer";
            }
            else { CurrentPlayer++; }
        }

        public UserState GetState(int user)
        {
            return GetUser(user).State;
        }

        public void Shuffle()
        {
            deck.Shuffle();
        }

        public void Deal(int user)
        {
            GetUser(user).Hit(deck);
        }

        public void Dealing()
        {
            dealer.SetState(UserState.RequestingCard);
            foreach (Player player in players)
            {
                player.SetState(UserState.RequestingCard);
            }
        }

        public void Hit()
        {
            if (CurrentActor == "dealer")
            {
                if (dealer.State != UserState.Standing && dealer.State != UserState.Busted) dealer.SetState(UserState.RequestingCard);
            }
            else
            {
                if (players[CurrentPlayer].State != UserState.Standing && players[CurrentPlayer].State != UserState.Busted) players[CurrentPlayer].SetState(UserState.RequestingCard);
            }
            CycleActor();
        }

        public void Stand()
        {
            if (CurrentActor == "dealer")
            {
                if (dealer.State != UserState.Busted) dealer.Stand();
            }
            else
            {
                if (players[CurrentPlayer].State != UserState.Busted) players[CurrentPlayer].Stand();
            }
            CycleActor();
        }

        public void StartGame(int user, int playerCount)
        {
            Winner = "";
            this.user = user;
            deck = new Deck();
            players = [new Player(Constants.startMoney)];
            dealer = new Dealer(Constants.startMoney);

            if (playerCount > 5) playerCount = 5;
            for (int i = 1; i > playerCount; i++)
            {
                players.Append(new Player(Constants.startMoney));
            }
        }
    }
}
