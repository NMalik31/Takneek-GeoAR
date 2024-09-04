using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOWTOPLAY : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlayMenu;
    public void HowToPlay()
    {
        MainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }
}
