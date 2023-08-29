using UnityEngine;

namespace Arkanoid
{
    public class PlatformController : MonoBehaviour
    {
        [Header("Input Settings")]
        [SerializeField] private InputController inputController;
        [SerializeField] private float movementSentence = 0.025f;
        [SerializeField] private float movementLimit = 1.68f;

        [Header("Bounce Settings")]
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private float force = 10f;
        [SerializeField] private float sideImpulse = 1f;

        [SerializeField][Range(0f, 1f)] private float normalSideZone = 0.5f;   // Зона на платформе от 0 до 1, при попадании на которую шарик будет отскакивать обычным образом.
                                                                               // За пределами этой зоны (шарик приземлился ближе к левой или правой части платформы)
                                                                               // будет добавлен импульс в сторону (sideImpulse). Нужно, чтобы легче управлять шариком,
                                                                               // чтобы он не прыгал только вперед - назад от платформы к препятствиям и обратно.
        private Vector2 platformSize;
        private bool isBallOnPlatform;
                        
        private void Start()
        {
            platformSize = gameObject.GetComponent<SpriteRenderer>().size;

            ball.transform.SetParent(transform);
            isBallOnPlatform = true;

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
            if (isBallOnPlatform)
            {
                ball.transform.SetParent(null);
                ball.AddForce(Vector2.up * force, ForceMode2D.Impulse);

                isBallOnPlatform = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Ball target = collision.gameObject.GetComponent<Ball>();

            if (target == null)
                return;

            float deltaPosition = Mathf.Abs(target.transform.position.x - transform.position.x);
            float minZone = platformSize.x * normalSideZone;

            if (deltaPosition > minZone)
            {
                float speed = ball.velocity.magnitude;
                
                float direction = target.transform.position.x >= transform.position.x ? 1f : -1f;                
                ball.AddForce(Vector2.right * sideImpulse * direction, ForceMode2D.Impulse);
                
                ball.velocity = ball.velocity.normalized * speed;
            }
        }
    }
}