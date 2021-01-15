using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class GameOverUIManager : MonoBehaviour
{
    #region Public&Private Fields
    //Public:
	
    //Private:
	private Button button;
    #endregion
 
    #region Own Methods
	public void ClickPlayAgain(){
//        SceneManager.LoadScene("Main");
    }

    #endregion

    #region Unity Methods
    void Start()
    {
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(ClickPlayAgain);
    }
 
    void Update()
    {
	
    }
    #endregion
}