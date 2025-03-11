namespace test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>


        public enum Type
        {
            Spades,
            Diamonds,
            Clubs,
            Hearts,
        }

        public class Card
        {
            public int[] Value { get; }
            public string Label { get; }
            public Type Type { get; }

            public Card(int[] value, string label, Type type)
            {
                Value = value;
                Label = label;
                Type = type;
            }
        }



        readonly int[][] DeckValues = [[11, 1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [10], [10], [10]];
        readonly string[] DeckLabels = ["Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"];
        readonly Type[] Types = [Type.Spades, Type.Diamonds, Type.Clubs, Type.Hearts];

        public List<Card> CreateDeck()
        {
            List<Card> Deck = new List<Card>();

            foreach (Type type in Types)
            {
                for (int i = 0; i < DeckLabels.Length; i++)
                {
                    Deck.Add(new Card(DeckValues[i], DeckLabels[i], type));
                }
            }

            return Deck;
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(357, 128);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            //
            // deck
            //
            List<Card> Deck = CreateDeck();
            Console.WriteLine(Deck);
        }

        #endregion

        private Button button1;
    }
}
