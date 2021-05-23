using UnityEngine;

public class TestTanRotation : MonoBehaviour
{
    [SerializeField] private Transform Zombie;

    private void Update()
    {
        var direction = Zombie.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
