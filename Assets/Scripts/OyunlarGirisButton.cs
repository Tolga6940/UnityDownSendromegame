using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunlarGirisButton : MonoBehaviour
{
    public void OyunGiris()
    {
        SceneManager.LoadScene(1);
    }
}
