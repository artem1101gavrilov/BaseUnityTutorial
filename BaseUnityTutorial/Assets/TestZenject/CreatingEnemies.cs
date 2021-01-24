using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreatingEnemies : MonoBehaviour
{
    [SerializeField, Inject] private DiContainer DiContainer;
    [SerializeField] private GameObject Enemy;

    public void CreateEnemy()
    {
        DiContainer.InstantiatePrefab(Enemy, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity, null);
    }
}
