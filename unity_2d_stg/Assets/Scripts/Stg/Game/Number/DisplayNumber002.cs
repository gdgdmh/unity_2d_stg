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
		basePosition.x = 2.0f;
		basePosition.y = 0;
		basePosition.z = 0;
		offset.x = -0.4f;
		offset.y = 0;
		offset.z = 0;

		// SpriteRendererの位置を設定
		ApplyPosition();
		{
			Vector3 position = basePosition;
			foreach (SpriteRenderer spriteRenderer in numSpriteRenderers) {
				spriteRenderer.sprite = numSprites[dummyNums[count]];
				++count;
			}
		}
	}

	/// <summary>
	/// 数値の表示設定
	/// </summary>
	/// <param name="num"></param>
	public void Set(int num) {
	}

	/// <summary>
	/// 基準位置を設定(1桁目を基準とする)
	/// </summary>
	/// <param name="position"></param>
	public void SetBasePosition(Vector3 position) {
		basePosition = position;
	}

	/// <summary>
	/// 数字間のオフセットを指定
	/// </summary>
	/// <param name="offset">オフセット</param>
	public void SetOffset(Vector3 offset) {
		this.offset = offset;
	}

	/// <summary>
	/// 基準位置やオフセットを適用する
	/// </summary>
	public void ApplyPosition() {
		Vector3 position = basePosition;
		foreach (SpriteRenderer spriteRenderer in numSpriteRenderers) {
			spriteRenderer.transform.position = position;
			position.x += offset.x;
			position.y += offset.y;
			position.z += offset.z;
			//MhCommon.Print(spriteRenderer.transform.position.x);
		}

	}

	static readonly string kDefaultGameObjectFormat = "Num{0:00}";
	static readonly int kNumSpriteNum = 10;
	static readonly int kDisplaySpriteNum = 10;
	protected SpriteRenderer[] numSpriteRenderers;
	protected Sprite[] numSprites;

	protected Vector3 basePosition; // 基準位置(1桁目の位置)
	protected Vector3 offset;		// 1桁ごとにずらすオフセット
	//protected Vector3 

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
