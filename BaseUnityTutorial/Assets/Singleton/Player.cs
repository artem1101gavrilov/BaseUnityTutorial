using UnityEngine;

namespace Singleton
{
    public class Player : MonoBehaviour
    {
        public static Player instance { get; private set; }
        public string Name { get; set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Name = "Lana";
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private Player()
        {

        }

        public void Say()
        {
            Debug.Log(Name);
        }
    }
}