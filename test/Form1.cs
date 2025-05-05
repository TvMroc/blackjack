using Microsoft.VisualBasic.ApplicationServices;
using test.Blackjack;

namespace test
{
    public partial class Form1 : Form
    {
        Blackjack.Blackjack Game = new Blackjack.Blackjack { };
        private int players = 5;
        public bool Started = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void ShuffleDeckAnimation()
        {
            Image img = cardsImage.Image;
            for (int i = 0; i < Constants.Flips; i++)
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                cardsImage.Image = img;
                await Task.Delay(75);
            }
        }

        public void DealCheck()
        {
            Game.UpdateBusted();
            bool allPlayersDealt = true;

            for (int i = 0; i < players; i++)
            {
                if (Game.GetCardCount(i) != 2)
                {
                    allPlayersDealt = false;
                    break;
                }
            }

            if (allPlayersDealt && Game.GetCardCount(5) == 2)
            {
                dealerCards.BringToFront();
                shuffleButton.SendToBack();
                hitButton.BringToFront();
                standButton.BringToFront();
                GameLoop();
            }
            if ((Game.GetState(5) == Constants.UserState.Busted || Game.GetState(5) == Constants.UserState.Standing) && !(Game.GetState(0) == Constants.UserState.RequestingCard || Game.GetState(1) == Constants.UserState.RequestingCard || Game.GetState(2) == Constants.UserState.RequestingCard || Game.GetState(3) == Constants.UserState.RequestingCard || Game.GetState(4) == Constants.UserState.RequestingCard)) GameLoop();
            Render();
        }

        public void Render()
        {
            dealerCards.Items.Clear();
            foreach (Card card in Game.GetCards(5))
            {
                dealerCards.Items.Add(card.Label);
            }

            player1Label.Text = "Player";
            player2Label.Text = "Player";
            player3Label.Text = "Player";
            player4Label.Text = "Player";
            player5Label.Text = "Player";
            dealerLabel.Text = "Dealer";
            if (Game.GetState(0) == Constants.UserState.RequestingCard) player1Label.Text = "Deal player";
            if (Game.GetState(1) == Constants.UserState.RequestingCard) player2Label.Text = "Deal player";
            if (Game.GetState(2) == Constants.UserState.RequestingCard) player3Label.Text = "Deal player";
            if (Game.GetState(3) == Constants.UserState.RequestingCard) player4Label.Text = "Deal player";
            if (Game.GetState(4) == Constants.UserState.RequestingCard) player5Label.Text = "Deal player";
            if (Game.GetState(5) == Constants.UserState.RequestingCard) dealerLabel.Text = "Deal dealer";
            player1State.Text = Game.GetState(0).ToString();
            player2State.Text = Game.GetState(1).ToString();
            player3State.Text = Game.GetState(2).ToString();
            player4State.Text = Game.GetState(3).ToString();
            player5State.Text = Game.GetState(4).ToString();
            dealerState.Text = Game.GetState(5).ToString();
            player1CardLabel.Text = Game.GetCardCount(0).ToString() + " Cards";
            player2CardLabel.Text = Game.GetCardCount(1).ToString() + " Cards";
            player3CardLabel.Text = Game.GetCardCount(2).ToString() + " Cards";
            player4CardLabel.Text = Game.GetCardCount(3).ToString() + " Cards";
            player5CardLabel.Text = Game.GetCardCount(4).ToString() + " Cards";
            dealerCardLabel.Text = Game.GetCardCount(5).ToString() + " Cards";
            if (Game.Winners.Count > 0)
            {
                if (Game.GetTotalFor(0).ToString().Length > 0) player1CardLabel.Text = Game.GetCardCount(0).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(0).ToString();
                if (Game.GetTotalFor(1).ToString().Length > 0) player2CardLabel.Text = Game.GetCardCount(1).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(1).ToString();
                if (Game.GetTotalFor(2).ToString().Length > 0) player3CardLabel.Text = Game.GetCardCount(2).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(2).ToString();
                if (Game.GetTotalFor(3).ToString().Length > 0) player4CardLabel.Text = Game.GetCardCount(3).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(3).ToString();
                if (Game.GetTotalFor(4).ToString().Length > 0) player5CardLabel.Text = Game.GetCardCount(4).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(4).ToString();
                player1Label.Text = "Player " + Game.Winners[0];
                player2Label.Text = "Player " + Game.Winners[1];
                player3Label.Text = "Player " + Game.Winners[2];
                player4Label.Text = "Player " + Game.Winners[3];
                player5Label.Text = "Player " + Game.Winners[4];


                for (int i = 0; i < players; i++)
                {
                    var playerCards = Controls.Find($"player{i + 1}Cards", true).FirstOrDefault() as ListBox;
                    if (playerCards != null)
                    {
                        playerCards.BringToFront();
                        playerCards.Items.Clear();
                        foreach (Card card in Game.GetCards(i))
                        {
                            playerCards.Items.Add(card.Label);
                        }
                    }
                }
            }
            if (Game.GetTotalFor(5).ToString().Length > 0) dealerCardLabel.Text = Game.GetCardCount(5).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(5).ToString();
        }

        public void GameLoop()
        {
            if (Game.Winners.Count > 0)
            {
                restartButton.BringToFront();
                return;
            }
            if (!Game.NextAction())
            {
                GameLoop();
                Render();
                return;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!Started)
            {
                Game.StartGame(5, players);
                Started = true;
                shuffleButton.BringToFront();
                cardsImage.BringToFront();
                player1CardLabel.BringToFront();
                player2CardLabel.BringToFront();
                player3CardLabel.BringToFront();
                player4CardLabel.BringToFront();
                player5CardLabel.BringToFront();
                dealerCardLabel.BringToFront();
                startButton.SendToBack();
                Game.Dealing();
                Render();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            restartButton.SendToBack();
            Started = false;
            startButton.Text = "Start";
            player1Label.Text = "Player";
            player2Label.Text = "Player";
            player3Label.Text = "Player";
            player4Label.Text = "Player";
            player5Label.Text = "Player";
            player1State.Text = "state";
            player2State.Text = "state";
            player3State.Text = "state";
            player4State.Text = "state";
            player5State.Text = "state";
            dealerState.Text = "state";
            player1CardLabel.Text = "0 cards";
            player2CardLabel.Text = "0 cards";
            player3CardLabel.Text = "0 cards";
            player4CardLabel.Text = "0 cards";
            player5CardLabel.Text = "0 cards";
            dealerCardLabel.Text = "0 cards";
            startButton.BringToFront();
            player1Cards.SendToBack();
            player2Cards.SendToBack();
            player3Cards.SendToBack();
            player4Cards.SendToBack();
            player5Cards.SendToBack();
            dealerCards.SendToBack();
            player1CardLabel.SendToBack();
            player2CardLabel.SendToBack();
            player3CardLabel.SendToBack();
            player4CardLabel.SendToBack();
            player5CardLabel.SendToBack();
            dealerCardLabel.SendToBack();
            cardsImage.SendToBack();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < players; i++)
            {
                if (Game.GetState(i) == Constants.UserState.RequestingCard) return;
            }
            Game.Hit();
            Render();
            GameLoop();
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < players; i++)
            {
                if (Game.GetState(i) == Constants.UserState.RequestingCard) return;
            }
            Game.Stand();

            Render();
            hitButton.SendToBack();
            standButton.SendToBack();
            GameLoop();
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            Game.Shuffle();
            ShuffleDeckAnimation();
        }
        private void Label_Click(object sender, int userIndex)
        {
            if (Started && Game.GetState(userIndex) == Constants.UserState.RequestingCard) Game.Deal(userIndex);
            DealCheck();
        }
    }
}
