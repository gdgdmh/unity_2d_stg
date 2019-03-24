using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Number002の表示制御を行う
/// 子にスプライトレンダラーが設定されていることが前提
/// </summary>
public class DisplayNumber002 : MonoBehaviour {

	public DisplayNumber002() {
	}

	public void Start() {

		numSprites = new Sprite[kNumSpriteNum];
		for (int i = 0; i < kNumSpriteNum; ++i) {
			numSprites[i] = Resources.Load<Sprite>("Textures/num002/num002_" + string.Format("{0:00}", i));
			//numSprites[i] = Resources.Load<Sprite>("Textures/num002/num002_00");
			MhCommon.Assert(numSprites[i] != null, "DisplayNumber002::Start() Resource.Load Sprite failure");
		}
		//sprite = Resources.Load<Sprite>("Textures/num002/num002_00");


		// 子に設定されているSpriteRendererを取得する
		numSpriteRenderers = new SpriteRenderer[kDisplaySpriteNum];
		SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
		for (int i = 1; i <= kDisplaySpriteNum; ++i) {
			string targetSpriteName = string.Format(kDefaultGameObjectFormat, i);
			foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
				string spriteName = spriteRenderer.name;
				// 名前に対応したスプライトを取得
				if (targetSpriteName == spriteName) {
					numSpriteRenderers[i - 1] = spriteRenderer;
					//MhCommon.Print("Get=" + i);
					break;
				}
			}
			MhCommon.Assert(numSpriteRenderers[i - 1] != null, "DisplayNumber002::Start() SpriteRenderer not set=" + i);
		}

		int[] dummyNums = {1, 2, 3, 0, 0, 0, 0, 0, 0, 0};
		int count = 0;
		foreach (SpriteRenderer spriteRenderer in numSpriteRenderers) {
			spriteRenderer.sprite = numSprites[dummyNums[count]];
			++count;
		}

		/*
		Component obj = this.gameObject.GetComponent("Num1");
		MhCommon.Assert(obj != null, "DisplayNumber002::Start null");
		GameObject obj2 = (GameObject)obj.gameObject;
		MhCommon.Assert(obj2 != null, "DisplayNumber002::Start null2");
		*/

		/*
		if (firstTime) {
			MhCommon.Print("start called");
			sprite = Resources.Load<Sprite>("Textures/num002/num002_01");
			renderer = this.gameObject.GetComponent<SpriteRenderer>();

			

			//sprit

			//renderer2 = renderer;
			//Instantiate(renderer, new Vector3(0, 1, 0), Quaternion.identity);
			firstTime = false;
		}
		*/

		//sprite = this.gameObject.GetComponent<Sprite>();
		//sprite = Resources.Load<Sprite>("Textures/num002/num002_00");
		//MhCommon.Assert(sprite != null, "DisplayNumber002::Start() null");
		//MhCommon.Print(sprite.ToString());
//フォルダごとまとめて読込みたい場合
//Sprite[] image = Resources.LoadAll<Sprite> ("Images/enemy/");
		//renderer.sprite = sprite;

		//MhCommon.Print("aaaa");
		//Instantiate(renderer, new Vector3(0, 0, 0), Quaternion.identity);

		/*
		//renderer = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sprite = Resources.Load<Sprite>("Textures/num002/num002_00");
		MhCommon.Assert(sprite != null, "DisplayNumber002::Start() null");
		MhCommon.Print(sprite.ToString());
//フォルダごとまとめて読込みたい場合
//Sprite[] image = Resources.LoadAll<Sprite> ("Images/enemy/");
		renderer.sprite = sprite;

		Instantiate(renderer, new Vector3(0, 0, 0), Quaternion.identity);
		*/
	}

	/// <summary>
	/// 数値の表示設定
	/// </summary>
	/// <param name="num"></param>
	public void Set(int num) {
	}

	static readonly string kDefaultGameObjectFormat = "Num{0:00}";
	static readonly int kNumSpriteNum = 10;
	static readonly int kDisplaySpriteNum = 10;
	protected SpriteRenderer[] numSpriteRenderers;
	protected Sprite[] numSprites;
	// 画像を持っている(0～9)
	// 

	//GameObject.Find("ScoreImage").GetComponent<Image>().sprite= numimage[number[0]];
	// とりあえず画像を表示してみる

	////private GameObject go;
	//private Sprite sprite;
	////public Sprite sprite2;
	//private new SpriteRenderer renderer;
	////private new SpriteRenderer renderer2;
	//bool firstTime = true;

}
