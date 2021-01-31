using Singleton;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private Transform target;

    [Inject]
    private void Init(Player player)
    {
        target = player.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
    }
}
