using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings gameSettings;
        
        public override void InstallBindings()
        {            
            Container.BindInstance(gameSettings).AsSingle();
            Container.Bind<EventsManager>().AsSingle();
        }
    }
}