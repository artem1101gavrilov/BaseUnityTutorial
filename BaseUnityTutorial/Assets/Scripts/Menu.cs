using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт меню, в нашем случае всего лишь 1 кнопка.
/// </summary>
public class Menu : MonoBehaviour
{
    /// <summary>
    /// Кнопка смены музыки.
    /// </summary>
    [SerializeField] private Image ButtonMusic;

    /// <summary>
    /// Спрайт для включенной музыки.
    /// </summary>
    [SerializeField] private Sprite SpriteMusicOn;
    /// <summary>
    /// Спрайт для выключенной музыки.
    /// </summary>
    [SerializeField] private Sprite SpriteMusicOff;

    /// <summary>
    /// Наша музыка.
    /// </summary>
    [SerializeField] private AudioSource Music;

    /// <summary>
    /// Играет ли музыка.
    /// </summary>
    private bool isPlayMusic;

    private void Start()
    {
        isPlayMusic = PlayerPrefs.GetInt("Music", 1) == 1;
        // Убираем воспроизведения с самого начала, т.к. пока непонятно почему не ставится сразу на паузу.
        Music.Play();
        SetMusic();
    }

    /// <summary>
    /// Метод для смены музыки.
    /// </summary>
    public void ChangeMusic()
    {
        isPlayMusic = !isPlayMusic;
        SetMusic();
    }

    /// <summary>
    /// Включение/выключение музыки.
    /// </summary>
    private void SetMusic()
    {
        if (isPlayMusic)
        {
            ChangeSpriteButton(SpriteMusicOn);
            UnPauseMusic();
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            ChangeSpriteButton(SpriteMusicOff);
            PauseMusic();
            PlayerPrefs.SetInt("Music", 0);
        }
    }

    /// <summary>
    /// Смена спрайта кнопки.
    /// </summary>
    /// <param name="sprite">Новая картинка.</param>
    private void ChangeSpriteButton(Sprite sprite)
    {
        ButtonMusic.sprite = sprite;
    }

    /// <summary>
    /// Включаем музыку после паузы.
    /// </summary>
    private void UnPauseMusic()
    {
        Music.UnPause();
    }

    /// <summary>
    /// Ставим музыку на паузу.
    /// </summary>
    private void PauseMusic()
    {
        Music.Pause();
    }
}
