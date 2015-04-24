#pragma strict

var noMatchForMeAudio: AudioClip;

 private var allAudioSources : AudioSource[];
  
 function Awake() {
     allAudioSources = FindObjectsOfType(AudioSource) as AudioSource[];
 }
  
 function StopAllAudio() {
     for(var audioS : AudioSource in allAudioSources) {
         audioS.Stop();
     }
 }
 
 function OnTriggerEnter(trigger:Collider) {
 	Debug.Log("Collision");
 	StopAllAudio();
 	GetComponent.<AudioSource>().PlayOneShot(noMatchForMeAudio);
 }
 
 @script RequireComponent(AudioSource)