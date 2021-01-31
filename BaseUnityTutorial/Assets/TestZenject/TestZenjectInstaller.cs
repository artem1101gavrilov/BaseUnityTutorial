using Singleton;
using UnityEngine;
using Zenject;

public class TestZenjectInstaller : MonoInstaller
{
    [SerializeField] private GameObject TargetPlayer;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentOn(TargetPlayer).AsSingle();
    }
}