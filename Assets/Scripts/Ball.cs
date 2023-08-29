using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        [Inject] private EventsManager eventsManager;

        private void Start()
        {
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
        }
    }
}