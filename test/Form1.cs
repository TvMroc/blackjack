using test.Blackjack;

namespace test
{
    public partial class Form1 : Form
    {

        Blackjack.Blackjack Game = new Blackjack.Blackjack { };
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


        public void Render()
        {
            listBox1.Items.Clear();
            foreach (Card card in Game.getCards("dealer"))
            {
                listBox1.Items.Add(card.Label);
            }
            label4.Text = Game.GetState("dealer").ToString();
            label5.Text = Game.GetState("player").ToString();
            if (Game.Winner.Length > 0)
            {
                if (Game.GetTotalFor("player").ToString().Length > 0) label1.Text = "Player: " + Game.GetTotalFor("player").ToString();
                label2.Text = "Winner: " + Game.Winner;
                listBox2.BringToFront();
                listBox2.Items.Clear();
                foreach (Card card in Game.getCards("player"))
                {
                    listBox2.Items.Add(card.Label);
                }
            }
            if (Game.GetTotalFor("dealer").ToString().Length > 0) label3.Text = "Dealer: " + Game.GetTotalFor("dealer").ToString();
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
                Game.StartGame("dealer");
                Started = true;
                button5.BringToFront();
                pictureBox2.BringToFront();
                button1.Text = "Deal";
            } else
            {
                Game.Deal();
                listBox1.BringToFront();
                button1.SendToBack();
                button5.SendToBack();
                Render();
                GameLoop();
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
            label1.Text = "Player";
            label2.Text = "Winner";
            label3.Text = "Dealer";
            label4.Text = "state";
            label5.Text = "state";
            button1.BringToFront();
            listBox1.SendToBack();
            listBox2.SendToBack();
            pictureBox2.SendToBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game.Hit();
            Render();
            button3.SendToBack();
            button4.SendToBack();
            GameLoop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
    }
}
