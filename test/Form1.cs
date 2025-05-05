using Microsoft.VisualBasic.ApplicationServices;
using test.Blackjack;

namespace test
{
    public partial class Form1 : Form
    {
        Blackjack.Blackjack Game = new Blackjack.Blackjack { };
        private int players = 1;
        public bool Started = false;

        public Form1()
        {
            InitializeComponent();
            playerCountInput.Text = players.ToString();
            player1Label.Click += (s, e) => Label_Click(s, 0);
            player2Label.Click += (s, e) => Label_Click(s, 1);
            player3Label.Click += (s, e) => Label_Click(s, 2);
            player4Label.Click += (s, e) => Label_Click(s, 3);
            player5Label.Click += (s, e) => Label_Click(s, 4);
            dealerLabel.Click += (s, e) => Label_Click(s, 5);
            UpdateUsers();
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

            bool anyPlayerRequestingCard = false;
            for (int i = 0; i < players; i++)
            {
                if (Game.GetState(i) == Constants.UserState.RequestingCard)
                {
                    anyPlayerRequestingCard = true;
                    break;
                }
            }

            if ((Game.GetState(5) == Constants.UserState.Busted || Game.GetState(5) == Constants.UserState.Standing) && !anyPlayerRequestingCard) GameLoop();
            Render();
        }

        public void Render()
        {
            dealerLabel.Text = Game.GetName(5);
            if (Game.GetState(5) == Constants.UserState.RequestingCard) dealerLabel.Text = "Deal " + Game.GetName(5);
            dealerState.Text = Game.GetState(5).ToString();
            dealerCardLabel.Text = Game.GetCardCount(5).ToString() + " Cards";

            for (int i = 0; i < players; i++)
            {
                var playerLabel = Controls.Find($"player{i + 1}Label", true).FirstOrDefault() as Label;
                var playerState = Controls.Find($"player{i + 1}State", true).FirstOrDefault() as Label;
                var playerCardLabel = Controls.Find($"player{i + 1}CardLabel", true).FirstOrDefault() as Label;

                playerLabel.Text = Game.GetName(i);
                if (Game.GetState(i) == Constants.UserState.RequestingCard) playerLabel.Text = "Deal " + Game.GetName(i);
                playerState.Text = Game.GetState(i).ToString();
                playerCardLabel.Text = Game.GetCardCount(i).ToString() + " Cards";
            }

            dealerCards.Items.Clear();
            foreach (Card card in Game.GetCards(5))
            {
                dealerCards.Items.Add(card.Label);
            }

            if (Game.Winners.Count > 0)
            {
                for (int i = 0; i < players; i++)
                {
                    var playerLabel = Controls.Find($"player{i + 1}Label", true).FirstOrDefault() as Label;
                    var playerCards = Controls.Find($"player{i + 1}Cards", true).FirstOrDefault() as ListBox;
                    var playerCardLabel = Controls.Find($"player{i + 1}CardLabel", true).FirstOrDefault() as Label;
                    var splitCards = Controls.Find($"player{i + 1}SplitCards", true).FirstOrDefault() as ListBox;
                    var splitLabel = Controls.Find($"player{i + 1}SplitLabel", true).FirstOrDefault() as Label;
                    var total = Game.GetTotal(i);

                    if (total.ToString().Length > 0) playerCardLabel.Text = Game.GetCardCount(i).ToString() + " Cards" + ", Total: " + total.ToString();

                    foreach (Card card in Game.GetCards(i))
                    {
                        playerLabel.Text = Game.GetName(i) + " " + Game.Winners[i];
                    }
                    playerCards.BringToFront();
                    playerCards.Items.Clear();
                    foreach (Card card in Game.GetCards(i))
                    {
                        playerCards.Items.Add(card.Label);
                    }

                    splitCards.SendToBack();
                    splitLabel.SendToBack();
                    if (Game.HasSplit(i))
                    {
                        splitCards.BringToFront();
                        splitCards.Items.Clear();
                        foreach (Card card in Game.GetSplitCards(i))
                        {
                            splitCards.Items.Add(card.Label);
                        }

                        int splitTotal = Game.GetSplitTotal(i);
                        splitLabel.BringToFront();
                        splitLabel.Text = "Split: " + splitTotal.ToString();
                    }
                }
            }
            if (Game.GetTotal(5).ToString().Length > 0) dealerCardLabel.Text = Game.GetCardCount(5).ToString() + " Cards" + ", Total: " + Game.GetTotal(5).ToString();
        }

        public void GameLoop()
        {
            if (Game.Winners.Count > 0)
            {
                restartButton.BringToFront();
                hitButton.SendToBack();
                standButton.SendToBack();
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
                HideNameInputs();
                Game.StartGame(5, players, [dealerNameInput.Text, player1NameInput.Text, player2NameInput.Text, player3NameInput.Text, player4NameInput.Text, player5NameInput.Text]);
                Started = true;
                shuffleButton.BringToFront();
                cardsImage.BringToFront();
                for (int i = 0; i < players; i++)
                {
                    var playerCardLabel = Controls.Find($"player{i + 1}CardLabel", true).FirstOrDefault() as Label;
                    playerCardLabel.BringToFront();
                }
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
            Started = false;
            restartButton.SendToBack();
            startButton.BringToFront();

            for (int i = 0; i < players; i++)
            {
                var playerLabel = Controls.Find($"player{i + 1}Label", true).FirstOrDefault() as Label;
                var playerState = Controls.Find($"player{i + 1}State", true).FirstOrDefault() as Label;
                var playerCardLabel = Controls.Find($"player{i + 1}CardLabel", true).FirstOrDefault() as Label;
                var playerCards = Controls.Find($"player{i + 1}Cards", true).FirstOrDefault() as ListBox;
                playerLabel.Text = "Player";
                playerState.Text = "state";
                playerCardLabel.Text = "0 cards";
                playerCardLabel.SendToBack();
                playerCards.SendToBack();
            }
            dealerState.Text = "state";
            dealerCardLabel.Text = "0 cards";
            dealerCards.SendToBack();
            dealerCardLabel.SendToBack();
            cardsImage.SendToBack();
            UpdateUsers();
            DealerNameLabel.BringToFront();
            playerCountLabel.BringToFront();
            dealerNameInput.BringToFront();
            playerCountInput.BringToFront();
            NamesLabel.BringToFront();
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

        private void playerCountInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void playerCountInput_KeyUp(object sender, EventArgs e)
        {
            Max5Min1UpdateCount();
        }

        private void playerCountInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Max5Min1UpdateCount()
        {
            if (int.TryParse(playerCountInput.Text, out int value))
            {
                if (value < 1)
                    value = 1;
                else if (value > 5)
                    value = 5;

                playerCountInput.Text = value.ToString();
                players = value;
                UpdateUsers();
            }
            else
            {
                playerCountInput.Text = string.Empty;
            }
        }

        private void UpdateUsers()
        {
            for (int i = 0; i < 5; i++)
            {
                var playerLabel = Controls.Find($"player{i + 1}Label", true).FirstOrDefault() as Label;
                var playerState = Controls.Find($"player{i + 1}State", true).FirstOrDefault() as Label;
                var playerCardLabel = Controls.Find($"player{i + 1}CardLabel", true).FirstOrDefault() as Label;
                var playerNameInput = Controls.Find($"player{i + 1}NameInput", true).FirstOrDefault() as TextBox;
                playerLabel.SendToBack();
                playerState.SendToBack();
                playerCardLabel.SendToBack();
                playerNameInput.SendToBack();
            }

            for (int i = 0; i < players; i++)
            {
                var playerLabel = Controls.Find($"player{i + 1}Label", true).FirstOrDefault() as Label;
                var playerState = Controls.Find($"player{i + 1}State", true).FirstOrDefault() as Label;
                var playerCardLabel = Controls.Find($"player{i + 1}CardLabel", true).FirstOrDefault() as Label;
                var playerNameInput = Controls.Find($"player{i + 1}NameInput", true).FirstOrDefault() as TextBox;
                playerLabel.BringToFront();
                playerState.BringToFront();
                playerCardLabel.BringToFront();
                playerNameInput.BringToFront(); 
            }
        }
        private void HideNameInputs()
        {
            for (int i = 0; i < 5; i++)
            {
                var playerNameInput = Controls.Find($"player{i + 1}NameInput", true).FirstOrDefault() as TextBox;
                playerNameInput.SendToBack();
            }
            DealerNameLabel.SendToBack();
            playerCountLabel.SendToBack();
            dealerNameInput.SendToBack();
            playerCountInput.SendToBack();
            NamesLabel.SendToBack();
        }
    }
}
