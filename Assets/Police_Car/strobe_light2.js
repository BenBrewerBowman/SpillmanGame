#pragma strict

@script RequireComponent (Light)

public var time:float = 0.5f; //time between on and off
public var active = false;

function Start () {
	StartCoroutine("Flicker");
}

function Update () {
	if(Input.GetButtonDown("Fire1")) {
		active = !active;
		Debug.Log("Lights are :" + active);
	}
}
	
function Flicker (){
	while(boolean){
		GetComponent.<Light>().enabled = false;
		yield WaitForSeconds(time);
		if(active) {
			GetComponent.<Light>().enabled = true;
			yield WaitForSeconds(time);
		}
	}

}