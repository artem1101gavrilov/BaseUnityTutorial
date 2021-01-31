using UnityEngine;

namespace Strategy
{
    public class Player : MonoBehaviour
    {
        private int HP;

        private IMovable movable;

        // Свойства

        private void Start()
        {
            movable = new MovableMain();
        }

        private void Update()
        {
            movable.Move(transform);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                ChangeMovable(new MovableMain());
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ChangeMovable(new MovableTrolley());
            }
        }

        private void ChangeMovable(IMovable movable)
        {
            this.movable = movable;
        }

        private void Shoot()
        {

        }

        private void Hurt()
        {

        }
    }
}