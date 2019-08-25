using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void RetryButton()
    {
        SceneManager.LoadScene("3_stage");
        Time.timeScale = 1f;
    }

}
