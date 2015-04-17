#pragma strict

var welcomeAudio : AudioClip;

function Start () {
	Debug.Log("Start");
	GetComponent.<AudioSource>().PlayOneShot(welcomeAudio);
}

function Update () {
//	Debug.Log("Update");
}

@script RequireComponent(AudioSource)