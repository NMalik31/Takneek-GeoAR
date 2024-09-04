using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BACK : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlayMenu;
    public void Back()
    {
        MainMenu.SetActive(true);
        HowToPlayMenu.SetActive(false);
    }
}
