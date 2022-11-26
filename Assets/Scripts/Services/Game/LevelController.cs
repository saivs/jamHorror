namespace Assets.Scripts.Services.Game
{
    public class LevelController 
    {
        private readonly QuestButton _questButton;
        private readonly IPlayer _player;

        public LevelController(QuestButton questButton, IPlayer player)
        {
            _questButton = questButton;
            _player = player;

            Subscribe();
        }

        private void Subscribe()
        {
            _questButton.OnActivated += Win;
            _player.OnDied += Lose;
        }

        private void Win()
        {
            
        }

        private void Lose()
        {

        }
    }
}