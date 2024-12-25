using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Camera moveCamera;
    public Camera windowCamera;
    public Camera potCamera;

    public GameObject pizzaPref;
    public GameObject hotDogPref;
    private void Awake()
    {
        singlton = this;
        CamChanger(0);
    }
    public static Manager singlton { get; private set; }
    /// <summary>
    /// 0 - moveCamera,     
    /// 1 - windowCamera,   
    /// 2 - potCamera
    /// </summary>
    /// <param name="numCamera"></param>
    public void CamChanger(int numCamera)
    {
        switch (numCamera)
        {
            case 0:
                moveCamera.enabled = true;
                windowCamera.enabled = false;
                //potCamera.enabled = false;
                break;
            case 1:

                moveCamera.enabled = false;
                windowCamera.enabled = true;
                //potCamera.enabled = false;
                break;
            case 2:
                moveCamera.enabled = false;
                windowCamera.enabled = false;
                //potCamera.enabled = true;
                break;
                
        }
    }
    /// <summary>
    /// спавнит объект из координат камеры Window
    /// </summary>
    /// <param name="obj"></param>
    public GameObject Spawn(GameObject pref)
    {
        return(Instantiate(pref,windowCamera.transform));

    }
}
