using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour {

    public CameraBase() {
    }

    private void Awake() {
        // アスペクト比の固定
        Camera camera = GetComponent<Camera>();
        Rect rect = CalcAspect(aspectX, aspectY);
        camera.rect = rect;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// アスペクト比の計算
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    Rect CalcAspect(float width, float height) {
        float targetAspect = width / height;
        float windwAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windwAspect / targetAspect;
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (scaleHeight < 1.0f) {
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            rect.width = 1.0f;
            rect.height = scaleHeight;
        } else {
            float scaleWidth = 1.0f / scaleHeight;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0.0f;
            rect.width = scaleWidth;
            rect.height = 1.0f;
        }
        return rect;
    }

    public float aspectX = 9.0f;
    public float aspectY = 16.0f;
}
