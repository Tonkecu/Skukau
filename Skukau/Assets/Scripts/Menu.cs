using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); //указываем номер сцены для загрузки
    }
    public void SeeTeach()
    {
        SceneManager.LoadScene(2); //указываем номер сцены для загрузки
    }
}

