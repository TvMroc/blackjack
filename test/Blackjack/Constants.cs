using static System.Windows.Forms.AxHost;

namespace test.Blackjack
{

    public class Constants
    {
        public enum Type
        {
            Spades,
            Diamonds,
            Clubs,
            Hearts,
        }
        public enum UserState
        {
            Playing,
            Standing,
            Busted,
            Forfeitted,
        }

        public static Random rng = new Random();

        public static readonly int startMoney = 500;
        public static readonly int DeckShuffles = 4;
        public static readonly int[][] DeckValues = [[11, 1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [10], [10], [10]];
        public static readonly int[] doubleDownRange = [9, 11];
        public static readonly string[] DeckLabels = ["Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"];
        public static readonly Type[] Types = [Type.Spades, Type.Diamonds, Type.Clubs, Type.Hearts];
        public static readonly UserState[] States = [UserState.Playing, UserState.Standing, UserState.Busted, UserState.Forfeitted];
    }
}
