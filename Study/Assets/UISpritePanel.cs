using UnityEngine;
using System.Collections;

public class UISpritePanel : MonoBehaviour {

	Sprite[] loadingCircle;

	int spriteIndex;
	float timer = 0.1f;
	float delay = 0.1f;

	// Use this for initialization
	void Start () {
		loadingCircle = Resources.LoadAll<Sprite>("Sprites/LoadingCircle");
		spriteIndex = 0;
		print (loadingCircle.Length);
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if(timer < 0){
			print (spriteIndex);
			spriteIndex++;
			if(spriteIndex == loadingCircle.Length){
				spriteIndex = 0;
			}
			timer = delay;
		}
	}

	void OnGUI(){
		Sprite s = loadingCircle [spriteIndex];
		Texture t = s.texture;
		Rect tr = s.textureRect;
		Rect r = new Rect (tr.x/t.width,tr.y/t.height,tr.width/t.width,tr.height/t.height);
		GUI.DrawTextureWithTexCoords (new Rect(0,0,tr.width,tr.height),t,r);
		//GUI.DrawTexture (new Rect(0,0,100,100),loadingCircle[spriteIndex].texture);
	}
}
