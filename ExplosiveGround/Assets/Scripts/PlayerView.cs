using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerView : MonoBehaviour
{
    #region Public&Private Fields
    //Public:
	
    //Private:
	[SerializeField] Transform cameraP;
    [SerializeField] float camSensitivity;

    #endregion
 
    #region Own Methods
	
    #endregion

    #region Unity Methods
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * camSensitivity * Time.deltaTime;
        transform.Rotate(0f, y, 0f);
    }
    #endregion
}