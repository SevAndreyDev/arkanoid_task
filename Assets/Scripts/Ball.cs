using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float deltaWallYForImpulse = 0.1f;
        [SerializeField] private float antiCircleImpulse = 1f;
        [Inject] private EventsManager eventsManager;

        private Rigidbody2D rb;
        private float lastWallY;

        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            eventsManager.AddListener(GameEvents.WinGame, _ => gameObject.SetActive(false));
            eventsManager.AddListener(GameEvents.LoseGame, _ => gameObject.SetActive(false));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
                eventsManager.InvokeEvent(GameEvents.DestroyObstacle);
            }

            if (collision.gameObject.CompareTag("Border"))
            {
                if (Mathf.Abs(transform.position.y - lastWallY) <= deltaWallYForImpulse)    // Избавляемся от зацикливания, когда шарик прыгает влево-вправо от одной стены к другой
                {
                    float speed = rb.velocity.magnitude;  // Запоминаем скорость, чтобы при добавлении импульса общая скорость не увеличилась, только направление

                    Vector2 direction = Random.Range(0f, 1f) >= 0.5f ? Vector2.up : Vector2.down;
                    rb.AddForce(direction * antiCircleImpulse, ForceMode2D.Impulse);

                    rb.velocity = rb.velocity.normalized * speed;
                    lastWallY = 0f;
                }
                else
                {
                    lastWallY = transform.position.y;
                }
            }
            else
            {
                lastWallY = 0f;
            }

            if (collision.gameObject.CompareTag("Death"))
            {
                eventsManager.InvokeEvent(GameEvents.LoseGame);
            }
        }
    }
}