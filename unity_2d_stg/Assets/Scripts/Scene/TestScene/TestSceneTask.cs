using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneTask : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneShare.Instance.Initialize();
        MhCommon.Print("TestSceneTask::Start() SceneShare Initialize");
        //SceneShare.Instance.GetInput
        //ShareData.Instance.
		
	}
	
	// Update is called once per frame
	void Update () {
        SceneShare.Instance.GetInput().GetSingleTouchAction().Update();
        SceneShare.Instance.GetInput().GetSingleTouchAction().PrintDifference();
	}
}
