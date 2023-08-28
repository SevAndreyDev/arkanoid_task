using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "ObstaclesConfiguration", fileName = "ObstaclesConfiguration")]
    public class ObstaclesConfiguration : ScriptableObject
    {
        [SerializeField] private Vector2Int[] obstacles;

        public Vector2Int[] Obstacles => obstacles;
    }
}