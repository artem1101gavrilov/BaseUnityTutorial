using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public int health;
    public GameObject Heart1, Heart2, Heart3, Heart4;

    #region Изменение данных.
    [SerializeField] private List<GameObject> Hearts;
    #region Разделение на отображение.
    [SerializeField] private HeartSystemView heartView;
    #endregion
    #region Событие.
    public event System.Action<int> OnChangeHealth;
    #endregion
    #endregion

    private void Update()
    {
        switch (health)
        {
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                break;
            case 4:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                break;
        }
    }

    #region Постепенное изменение от меня
    private void ChangeHealth()
    {
        #region 1. Избавляемся от громоздкого switch
        Heart1.SetActive(health > 0);
        Heart2.SetActive(health > 1);
        Heart3.SetActive(health > 2);
        #endregion
        #region 2. Переносим в массив
        for (int i = 0; i < Hearts.Count; i++)
        {
            Hearts[i].SetActive(health > i);
        }
        #endregion
        #region 3. Использование класса для отображения
        heartView.Display(health);
        #endregion
        #region 4. Перевод в событийную модель
        // На версии C#6 используйте сокращенную версию: 
        // OnChangeHealth?.Invoke(health);
        // Я использую код, который подойдет для старых версий Unity и для C#4
        if (OnChangeHealth != null) OnChangeHealth(health);
        #endregion
    }
    #endregion
}
