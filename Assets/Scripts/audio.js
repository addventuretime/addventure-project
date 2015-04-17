#pragma strict

var welcomeAudio : AudioClip;

function Start () {
	Debug.Log("Start");
	audio.PlayOneShot(welcomeAudio);
}

function Update () {
//	Debug.Log("Update");
}

@script RequireComponent(AudioSource)