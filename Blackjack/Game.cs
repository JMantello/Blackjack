namespace Blackjack
{
    public class Game
    {
        //fields
        private Player _player;
        private Player _cpu;
        private string _status;
        private string _winner;
        private Deck _deck;

        //constructor
        public Game()
        {
            //Game status
            _status = "Not started";
            _winner = null;

            //create deck
            _deck = new Deck();

            //create players
            _player = new Player();
            _cpu = new Player();
        }

        //properties
        public string Status
        {
            get { return _status; }
        }
        public string Winner
        {
            get { return _winner; }
        }

        //return players points, hand for display
        public int PlayerPoints
        {
            get { return _player.Points; }
        }
        public Card[] PlayerHand
        {
            get { return _player.Hand; }
        }
        public bool PlayerBust
        {
            get { return _player.Bust; }
        }
        public bool PlayerDealt21
        {
            get { return _player.Dealt21; }
        }
        public bool PlayerCanHit
        {
            get { return _player.CanHit; }
        }

        //return cpu points and hand for display
        public int CpuPoints
        {
            get { return _cpu.Points; }
        }
        public Card[] CpuHand
        {
            get { return _cpu.Hand; }
        }
        public bool CpuBust
        {
            get { return _cpu.Bust; }
        }
        public bool CpuDealt21
        {
            get { return _cpu.Dealt21; }
        }

        //methods
        public void NewRound()
        {
            _status = "Playing";
            _winner = null;

            _cpu.Reset();
            _player.Reset();

            //deal cards
            _player.StartingDeal(_deck);
            _cpu.StartingDeal(_deck);
        }

        public void PlayerHits()
        {
            _player.Hit(_deck);
        }

        private void cpuAutoDraw()
        {
            if (PlayerBust)
                return;
            else
                while (CpuHand.Length < 5 && CpuPoints < 17)
                    _cpu.Hit(_deck);
        }

        public void ScoreGame()
        {
            if (PlayerDealt21)
                DetermineWinner();

            if (Status.Equals("Playing"))
            {
                cpuAutoDraw();
                DetermineWinner();
            }
        }

        public void DetermineWinner()
        {
            _status = "Finished";

            //you win
            if ((_cpu.Bust && !_player.Bust) ||
                (_player.Points > _cpu.Points && !_player.Bust) ||
                (_player.Hand.Length == 5 && !_player.Bust) ||
                (_player.Dealt21 && !_cpu.Dealt21))
            {
                _winner = ("You");
                return;
            }

            //cpu wins
            if ((_player.Bust && !_cpu.Bust) ||
               (_cpu.Points > _player.Points && !_cpu.Bust && _player.Hand.Length < 5) ||
               (_player.Bust && _cpu.Bust) || 
               (_cpu.Dealt21 && !_player.Dealt21))
            {
                _winner = ("Dealer");
                return;
            }

            //draw
            if (_player.Points == _cpu.Points)
            {
                _winner = ("Draw");
                return;
            }

            _winner = "Winner not accounted for";
            return;
        }
    }
}
