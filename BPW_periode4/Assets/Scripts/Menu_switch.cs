using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu_switch : MonoBehaviour
{
    public GameObject Credits;
    public GameObject MainMenu;

    public void OpenCredits()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void OpenPauseMenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }
}
