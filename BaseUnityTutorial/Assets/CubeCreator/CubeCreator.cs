using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    /// <summary>
    /// Префаб куба, который будем создавать.
    /// </summary>
    [SerializeField] private GameObject Cube;
    /// <summary>
    /// Позиция для создания нового куба.
    /// </summary>
    [SerializeField] private Vector3 position;
    /// <summary>
    /// Размер последнего установленного куба.
    /// Изначально 5.
    /// </summary>
    private float size = 5;
    private bool canCreated = true;
    private int HP = 3;
    private int score = 0;

    public event System.Action<int> OnChangeHealth;
    public event System.Action<int> OnChangeScore;

    private void Update()
    {
        CreateCube();
    }

    private void CreateCube()
    {
        if (canCreated && Input.GetKeyDown(KeyCode.Mouse0))
        {
            var cube = Instantiate(Cube, position, Quaternion.identity).GetComponent<GameCube>();
            cube.Init(size, CompleteCreatedCube, DestroyingCreatedCube);
            canCreated = false;
        }
    }

    private void CompleteCreatedCube(float size)
    {
        this.size = size;
        score++;
        OnChangeScore(score);

        position.y += size;

        var positionCamera = transform.position;
        positionCamera.y += size;
        transform.position = positionCamera;

        canCreated = true;
    }

    private void DestroyingCreatedCube()
    {
        HP--;
        OnChangeHealth(HP);
        if(HP > 0) canCreated = true;
    }
}
