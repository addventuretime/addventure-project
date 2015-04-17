#pragma strict

var collisionAudio: AudioClip;

 function OnTriggerEnter(trigger:Collider) {
 	Debug.Log("Collision");
 	audio.PlayOneShot(collisionAudio);
 }
 
 @script RequireComponent(AudioSource)