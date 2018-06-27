using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
	// animator for monster object
	private Animator m_animator;


	void Start () {
		m_animator = gameObject.GetComponent<Animator>();
		m_animator.SetBool ("Run", false);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
			m_animator.SetBool ("Run", true);

		}
		if (Input.GetKeyUp(KeyCode.W)) {
			m_animator.SetBool ("Run", false);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			m_animator.SetFloat ("Chase", 1.0f);
		} 
		if (Input.GetKeyUp(KeyCode.S)) {
			m_animator.SetFloat ("Chase", 0.0f);
		}
	}
}
