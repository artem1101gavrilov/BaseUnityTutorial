using UnityEngine;

namespace OldCubeCreator
{
    public class OldCubeCreator : MonoBehaviour
    {
        [SerializeField] private GameObject Cube;
        private Transform currentCube;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var position = Input.mousePosition;
                position.z = 10;
                currentCube = Instantiate(Cube, Camera.main.ScreenToWorldPoint(position) + transform.forward * 10, Quaternion.identity).transform;
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                currentCube.localScale += Vector3.one * Time.deltaTime;
            }
        }
    }
}