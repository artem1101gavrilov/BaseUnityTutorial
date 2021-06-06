using System;
using System.Collections;
using UnityEngine;

public class GameCube : MonoBehaviour
{
    [SerializeField] private Material redMaterial;
    /// <summary>
    /// Размер последнего установленного куба.
    /// </summary>
    private float size;
    private bool canIncrease = true;
    private MeshRenderer meshRenderer;
    private Action<float> created;
    private Action destroyed;
    private float speed = 2.0f;

    internal void Init(float size, Action<float> created, Action destroyed)
    {
        this.size = size;
        this.created = created;
        this.destroyed = destroyed;
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (canIncrease)
        {
            IncreaseSize();
            EndIncrease();
            CheckSize();
        }
    }

    private void CheckSize()
    {
        if (transform.localScale.x > size)
        {
            StartCoroutine(Destroying());
        }
    }

    private void IncreaseSize()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.localScale += Vector3.one * Time.deltaTime * speed;
        }
    }

    /// <summary>
    /// Окончание увеличения куба, передача данных в создание кубов.
    /// </summary>
    private void EndIncrease()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            canIncrease = false;
            created(transform.localScale.x);
        }
    }

    /// <summary>
    /// Останавливаем увеличение и уничтожаем данный куб.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Destroying()
    {
        canIncrease = false;
        meshRenderer.material = redMaterial;
        yield return new WaitForSeconds(1);
        destroyed();
        Destroy(gameObject);
    }
}
