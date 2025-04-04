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
            dataGridView1.Rows.Clear();
            Game.StartGame("dealer");

            foreach (Card card in Game.getCards())
            {
                dataGridView1.Rows.Add(card.Label);
            }
            label1.Text = Game.GetTotalFor("player").ToString();
            label2.Text = Game.Winner;
            label3.Text = Game.GetTotalFor("dealer").ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            pictureBox2.BackColor = Color.Transparent;
            this.TransparencyKey = Color.Transparent;
        }
    }
}
