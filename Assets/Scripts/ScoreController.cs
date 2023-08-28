using UnityEngine;
using TMPro;

namespace Arkanoid
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreValue;

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

        private void Start() => Score = 0;

        public void AddScore(int score)
        {
            Score += score;
        }
    }
}