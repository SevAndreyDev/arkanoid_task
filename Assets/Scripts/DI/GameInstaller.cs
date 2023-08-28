using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private ScoreController scoreController;

        public override void InstallBindings()
        {            
            Container.BindInstance(gameSettings).AsSingle();
            Container.BindInstance(scoreController).AsSingle();
        }
    }
}