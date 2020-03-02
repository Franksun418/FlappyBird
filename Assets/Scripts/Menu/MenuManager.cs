using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Game:
                SceneManager.LoadScene("Menu");
                break;
            case MenuName.GameOverPage:
                Object.Instantiate(Resources.Load("GameOverPage"));
                break;
        }
    }
}