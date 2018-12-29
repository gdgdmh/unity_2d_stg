using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneTask : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneShare.Instance.Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        UnitySingleTouchAction touchAction = SceneShare.Instance.GetInput().GetSingleTouchAction();
        touchAction.Update();
        if (touchAction.IsTouchBegan()) {
            MhCommon.Print("TitleScene -> MainMenuScene");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }
        //UnityEngine.SceneManagement.SceneManager.LoadScene("DebugMenuScene");
    }
}
