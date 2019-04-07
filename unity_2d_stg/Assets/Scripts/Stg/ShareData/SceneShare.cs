﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーン間共有データ
/// </summary>
public class SceneShare : SingletonMonoBehaviour<SceneShare> {

    private void Awake() {
        if (this != Instance) {
            // すでに存在しているなら破棄
            Destroy(this);
        } else {
            // シーン遷移したときに破棄させない
            DontDestroyOnLoad(this.gameObject);
        }
        Initialize();
    }

    private void OnDestroy() {
    }

    public void Initialize() {
        inputSystem = new InputSystem();
        inputSystem.Initialize();
        inputSystem.SetDisplaySize(ApplicationConstant.GetDisplayWidth(), ApplicationConstant.GetDisplayHeight());
		gameTemporaryData = new GameTemporaryData();
		gameTemporaryData.Initialize();
    }

    public InputSystem GetInput() {
        return inputSystem;
    }

	public GameTemporaryData GetGameTemporaryData() {
		return gameTemporaryData;
	}

    // Use this for initialization
    //void Start () {
	//}
	
	// Update is called once per frame
	//void Update () {	
	//}

    private InputSystem inputSystem;
    private ApplicationConstant applicationConstant;
	private GameTemporaryData gameTemporaryData; // ゲーム保持一時データ

}
