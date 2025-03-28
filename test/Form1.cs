using test.Blackjack;
using static test.Blackjack.Deck;
using static test.Blackjack.Dealer;

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
            Game.StartGame();
            label1.Text = Game.player.GetTotal().ToString();
            label2.Text = Game.Winner;
            label3.Text = Game.dealer.GetTotal().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            sender = Game.player.GetTotal();

        }
    }
}
