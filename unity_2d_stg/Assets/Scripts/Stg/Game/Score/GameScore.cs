﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour {

	private void Awake() {
		// Resourceから作成版
		//displayNumber = (GameObject)Resources.Load("Prefabs/Common/Number/DisplayNumber002");
		//MhCommon.Assert(displayNumber != null, "GameScore::Start() displayNumber null");
		//displayNumber002 = displayNumber.GetComponent<DisplayNumber002>();
		//MhCommon.Assert(displayNumber002 != null, "GameScore::Start() displayNumber002 null");
		//Instantiate(displayNumber, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
	}

	// Start is called before the first frame update
	void Start() {
		{
			// DisplayNumber002 のGameObjectとスクリプトを取得
			displayNumber = GameObject.Find("DisplayNumber002");
			MhCommon.Assert(displayNumber != null, "GameScore::Awake DisplayNumber002 Find Failure");
			displayNumber002 = displayNumber.GetComponent<DisplayNumber002>();
			MhCommon.Assert(displayNumber002 != null, "GameScore::Awake DisplayNumber002(Component Script DisplayNumber002) Find Failure");
			// 555に設定
			displayNumber002.Set(System.Int32.MinValue);
			displayNumber002.SetBasePosition(new Vector3(2.5f, 4.5f, 0));
			displayNumber002.SetOffset(new Vector3((-0.32f / 2), 0, 0));
			displayNumber002.SetScale(new Vector3(0.5f, 0.5f, 1.0f));
			//SetScale
			displayNumber002.ApplyPosition();
		}

		// Resourceから作成版
		//displayNumber002.Set(555);
		//displayNumber002.SetBasePosition(new Vector3(2.5f, 4.5f, 0.0f));
		//displayNumber002.SetOffset(new Vector3(-0.32f, 0.0f, 0.0f));
		//displayNumber002.ApplyPosition();
    }

    // Update is called once per frame
    void Update() {
    }

	private GameObject displayNumber;
	private DisplayNumber002 displayNumber002;
}
