using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class START : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("NotInMissionScene");
    }
}
