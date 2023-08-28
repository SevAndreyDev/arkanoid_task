using UnityEngine;

namespace Arkanoid
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Vector2Int mathSize;
        [SerializeField] private Transform container;
        [SerializeField] private Transform obstaclePrefab;        
        [SerializeField] private ObstaclesConfiguration fieldObstacles;

        private void Start() => FillField();

        private void FillField()
        {
            Vector2 size = spriteRenderer.size;

            float scaleX = size.x / mathSize.x;
            float scaleY = size.y / mathSize.y;

            float startX = transform.position.x - size.x / 2f + scaleX / 2f;
            float startY = transform.position.y + size.y / 2f - scaleY / 2f;
                        
            foreach (var item in fieldObstacles.Obstacles)
            {
                Transform obstacle = Instantiate(obstaclePrefab);
                obstacle.position = new Vector3(startX + scaleX * item.x, startY - scaleY * item.y, 0f);

                obstacle.SetParent(container, true);
            }
        }
    }
}