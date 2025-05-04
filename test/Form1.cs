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
        }

        private async void ShuffleDeckAnimation()
        {
            Image img = pictureBox2.Image;
            for (int i = 0; i < Constants.Flips; i++)
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox2.Image = img;
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
                listBox1.BringToFront();
                button5.SendToBack();
                GameLoop();
            }

            Render();
        }

        public void Render()
        {
            listBox1.Items.Clear();
            foreach (Card card in Game.GetCards(5))
            {
                listBox1.Items.Add(card.Label);
            }

            label1.Text = "Player";
            label3.Text = "Dealer";
            if (Game.GetState(0) == Constants.UserState.RequestingCard) label1.Text = "Deal player";
            if (Game.GetState(5) == Constants.UserState.RequestingCard) label3.Text = "Deal dealer";
            label4.Text = Game.GetState(5).ToString();
            label5.Text = Game.GetState(0).ToString();
            label6.Text = Game.GetCardCount(0).ToString() + " Cards";
            label7.Text = Game.GetCardCount(0).ToString() + " Cards";
            if (Game.Winner.Length > 0)
            {
                if (Game.GetTotalFor(0).ToString().Length > 0) label6.Text = label6.Text = Game.GetCardCount(0).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(0).ToString();
                label2.Text = "Winner: " + Game.Winner;
                listBox2.BringToFront();
                listBox2.Items.Clear();
                foreach (Card card in Game.GetCards(0))
                {
                    listBox2.Items.Add(card.Label);
                }
            }
            if (Game.GetTotalFor(5).ToString().Length > 0) label7.Text = Game.GetCardCount(5).ToString() + " Cards" + ", Total: " + Game.GetTotalFor(5).ToString();
        }

        public void GameLoop()
        {
            if (Game.Winner.Length > 0)
            {
                button2.BringToFront();
                return;
            }
            if (!Game.NextAction())
            {
                GameLoop();
                Render();
                return;
            }
            else
            {
                button3.BringToFront();
                button4.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Started)
            {
                Game.StartGame(5, players);
                Started = true;
                button5.BringToFront();
                pictureBox2.BringToFront();
                label6.BringToFront();
                label7.BringToFront();
                button1.SendToBack();
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

        private void button2_Click(object sender, EventArgs e)
        {
            button2.SendToBack();
            Started = false;
            button1.Text = "Start";
            label2.Text = "Winner";
            label4.Text = "state";
            label5.Text = "state";
            label6.Text = "0 cards";
            label7.Text = "0 cards";
            button1.BringToFront();
            listBox1.SendToBack();
            listBox2.SendToBack();
            label6.SendToBack();
            label7.SendToBack();
            pictureBox2.SendToBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Game.GetState(0) == Constants.UserState.RequestingCard) return;
            Game.Hit();
            Render();
            button3.SendToBack();
            button4.SendToBack();
            GameLoop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Game.GetState(0) == Constants.UserState.RequestingCard) return;
            Game.Stand();
            Render();
            button3.SendToBack();
            button4.SendToBack();
            GameLoop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Game.Shuffle();
            ShuffleDeckAnimation();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (Started && Game.GetState(5) == Constants.UserState.RequestingCard) Game.Deal(5);
            DealCheck();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Started && Game.GetState(0) == Constants.UserState.RequestingCard) Game.Deal(0);
            DealCheck();
        }
    }
}
