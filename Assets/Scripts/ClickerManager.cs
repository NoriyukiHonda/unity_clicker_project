using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
	const string TOTAL_CLICK_KEY = "TotalClick";
	const string POWER_KEY = "Power";
	const string TOTAL_DAMAGE_KEY = "TotalDamage";
	[SerializeField] Text fpsText;
	[SerializeField] Text totalClickText;
	[SerializeField] Text powerText;
	[SerializeField] Text totalDamageText;

	int counter = 0;
	int totalClick = 0;
	int power = 0;
	int totalDamage = 0;

	void Start()
	{
		LoadData();
	}

	void LoadData()
	{
		totalClick = PlayerPrefs.GetInt(TOTAL_CLICK_KEY, 0);
		power = PlayerPrefs.GetInt(POWER_KEY, 0);
		totalDamage = PlayerPrefs.GetInt(TOTAL_DAMAGE_KEY, 0);
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			AddTotalClick();
			CauseDamage();
			InstantiateItems();
		}

		DrawText();
	}

	void InstantiateItems()
	{
		var localVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		var prefab = (GameObject)Resources.Load("Prefabs/ClickerObject");
		for (int rad = 0; rad < 360; rad += 30)
		{
			// 八方向にInstantiate
			var item = Instantiate(prefab, localVector3, Quaternion.identity, this.gameObject.transform);
			var clickerObject = item.GetComponent<ClickerObject>();
			clickerObject.Initialize(rad, 100);
		}
	}

	void DrawText()
	{
		counter++;
		if (counter >= 30)
		{
			fpsText.text = "FPS:" + (1f / Time.deltaTime).ToString("f2");
			counter = 0;
		}

		totalClickText.text = "クリック総数:" + totalClick.ToString();

		powerText.text = "パワー:" + power.ToString();
		totalDamageText.text = "トータルダメージ:" + totalDamage.ToString();
	}

	void AddTotalClick()
	{
		totalClick++;
	}

	void CauseDamage()
	{
		totalDamage += power;
	}

	void OnDestroy()
	{
		SaveData();
	}

	void SaveData()
	{
		PlayerPrefs.SetInt(TOTAL_CLICK_KEY, totalClick);
		PlayerPrefs.SetInt(POWER_KEY, power);
		PlayerPrefs.SetInt(TOTAL_DAMAGE_KEY, totalDamage);
		PlayerPrefs.Save();
	}

	public void OnClick()
	{
		AddPower();
	}

	void AddPower()
	{
		power++;
	}
}
