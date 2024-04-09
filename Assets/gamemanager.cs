using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public int ganar;
    // Start is called before the first frame update
    void Start()
    {
        ganar = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (ganar==0)
        {
            SceneManager.LoadScene("ganar");
        }
    }
    public void cc()
    {
        ganar--;
    }
}
