using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Services.Game
{
    public class LevelController: MonoBehaviour 
    {
        [SerializeField] private QuestButton _questButton;
        [SerializeField] private Player _player;

        private void Start()
        {
            Subscribe();
        }

        [ContextMenu("Test Pick Brush")]
        public void TestPickBrush()
        {
            var brush = FindObjectOfType<Brush>();
            _player.PickItem(brush);
        }

        [ContextMenu("Test Interact With Can")]
        public void TestInteractWithCan()
        {
            var can = FindObjectOfType<Can>();
            _player.InteractWithItem(can);
        }

        [ContextMenu("Test Interact With Button")]
        public void TestInteractWithButton()
        {
            var button = FindObjectOfType<QuestButton>();
            _player.InteractWithItem(button);
        }

        private void Subscribe()
        {
            _questButton.OnActivated += Win;
            _player.OnDied += Lose;
        }

        private void Win()
        {
            Debug.Log("Win");
        }

        private void Lose()
        {
            Debug.Log("Lose");
        }
    }
}