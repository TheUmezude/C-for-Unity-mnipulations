// ************* Some useful C# scripts for manipulating game objects *****************



// Code to print statements to console screen -- Needs to be attached to a game object for execution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintToConsole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am printing to the console!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//*****************************************************************************************************************************************
// Code to rotate a game object (could be a holder game object or more).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpheres : MonoBehaviour
{
    Vector3 movement; // This allows for movement of objects, like rotations, etc.
	public int xi, yi, zi; // Do this if you want to be able to change the values of the x, y and z components from the Unity GUI
	// Start is called before the first frame update
    void Start()
    {
		movement = new Vector3(xi,yi,zi); // You can modify the 'yi' value from Unity to 30 to Initialize the first movement to rotate on the y-axis at 30 degree increments, for instance.
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(movement * Time.deltaTime);  // Subsequent movements after the first in increments of 30 degrees
	  // The '* Time.deltaTime is only being added to smoothen and slow down the rotations - It makes movement to be frame rate independent.
    }
}

//*****************************************************************************************************************************************

// Code to change from an image to another (note: Not Raw image) -- Can be attached to a button
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image original; // This is the image/sprite that is currently being displayed on the canvas
	public Sprite newSprite; // This would be for the new image that is intended to be created
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void NewImage()
	{
		original.sprite = newSprite; // Reassign the image being shown
	}
}

//********************************************************************************************************************************************

// Code to translate a game object (i.e. move a game object in a straight line on x, y or z axis -- without input from a source (like keyboard, mouse or gamepad)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate_object : MonoBehaviour
{
    [SerializeField] public float x=0.01f, y=0.01f, z=0.01f; // Creating publicly editable variables for x,y and z increments
    // These variables would be come modifiable from the Unity platform after they have been associated with a game object.
    // Adding the '[SerializeField]' keyword is supposed to make the variables modifiable from Unity --
    // -- but without it, by using the 'Public' keyword, the variables are still modifiable
    // Note that the 'f' keyword added at the back of the floating point numbers is to differ them from doubles
    // Start is called before the first frame update
    void Start()
    {
        // You only need to add translation codes here if you want to modify the first movement instance of the game object.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x, y, z); 
        // The 'transform' class and 'Translate' method would allow increments in x,y,z for the game object.
    }
}


//************************************************************************************************************************************************

// Code to translate object (i.e. move a game object on the x and z-axis -- with input from a source (like keyboard, mouse or gamepad)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate_object : MonoBehaviour
{
    // Instead of initializing vairables for public modification in Unity, such as:
    // [SerializeField] public float x_val=0.01f, y_val=0.01f, z_val=0.01f;
    // We can use Unity's in-built 'Input' class and 'GetAxis' method to get input from the keyboard. 
   
    // Start is called before the first frame update

    public float moveSpeed = 10f; // For adjusting the movement speed by a multiplier effect.
    void Start()
    {
        // You only need to add translation codes here if you want to modify the first movement instance of the game object.
    }

    // Update is called once per frame
    void Update()
    {
        AxisMovement(); // To make the code cleaner, I made a void function/method for axis movement below, and I am now calling it to execute in the update function
		// Pending what I want, I could also call it in the start function
    }
	
	void AxisMovement()
	{
		// Note that, unlike what was done above, the assigned values for x, y and z are made inside the update function 
        // This allows the software to keep looking out for keyboard input as the game progresses.
        // Note: You might, otherwise, decide to skip the entire assignemnt and just work from the 'transform.Translate' call.
        float x_val = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; // Adding 'Time.deltaTime' is just to slow down the movement.
        float z_val = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float y_val = 0.001f; // Modify based on how much up & down movement you want on your game object.
        transform.Translate(x_val, y_val, z_val);
        // The 'Input.GetAxix' allows us to make use of pre-initialized control information in Unity
        // This allows for movement controls in the horizontal, vertical planes, etc.
        // The 'transform' class and 'Translate' method would allow increments in x,y,z for the game object.
	}
}


//*************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // We removed the 'Start' and 'Update' methods because we do not intend this script to do anything in either of those dispositions
    private void OnCollisionEnter(Collision collision)
    {
        /*
         This is a callback method that Unity understands and implements whenever the 'Box Collider' on one game object meets the
        'box collider' on another game object (one that the script is attached to).
        When this normally happens, an 'Event' is triggered
         
        It is also a type 'private' method because it can only be used within the class.

        'collision' can be seen as a variable of type: Collision. In-other words, it can be given any other name.
         */

        // Making the game to get a 'MeshRenderer' type component which holds info about 'Materials', 'Lighting', 'Probes', etc.
        // In this case, I am asking for the material property to be gotten from 'Mesh Renderer'.
        // Under the material property, I am asking for the color sub-property to be modified.
        // I am then equating the material's color sub-property to the color names from Unity's documentation - type 'Color'

        // It is possible to only trigger this response when a particular object is contacted.
        // For that, we would need to use tags. To use tags, the game object would first have to be tagged from Unity's GUI
        if (collision.gameObject.tag == "Player") // The tag being used here is "Player"
        {
            /* 
            The 'if' statement is only being used in-order:
            for the response to only be triggered when the collision happens with a specific tag
            Note that in-order for this to work, the tag would have to first be assigned to the game object.
            REMOVE the 'if' statement if you do not want the action to be triggered when a particular object makes the collision.
             */
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Already Hit"; // Changing the tag of any obstacle being hit to allow for more modifications
        }
        
    }
}


//**************************************************************************************************************************************************

// Code to turn on/off components associated with a Game Object - In this case the 'Mesh Renderer' component and the 'Rigidbody' components would be toggled,
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float timecount = 5f; // This is to initialize the count time to a specific time value
    // Start is called before the first frame update
    void Start()
    {
        // I would need to firstly get access to the necessary components I want to toggle on/off, once the game starts.
        // Next, I would need to set the property of the component to False. (enabled is a property of every component).
        GetComponent<MeshRenderer>().enabled = false; // Disabling the Mesh Renderer component - to make the game object invisible
        // Note that you could also do this by creating a vairable of type 'MeshRenderer' and equal it to the 'GetComponent'
        // e.g: MeshRenderer renderer_variable;
        // renderer_variable = GetComponent<MeshRenderer>();
        // renderer_variable.enabled = false;

        GetComponent<Rigidbody>().useGravity = false; // Disabling the Rigidbody component
        // Note that you could also do this by creating a vairable of type 'RigidBody' and equal it to the 'GetComponent'
        // e.g: Rigidbody rigidbody_variable;
        // rigidbody_variable = GetComponent<MeshRenderer>();
        // renderer_variable.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Note that 'Time.time' returns the time that the game has been running for (for each moment it is called).
        if (Time.time > timecount) 
        {
            GetComponent<MeshRenderer>().enabled = true; // re-enabling the components
            GetComponent<Rigidbody>().useGravity = true; // re-enabling the components
        }    
    }
}
//*********************************************************************************************************************************************************
