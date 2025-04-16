using test.Blackjack;

namespace test
{
    public partial class Form1 : Form
    {

        Blackjack.Blackjack Game = new Blackjack.Blackjack { };

        public Form1()
        {
            InitializeComponent();
        }

        public void Render()
        {
            listBox1.Items.Clear();
            foreach (Card card in Game.getCards())
            {
                listBox1.Items.Add(card.Label);
            }
            if (Game.GetTotalFor("player").ToString().Length > 0) label1.Text = "Player: " + Game.GetTotalFor("player").ToString();
            if (Game.Winner.Length > 0) label2.Text = "Winner: " + Game.Winner;
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
            } else
            {
                button3.BringToFront();
                button4.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.StartGame("dealer");
            listBox1.BringToFront();
            button1.SendToBack();
            Game.Shuffle();
            Game.Shuffle();
            Game.Shuffle();
            Game.Deal();
            Render();
            GameLoop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.SendToBack();
            button3.SendToBack();
            button4.SendToBack();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.SendToBack();
            label1.Text = "Player";
            label2.Text = "Winner";
            label3.Text = "Dealer";
            button1.BringToFront();
            listBox1.SendToBack();
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
    }
}
