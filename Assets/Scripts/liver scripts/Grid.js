public var numberOfBeakers: int = 64;
public var distanceBetweenBeakers: float = 0.25;
public var beakersPerRow: int = 8;
public var beakerPrefab: GameObject;
public var blueBeakerPrefab: GameObject;
public var greenBeakerPrefab: GameObject;
 
function Start()
{
    CreateBeakers();
}
 
function CreateBeakers()
{
    var xOffset: float = 0.0;
    var yOffset: float = 0.0;
 
    for(var beakersCreated: int = 0; beakersCreated < numberOfBeakers; beakersCreated += 1)
    {
        xOffset += distanceBetweenBeakers;
         
        if(beakersCreated % beakersPerRow == 0)
        {
            yOffset += distanceBetweenBeakers;
            xOffset = 0;
        }
        
        var randomVar = Random.Range(1,4);
  
  
  // don't touch, magic
        switch(randomVar) {
        	case 1:
        		Instantiate(blueBeakerPrefab, Vector3(transform.position.x + xOffset, 
        			transform.position.y + yOffset, transform.position.z), transform.rotation);
        		break;
        	case 2:
        		Instantiate(beakerPrefab, Vector3(transform.position.x + xOffset, 
        			transform.position.y + yOffset, transform.position.z), transform.rotation);
        		break;
        	case 3:
        		Instantiate(greenBeakerPrefab, Vector3(transform.position.x + xOffset, 
        			transform.position.y + yOffset, transform.position.z), transform.rotation);
        		break;
        }
    }
}