using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void ClickButtonReset()
    {
        SceneManager.LoadScene(0);

    }
}
