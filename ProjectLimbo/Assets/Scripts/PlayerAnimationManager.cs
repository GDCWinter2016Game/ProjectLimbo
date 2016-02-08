using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

	private Animator animator;
	private PlayerController playerController;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(playerController.currentState == PlayerState.Running){
			animator.SetBool("Running", true);
		}
		else{
			animator.SetBool("Running", false);
		}
	
	}
}
