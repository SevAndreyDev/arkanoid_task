using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int scoresForObstacle;

        public int ScoresForObstacle => scoresForObstacle;
    }
}