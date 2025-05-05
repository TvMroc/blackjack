using static test.Blackjack.Deck;
using static test.Blackjack.Dealer;
using static test.Blackjack.Blackjack;
using test.Blackjack;

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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            startButton = new Button();
            player1Label = new Label();
            dealerLabel = new Label();
            tableImage = new PictureBox();
            cardsImage = new PictureBox();
            dealerCards = new ListBox();
            restartButton = new Button();
            hitButton = new Button();
            standButton = new Button();
            shuffleButton = new Button();
            dealerState = new Label();
            player1State = new Label();
            player1Cards = new ListBox();
            player1CardLabel = new Label();
            dealerCardLabel = new Label();
            player2Cards = new ListBox();
            player2CardLabel = new Label();
            player2State = new Label();
            player2Label = new Label();
            player3CardLabel = new Label();
            player3State = new Label();
            player3Label = new Label();
            player3Cards = new ListBox();
            player4CardLabel = new Label();
            player4State = new Label();
            player4Label = new Label();
            player4Cards = new ListBox();
            player5CardLabel = new Label();
            player5State = new Label();
            player5Label = new Label();
            player5Cards = new ListBox();
            playerCountInput = new TextBox();
            player1NameInput = new TextBox();
            player2NameInput = new TextBox();
            player3NameInput = new TextBox();
            player4NameInput = new TextBox();
            player5NameInput = new TextBox();
            NamesLabel = new Label();
            dealerNameInput = new TextBox();
            DealerNameLabel = new Label();
            playerCountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)tableImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cardsImage).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(394, 225);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // player1Label
            // 
            player1Label.AutoSize = true;
            player1Label.Location = new Point(428, 128);
            player1Label.Name = "player1Label";
            player1Label.Size = new Size(39, 15);
            player1Label.TabIndex = 1;
            player1Label.Text = "Player";
            // 
            // dealerLabel
            // 
            dealerLabel.AutoSize = true;
            dealerLabel.Location = new Point(428, 323);
            dealerLabel.Name = "dealerLabel";
            dealerLabel.Size = new Size(40, 15);
            dealerLabel.TabIndex = 3;
            dealerLabel.Text = "Dealer";
            // 
            // tableImage
            // 
            tableImage.Image = Properties.Resources.table;
            tableImage.Location = new Point(-1, 1);
            tableImage.Name = "tableImage";
            tableImage.Size = new Size(855, 598);
            tableImage.TabIndex = 4;
            tableImage.TabStop = false;
            // 
            // cardsImage
            // 
            cardsImage.Image = (Image)resources.GetObject("cardsImage.Image");
            cardsImage.Location = new Point(475, 203);
            cardsImage.Name = "cardsImage";
            cardsImage.Size = new Size(108, 64);
            cardsImage.TabIndex = 7;
            cardsImage.TabStop = false;
            // 
            // dealerCards
            // 
            dealerCards.FormattingEnabled = true;
            dealerCards.Location = new Point(388, 306);
            dealerCards.Name = "dealerCards";
            dealerCards.Size = new Size(40, 64);
            dealerCards.TabIndex = 8;
            // 
            // restartButton
            // 
            restartButton.Location = new Point(394, 224);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(75, 23);
            restartButton.TabIndex = 9;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // hitButton
            // 
            hitButton.Location = new Point(142, 345);
            hitButton.Name = "hitButton";
            hitButton.Size = new Size(75, 23);
            hitButton.TabIndex = 10;
            hitButton.Text = "Hit";
            hitButton.UseVisualStyleBackColor = true;
            hitButton.Click += hitButton_Click;
            // 
            // standButton
            // 
            standButton.Location = new Point(51, 345);
            standButton.Name = "standButton";
            standButton.Size = new Size(75, 23);
            standButton.TabIndex = 11;
            standButton.Text = "Stand";
            standButton.UseVisualStyleBackColor = true;
            standButton.Click += standButton_Click;
            // 
            // shuffleButton
            // 
            shuffleButton.Location = new Point(492, 274);
            shuffleButton.Name = "shuffleButton";
            shuffleButton.Size = new Size(75, 23);
            shuffleButton.TabIndex = 12;
            shuffleButton.Text = "Shuffle";
            shuffleButton.UseVisualStyleBackColor = true;
            shuffleButton.Click += shuffleButton_Click;
            // 
            // dealerState
            // 
            dealerState.AutoSize = true;
            dealerState.Location = new Point(428, 339);
            dealerState.Name = "dealerState";
            dealerState.Size = new Size(32, 15);
            dealerState.TabIndex = 13;
            dealerState.Text = "state";
            // 
            // player1State
            // 
            player1State.AutoSize = true;
            player1State.Location = new Point(428, 112);
            player1State.Name = "player1State";
            player1State.Size = new Size(32, 15);
            player1State.TabIndex = 14;
            player1State.Text = "state";
            // 
            // player1Cards
            // 
            player1Cards.FormattingEnabled = true;
            player1Cards.Location = new Point(388, 95);
            player1Cards.Name = "player1Cards";
            player1Cards.Size = new Size(40, 64);
            player1Cards.TabIndex = 15;
            // 
            // player1CardLabel
            // 
            player1CardLabel.AutoSize = true;
            player1CardLabel.Location = new Point(428, 96);
            player1CardLabel.Name = "player1CardLabel";
            player1CardLabel.Size = new Size(37, 15);
            player1CardLabel.TabIndex = 16;
            player1CardLabel.Text = "Cards";
            // 
            // dealerCardLabel
            // 
            dealerCardLabel.AutoSize = true;
            dealerCardLabel.Location = new Point(428, 355);
            dealerCardLabel.Name = "dealerCardLabel";
            dealerCardLabel.Size = new Size(37, 15);
            dealerCardLabel.TabIndex = 17;
            dealerCardLabel.Text = "Cards";
            // 
            // player2Cards
            // 
            player2Cards.FormattingEnabled = true;
            player2Cards.Location = new Point(177, 95);
            player2Cards.Name = "player2Cards";
            player2Cards.Size = new Size(40, 64);
            player2Cards.TabIndex = 18;
            // 
            // player2CardLabel
            // 
            player2CardLabel.AutoSize = true;
            player2CardLabel.Location = new Point(217, 96);
            player2CardLabel.Name = "player2CardLabel";
            player2CardLabel.Size = new Size(37, 15);
            player2CardLabel.TabIndex = 19;
            player2CardLabel.Text = "Cards";
            // 
            // player2State
            // 
            player2State.AutoSize = true;
            player2State.Location = new Point(217, 112);
            player2State.Name = "player2State";
            player2State.Size = new Size(32, 15);
            player2State.TabIndex = 20;
            player2State.Text = "state";
            // 
            // player2Label
            // 
            player2Label.AutoSize = true;
            player2Label.Location = new Point(217, 128);
            player2Label.Name = "player2Label";
            player2Label.Size = new Size(39, 15);
            player2Label.TabIndex = 21;
            player2Label.Text = "Player";
            // 
            // player3CardLabel
            // 
            player3CardLabel.AutoSize = true;
            player3CardLabel.Location = new Point(637, 95);
            player3CardLabel.Name = "player3CardLabel";
            player3CardLabel.Size = new Size(37, 15);
            player3CardLabel.TabIndex = 22;
            player3CardLabel.Text = "Cards";
            // 
            // player3State
            // 
            player3State.AutoSize = true;
            player3State.Location = new Point(637, 111);
            player3State.Name = "player3State";
            player3State.Size = new Size(32, 15);
            player3State.TabIndex = 23;
            player3State.Text = "state";
            // 
            // player3Label
            // 
            player3Label.AutoSize = true;
            player3Label.Location = new Point(637, 127);
            player3Label.Name = "player3Label";
            player3Label.Size = new Size(39, 15);
            player3Label.TabIndex = 24;
            player3Label.Text = "Player";
            // 
            // player3Cards
            // 
            player3Cards.FormattingEnabled = true;
            player3Cards.Location = new Point(597, 95);
            player3Cards.Name = "player3Cards";
            player3Cards.Size = new Size(40, 64);
            player3Cards.TabIndex = 25;
            // 
            // player4CardLabel
            // 
            player4CardLabel.AutoSize = true;
            player4CardLabel.Location = new Point(705, 205);
            player4CardLabel.Name = "player4CardLabel";
            player4CardLabel.Size = new Size(37, 15);
            player4CardLabel.TabIndex = 26;
            player4CardLabel.Text = "Cards";
            // 
            // player4State
            // 
            player4State.AutoSize = true;
            player4State.Location = new Point(705, 221);
            player4State.Name = "player4State";
            player4State.Size = new Size(32, 15);
            player4State.TabIndex = 27;
            player4State.Text = "state";
            // 
            // player4Label
            // 
            player4Label.AutoSize = true;
            player4Label.Location = new Point(705, 237);
            player4Label.Name = "player4Label";
            player4Label.Size = new Size(39, 15);
            player4Label.TabIndex = 28;
            player4Label.Text = "Player";
            // 
            // player4Cards
            // 
            player4Cards.FormattingEnabled = true;
            player4Cards.Location = new Point(665, 204);
            player4Cards.Name = "player4Cards";
            player4Cards.Size = new Size(40, 64);
            player4Cards.TabIndex = 29;
            // 
            // player5CardLabel
            // 
            player5CardLabel.AutoSize = true;
            player5CardLabel.Location = new Point(153, 205);
            player5CardLabel.Name = "player5CardLabel";
            player5CardLabel.Size = new Size(37, 15);
            player5CardLabel.TabIndex = 30;
            player5CardLabel.Text = "Cards";
            // 
            // player5State
            // 
            player5State.AutoSize = true;
            player5State.Location = new Point(153, 221);
            player5State.Name = "player5State";
            player5State.Size = new Size(32, 15);
            player5State.TabIndex = 31;
            player5State.Text = "state";
            // 
            // player5Label
            // 
            player5Label.AutoSize = true;
            player5Label.Location = new Point(153, 237);
            player5Label.Name = "player5Label";
            player5Label.Size = new Size(39, 15);
            player5Label.TabIndex = 32;
            player5Label.Text = "Player";
            // 
            // player5Cards
            // 
            player5Cards.FormattingEnabled = true;
            player5Cards.Location = new Point(113, 203);
            player5Cards.Name = "player5Cards";
            player5Cards.Size = new Size(40, 64);
            player5Cards.TabIndex = 33;
            // 
            // playerCountInput
            // 
            playerCountInput.Location = new Point(319, 398);
            playerCountInput.Name = "playerCountInput";
            playerCountInput.Size = new Size(100, 23);
            playerCountInput.TabIndex = 34;
            playerCountInput.Text = "1";
            playerCountInput.KeyDown += playerCountInput_KeyDown;
            playerCountInput.KeyPress += playerCountInput_KeyPress;
            playerCountInput.KeyUp += playerCountInput_KeyUp;
            // 
            // player1NameInput
            // 
            player1NameInput.Location = new Point(484, 379);
            player1NameInput.Name = "player1NameInput";
            player1NameInput.Size = new Size(100, 23);
            player1NameInput.TabIndex = 35;
            player1NameInput.Text = "Player1";
            // 
            // player2NameInput
            // 
            player2NameInput.Location = new Point(584, 379);
            player2NameInput.Name = "player2NameInput";
            player2NameInput.Size = new Size(100, 23);
            player2NameInput.TabIndex = 36;
            player2NameInput.Text = "Player2";
            // 
            // player3NameInput
            // 
            player3NameInput.Location = new Point(684, 379);
            player3NameInput.Name = "player3NameInput";
            player3NameInput.Size = new Size(100, 23);
            player3NameInput.TabIndex = 37;
            player3NameInput.Text = "Player3";
            // 
            // player4NameInput
            // 
            player4NameInput.Location = new Point(484, 402);
            player4NameInput.Name = "player4NameInput";
            player4NameInput.Size = new Size(100, 23);
            player4NameInput.TabIndex = 38;
            player4NameInput.Text = "Player4";
            // 
            // player5NameInput
            // 
            player5NameInput.Location = new Point(584, 402);
            player5NameInput.Name = "player5NameInput";
            player5NameInput.Size = new Size(100, 23);
            player5NameInput.TabIndex = 39;
            player5NameInput.Text = "Player5";
            // 
            // NamesLabel
            // 
            NamesLabel.AutoSize = true;
            NamesLabel.Location = new Point(435, 393);
            NamesLabel.Name = "NamesLabel";
            NamesLabel.Size = new Size(47, 15);
            NamesLabel.TabIndex = 40;
            NamesLabel.Text = "Names:";
            // 
            // dealerNameInput
            // 
            dealerNameInput.Location = new Point(51, 399);
            dealerNameInput.Name = "dealerNameInput";
            dealerNameInput.Size = new Size(100, 23);
            dealerNameInput.TabIndex = 41;
            dealerNameInput.Text = "Dealer";
            // 
            // DealerNameLabel
            // 
            DealerNameLabel.AutoSize = true;
            DealerNameLabel.Location = new Point(78, 383);
            DealerNameLabel.Name = "DealerNameLabel";
            DealerNameLabel.Size = new Size(42, 15);
            DealerNameLabel.TabIndex = 42;
            DealerNameLabel.Text = "Name:";
            // 
            // playerCountLabel
            // 
            playerCountLabel.AutoSize = true;
            playerCountLabel.Location = new Point(331, 382);
            playerCountLabel.Name = "playerCountLabel";
            playerCountLabel.Size = new Size(76, 15);
            playerCountLabel.TabIndex = 43;
            playerCountLabel.Text = "Player count:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 573);
            Controls.Add(playerCountLabel);
            Controls.Add(DealerNameLabel);
            Controls.Add(dealerNameInput);
            Controls.Add(NamesLabel);
            Controls.Add(player5NameInput);
            Controls.Add(player4NameInput);
            Controls.Add(player3NameInput);
            Controls.Add(player2NameInput);
            Controls.Add(player1NameInput);
            Controls.Add(playerCountInput);
            Controls.Add(player5Label);
            Controls.Add(player5State);
            Controls.Add(player5CardLabel);
            Controls.Add(player4Label);
            Controls.Add(player4State);
            Controls.Add(player4CardLabel);
            Controls.Add(player3Label);
            Controls.Add(player3State);
            Controls.Add(player3CardLabel);
            Controls.Add(player2Label);
            Controls.Add(player2State);
            Controls.Add(player2CardLabel);
            Controls.Add(dealerCardLabel);
            Controls.Add(player1CardLabel);
            Controls.Add(player1State);
            Controls.Add(dealerState);
            Controls.Add(dealerLabel);
            Controls.Add(player1Label);
            Controls.Add(startButton);
            Controls.Add(tableImage);
            Controls.Add(restartButton);
            Controls.Add(hitButton);
            Controls.Add(standButton);
            Controls.Add(player5Cards);
            Controls.Add(player2Cards);
            Controls.Add(player1Cards);
            Controls.Add(player3Cards);
            Controls.Add(player4Cards);
            Controls.Add(dealerCards);
            Controls.Add(shuffleButton);
            Controls.Add(cardsImage);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tableImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)cardsImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label player1Label;
        private Label dealerLabel;
        private PictureBox tableImage;
        private PictureBox cardsImage;
        private ListBox dealerCards;
        private Button restartButton;
        private Button hitButton;
        private Button standButton;
        private Button shuffleButton;
        private Label dealerState;
        private Label player1State;
        private ListBox player1Cards;
        private Label player1CardLabel;
        private Label dealerCardLabel;
        private ListBox player2Cards;
        private Label player2CardLabel;
        private Label player2State;
        private Label player2Label;
        private Label player3CardLabel;
        private Label player3State;
        private Label player3Label;
        private ListBox player3Cards;
        private Label player4CardLabel;
        private Label player4State;
        private Label player4Label;
        private ListBox player4Cards;
        private Label player5CardLabel;
        private Label player5State;
        private Label player5Label;
        private ListBox player5Cards;
        private TextBox playerCountInput;
        private TextBox player1NameInput;
        private TextBox player2NameInput;
        private TextBox player3NameInput;
        private TextBox player4NameInput;
        private TextBox player5NameInput;
        private Label NamesLabel;
        private TextBox dealerNameInput;
        private Label DealerNameLabel;
        private Label playerCountLabel;
    }
}
