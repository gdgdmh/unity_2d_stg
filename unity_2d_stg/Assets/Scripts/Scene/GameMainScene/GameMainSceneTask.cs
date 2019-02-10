using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSceneTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneShare.Instance.Initialize();

		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();
		GameObject bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal, new Object2dFloatPosition(0, 0));
		//StgBulletBase bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal, new Object2dFloatPosition(0, 0));
		Instantiate(bullet, new Vector3(0.0f, -3.0f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
