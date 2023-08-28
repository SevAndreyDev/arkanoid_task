using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
                // TODO: SCORE
            }
        }
    }
}