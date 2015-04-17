#pragma strict

var collisionAudio: AudioClip;

 function OnTriggerEnter(trigger:Collider) {
 	Debug.Log("Collision");
 	GetComponent.<AudioSource>().PlayOneShot(collisionAudio);
 }
 
 @script RequireComponent(AudioSource)