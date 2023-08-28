using UnityEngine;

namespace Arkanoid
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private InputController inputController;

        [SerializeField] private float movementSentence = 0.025f;
        [SerializeField] private float movementLimit = 1.68f;
        [SerializeField] private float force = 10f;
        [SerializeField] private Rigidbody2D ball;
                        
        private void Start()
        {
            ball.transform.SetParent(transform);

            inputController.OnMove += OnMoveIteration;
            inputController.OnBallThrow += OnBallThrow;
        }
                
        private void OnMoveIteration(float movement)
        {
            Vector3 position = transform.position;
            position.x += movement * movementSentence;
            position.x = Mathf.Clamp(position.x, -movementLimit, movementLimit);
            transform.position = position;
        }

        private void OnBallThrow()
        {
            ball.transform.SetParent(null);
            ball.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}