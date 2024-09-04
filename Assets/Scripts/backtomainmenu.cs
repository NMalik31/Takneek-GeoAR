using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomainmenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Start");
    }
}
