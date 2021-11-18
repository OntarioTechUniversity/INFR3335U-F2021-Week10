using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("OnScreen Controls Properties")]
    public GameObject onScreenControls;

    // Start is called before the first frame update
    void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                break;
            default:
                onScreenControls.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
    }


}
