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

        private void button1_Click(object sender, EventArgs e)
        {
            Game.StartGame("dealer");
            button1.Location = new Point(-button1.Size.Width, -button1.Size.Height);
            listBox1.Items.Clear();
            listBox1.Location = new Point(544, 283);

            foreach (Card card in Game.getCards())
            {
                listBox1.Items.Add(card.Label);
            }
            label1.Text = "Player: " + Game.GetTotalFor("player").ToString();
            label2.Text = "Winner: " + Game.Winner;
            label3.Text = "Dealer: " + Game.GetTotalFor("dealer").ToString();
            button2.Location = new Point(650, 220);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Location = new Point(394, 215);
            listBox1.Location = new Point(-listBox1.Size.Width, -listBox1.Size.Height);
            button2.Location = new Point(-button2.Size.Width, -button2.Size.Height);
            label1.Text = "Player";
            label2.Text = "Winner";
            label3.Text = "Dealer";
        }
    }
}
