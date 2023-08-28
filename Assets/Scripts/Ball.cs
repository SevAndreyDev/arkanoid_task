using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        [Inject] private GameSettings gameSettings;
        [Inject] private ScoreController scoreController;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
                scoreController.AddScore(gameSettings.ScoresForObstacle);
            }
        }
    }
}