﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordParent : MonoBehaviour {

    public GameObject FreeSword;
    public GameObject hand_r;

    public void SetParent(GameObject hand_r) {

        FreeSword.transform.parent = hand_r.transform;
        Debug.Log("Sword's Parent: " + FreeSword.transform.parent.parent.name);
    }

  
}