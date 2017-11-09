using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
	[SerializeField] Text fpsText;
	[SerializeField] Text clickAmountText;
	[SerializeField] Text objectAmountText;

	int counter = 0;
	int clickAmount = 0;
	int objectAmount = 0;

	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			clickAmount++;
			var localVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			// プレハブを取得
			var prefab = (GameObject)Resources.Load("Prefabs/ClickerObject");
			for(int rad = 0; rad < 360; rad+=30)
			{
				// prefabを八方向にInstantiate
				var item = Instantiate(prefab, localVector3, Quaternion.identity, this.gameObject.transform);
				var clickerObject = item.GetComponent<ClickerObject>();
				clickerObject.Initialize(rad, 100);
				objectAmount++;
			}
		}

		counter++;
		if(counter >= 30)
		{
			fpsText.text = "FPS:" + (1f / Time.deltaTime).ToString("f2");
			counter = 0;
		}

		clickAmountText.text = "クリック回数:" + clickAmount.ToString();

		objectAmountText.text = "オブジェクト数:" + objectAmount.ToString();
	}
}
