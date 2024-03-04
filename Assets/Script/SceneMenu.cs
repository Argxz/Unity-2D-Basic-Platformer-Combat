using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    public void KeScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}
