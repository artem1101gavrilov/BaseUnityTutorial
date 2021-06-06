using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewCubeCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> Hearts;
    #region Ссылка на класс с нужным событием.
    [SerializeField] private CubeCreator heartSystem;
    #endregion

    [SerializeField] private GameObject RestartButton;
    [SerializeField] private Text Score;

    #region Подписка и отписка
    private void OnEnable()
    {
        heartSystem.OnChangeHealth += DisplayHealth;
        heartSystem.OnChangeScore += DisplayScore;
    }

    private void OnDisable()
    {
        heartSystem.OnChangeHealth -= DisplayHealth;
        heartSystem.OnChangeScore -= DisplayScore;
    }
    #endregion

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < Hearts.Count; i++)
        {
            Hearts[i].SetActive(health > i);
        }
        if (health <= 0)
        {
            RestartButton.SetActive(true);
        }
    }

    private void DisplayScore(int score)
    {
        Score.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
