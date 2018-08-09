using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour {

    public Text health;
    public Text armor;

	// Use this for initialization
	void Start () {

        health.text = GetComponent<CharacterStats>().currentHealth.ToString();
        armor.text = GetComponent<CharacterStats>().armor.ToString();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
        GetComponent<CharacterStats>().OnArmorChanged += OnArmorChanged;
	}

    void OnHealthChanged(int currentHealth)
    {
        health.text = currentHealth.ToString();
    }

    void OnArmorChanged(int newArmor)
    {
        armor.text = newArmor.ToString();
    }

}
