using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GMsuicide : MonoBehaviour
{
    private void Start()
    {
        Invoke("Restart", 11f);
    }

    private void Restart()
    {
        SceneManager.LoadScene("1_Denial");
    }
}
