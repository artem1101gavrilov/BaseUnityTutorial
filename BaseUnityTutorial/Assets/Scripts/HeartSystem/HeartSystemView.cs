using System.Collections.Generic;
using UnityEngine;

public class HeartSystemView : MonoBehaviour
{
    [SerializeField] private List<GameObject> Hearts;
    #region Ссылка на класс с нужным соыбтием.
    private HeartSystem heartSystem;
    #endregion

    #region Подписка и отписка
    private void OnEnable()
    {
        heartSystem.OnChangeHealth += Display;
    }

    private void OnDisable()
    {
        heartSystem.OnChangeHealth -= Display;
    }
    #endregion

    public void Display(int health)
    {
        for (int i = 0; i < Hearts.Count; i++)
        {
            Hearts[i].SetActive(health > i);
        }
    }
}
