using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static test.Blackjack.Constants;
using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {
        private int user = 5;

        private List<Player> players = [new Player(Constants.startMoney, "player")];
        private Dealer dealer = new Dealer(Constants.startMoney, "dealer");
        private int CurrentPlayer = 0;
        public List<string> Winners { get; private set; } = [];

        Deck deck = new Deck();

        private User GetUser(int i)
        {
            if (i == 5) return dealer;
            return players[i];
        }

        public string GetName(int user)
        {
            return GetUser(user).Name;
        }

        public List<Card> GetCards(int user)
        {
            if (Winners.Count > 0 || this.user == user) return GetUser(user).Hand;
            return new List<Card> { };
        }

        public int GetCardCount(int user)
        {
            return GetUser(user).Hand.Count;
        }
        public int GetTotalFor(int user)
        {
            if (Winners.Count > 0 || this.user ==user) return GetUser(user).GetTotal();
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
                if (dealer.State != UserState.Standing && dealer.State != UserState.Busted || players.Any(player => player.State == UserState.RequestingCard))
                {
                    if (user == 5)
                    {
                        return true;
                    }
                    else
                    {
                        if (dealer.GetTotal() < 16)
                        {
                            dealer.SetState(UserState.RequestingCard);
                        }
                        else
                        {
                            dealer.Stand();
                        }
                    }
                }
            }
            else
            {
                if (players[CurrentPlayer].State != UserState.Standing && players[CurrentPlayer].State != UserState.Busted && players[CurrentPlayer].State != UserState.RequestingCard)
                {
                    if (user == CurrentPlayer)
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

            bool allStandingOrBusted = dealer.State == UserState.Standing || dealer.State == UserState.Busted;
            foreach (var player in players)
            {
                if (player.State != UserState.Standing && player.State != UserState.Busted)
                {
                    allStandingOrBusted = false;
                    break;
                }
            }

            if (allStandingOrBusted) FindWinners();

            CycleActor();
            return false;
        }

        private void FindWinners()
        {
            for (int i = 0; i < players.Count; i++)
            {
                var player = players[i];
                if ((dealer.State == UserState.Standing || dealer.State == UserState.Busted) && (player.State == UserState.Standing || player.State == UserState.Busted))
                {
                    if ((dealer.State == UserState.Busted && player.State == UserState.Busted) ||
                        (player.GetTotal() == dealer.GetTotal()))
                    {
                        Winners.Add("Draw");
                    }
                    else if (dealer.State == UserState.Busted && player.State != UserState.Busted ||
                             player.State != UserState.Busted && player.GetTotal() > dealer.GetTotal())
                    {
                        Winners.Add("Won");
                    }
                    else if (player.State == UserState.Busted && dealer.State != UserState.Busted ||
                             dealer.State != UserState.Busted && dealer.GetTotal() > player.GetTotal())
                    {
                        Winners.Add("Lost");
                    }
                }
            }
        }

        public void CycleActor()
        {
            if (CurrentActor == "dealer")
            {
                CurrentActor = "player";
                CurrentPlayer = 0;
            }
            else if (CurrentPlayer >= players.Count - 1)
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

        public void StartGame(int user, int playerCount, List<string> names)
        {
            Winners = [ ];
            this.user = user;
            deck = new Deck();
            players = [new Player(Constants.startMoney, names[1])];
            dealer = new Dealer(Constants.startMoney, names[0]);
            CurrentActor = "dealer";
            CurrentPlayer = 0;

            if (playerCount > 5) playerCount = 5;
            if (playerCount < 1) playerCount = 1;
            for (int i = 1; i < playerCount; i++)
            {
                players.Add(new Player(Constants.startMoney, names[i+1]));
            }
        }
    }
}
