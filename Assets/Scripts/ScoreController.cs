using UnityEngine;
using TMPro;
using Zenject;
using System;

namespace Arkanoid
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreValue;
        [Inject] private EventsManager eventsManager;
        [Inject] private GameSettings gameSettings;

        private int score;
        public int Score 
        {
            get { return score; }
            
            private set
            {
                score = value;
                scoreValue.text = score.ToString();
            }
        }

        private void Start()
        {
            eventsManager.AddListener(GameEvents.DestroyObstacle, OnDestroyObstacle);
            Score = 0;
        }

        private void OnDestroyObstacle(object[] args)
        {
            AddScore(gameSettings.ScoresForObstacle);
        }

        public void AddScore(int score)
        {
            Score += score;
        }
    }
}