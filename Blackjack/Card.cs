namespace Blackjack
{
    public class Card
    {
        private string _type; //number, ace, jack, queen, king.
        private string _suit;
        private int _value;
        private bool _isAce;
        private System.Drawing.Image _image;


        public Card(string type, string suit, int value)
        {
            _type = type;
            _suit = suit;
            _value = value;

            if (type.Equals("ace"))
                _isAce = true;
            else
                _isAce = false;
        }

        public string Type
        {
            get { return _type; }
        }

        public string Suit
        {
            get { return _suit; }
        }

        public int Value
        {
            get { return _value; }
        }

        public bool IsAce
        {
            get { return _isAce; }
        }

        public System.Drawing.Image Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
