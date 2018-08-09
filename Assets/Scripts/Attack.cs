using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    Animator m_Animator;

	void Start () {

        m_Animator = gameObject.GetComponent<Animator>();
		
	}
	
	void Update () {

        if (Input.GetKey(KeyCode.Space)) {

            m_Animator.ResetTrigger("End");
            m_Animator.SetTrigger("Attack");
        }
		
        if (Input.GetKey(KeyCode.DownArrow)) {

            m_Animator.ResetTrigger("Attack");
            m_Animator.SetTrigger("End");
        }
	}
}







