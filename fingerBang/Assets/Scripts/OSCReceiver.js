
//You can set these variables in the scene because they are public 
public var RemoteIP : String = "127.0.0.1";
public var SendToPort : int = 6448;
public var ListenerPort : int = 12000;
public var controller : Transform; 
private var handler : Osc;
private var sig1 : int = 0;
private var lastFeat: float = 1; 

public var bulletPrefab: GameObject;
public var rightBulletSpawn: Transform;
public var leftBulletSpawn: Transform;

public var fireRate: float = 0.4;
private var nextShot: float = 0;

public var maxAmmo: int = 10;
private var currentAmmo: int;
public var reloadSpeed: float = 1;

//public var rightAmmoCount: guiText;


public function Start ()
{
	//Initializes on start up to listen for messages
	//make sure this game object has both UDPPackIO and OSC script attached
	
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(RemoteIP, SendToPort, ListenerPort);
	handler = GetComponent("Osc");
	handler.init(udp);
			

	//Tell Unity to call function Example1 when message /wek/outputs arrives
	handler.SetAddressHandler("/wek/outputs", Example1);

	//Starts with current ammo
	currentAmmo = maxAmmo;

}
Debug.Log("OSC Running");

//Use the values from OSC to do stuff
function Update () {
	
		if (sig1 == 1 && Time.time > nextShot) {

			//If current ammo is more than zero then fire weapon
			if (currentAmmo > 0) {
				nextShot = Time.time + fireRate;
				RightFire();
			}
		}

		 if (sig1 == 2){
			Reload();
		}

		if (sig1 == 3 && Time.time > nextShot) {

			//If current ammo is more than zero then fire weapon
			if (currentAmmo > 0) {
				nextShot = Time.time + fireRate;
				LeftFire();
			}
		}

}

//This is called when /wek/outputs arrives, since this is what's specified in Start()
public function Example1(oscMessage : OscMessage) : void
{	
	
	Debug.Log("Called Example One > " + Osc.OscMessageToString(oscMessage));
	Debug.Log("Message Values > " + oscMessage.Values[0] + " " + oscMessage.Values[1]);
	sig1 = oscMessage.Values[0];

} 

function RightFire(){

var bullet: GameObject;
bullet = Instantiate (bulletPrefab, rightBulletSpawn.transform.position, rightBulletSpawn.transform.rotation) as GameObject;

bullet.GetComponent(Rigidbody).velocity = bullet.transform.forward * 6;


	// Destroy the bullet after 2 seconds
	Destroy(bullet, 2.0f);

	//Lose one bullet everytime the weapon is shot
	currentAmmo--;

}

function LeftFire(){

var bullet: GameObject;
bullet = Instantiate (bulletPrefab, leftBulletSpawn.transform.position, leftBulletSpawn.transform.rotation) as GameObject;

bullet.GetComponent(Rigidbody).velocity = bullet.transform.forward * 6;


	// Destroy the bullet after 2 seconds
	Destroy(bullet, 2.0f);

	//Lose one bullet everytime the weapon is shot
	currentAmmo--;

}

	function Reload(){
		
		Debug.Log ("Reloading...");

		//Get accessor to a new wait with a reload speed
		yield new WaitForSeconds (reloadSpeed);

		//When reloading, current ammo grabs the max ammo
		currentAmmo = maxAmmo;

	
	}


