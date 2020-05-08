using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//public float barMaxSize, barMinSize, barSize,barSize;
	public float currentEnergy, maxEnergy, energyCoef;
	public float energyTimer, energyRegen;
	public GameObject energyBarProgress;
	public GameObject energyBarProgressBarSprite;
	public GameObject energyBarText, generatorCostText;
	public int currentGeneratorLevel, generatorNextLevelCost;
	private float energyTimerSet;
	public Color newColor;
	public SpriteRenderer pbBarSR;
	public int money;

	// Use this for initialization
	void Start () {
		GeneratorLevelControl ();
	}
	
	// Update is called once per frame
	void Update () {
		EnergyBar ();
		EnergyGain ();
	}

	public void EnergyBar(){
		energyCoef = currentEnergy / maxEnergy;
		Vector3 barSizeV = energyBarProgress.GetComponent<Transform> ().localScale;
		barSizeV.x=energyCoef;
		energyBarProgress.GetComponent<Transform> ().localScale = barSizeV;
		energyBarText.GetComponent<TextMesh> ().text = currentEnergy + " / " + maxEnergy;

		Color newColor = new Color ((255-186*energyCoef)/255, (70 + 185*energyCoef)/255, (28 + 58 * energyCoef)/255, 1);

		pbBarSR.color = newColor;
		//print (newColor);
	}

	public void GeneratorLevelControl(){
		if (currentGeneratorLevel == 1) {
			maxEnergy = 100;
			energyTimer = 2f;
			energyTimerSet = 2f;
			energyRegen = 8f;

			generatorNextLevelCost=100;
			generatorCostText.GetComponent<TextMesh> ().text = generatorNextLevelCost+"$";
		}
		if (currentGeneratorLevel == 2) {
			maxEnergy = 150;
			energyTimer = 2f;
			energyTimerSet = 2f;
			energyRegen = 12f;

			generatorNextLevelCost=500;
			generatorCostText.GetComponent<TextMesh> ().text = generatorNextLevelCost+"$";
		}

		if (currentGeneratorLevel == 3) {
			maxEnergy = 250;
			energyTimer = 1.9f;
			energyTimerSet = 1.9f;
			energyRegen = 15f;

			generatorNextLevelCost=1500;
			generatorCostText.GetComponent<TextMesh> ().text = generatorNextLevelCost+"$";
		}


	}

	public void EnergyGain(){
		energyTimer = energyTimer - Time.deltaTime;
		if (energyTimer <= 0) {
			energyTimer = energyTimerSet;
			currentEnergy = currentEnergy + energyRegen;
			if(currentEnergy>=maxEnergy)
			{
				currentEnergy = maxEnergy;	
			}
		}
	}

	public void GeneratorLevelUp(){
		if (money >= generatorNextLevelCost && currentGeneratorLevel == 2) {
			money = money - generatorNextLevelCost;
			currentGeneratorLevel = 3;
			GeneratorLevelControl ();
		}

		if (money >= generatorNextLevelCost && currentGeneratorLevel == 1) {
			money = money - generatorNextLevelCost;
			currentGeneratorLevel = 2;
			GeneratorLevelControl ();
		}
	}
}
