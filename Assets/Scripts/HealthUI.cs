using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour {

    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Image healthSlider;

	// Use this for initialization
	void Start () {
		foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            ui = Instantiate(uiPrefab, c.transform).transform;
            ui.position = target.position;
            healthSlider = ui.GetChild(0).GetComponent<Image>();
            break;
        }

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
	}    

    void OnHealthChanged (int maxHealth, int currentHealth)
    {
        if (ui != null)
        {
            ui.gameObject.SetActive(true);

            // changing slider amount based on taken damage
            float healthpercent = currentHealth / (float)maxHealth;
            healthSlider.fillAmount = healthpercent;
            if (currentHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
    }
}
