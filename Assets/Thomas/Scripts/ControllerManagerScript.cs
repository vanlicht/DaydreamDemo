using UnityEngine;
using System.Collections;

public class ControllerManagerScript : MonoBehaviour
{
    public GameObject player;
    public float playerHeight= 1.6f;
    public LineRenderer laser;
    public float LaserLength = 0.25f;
	public GameObject reticle;

    Vector3 currentTargetPos;
    private GameObject collidedObject;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { this.transform.position + new Vector3(0, 0, 0.055f), this.transform.position + new Vector3(0, 0, LaserLength) };
        laser.SetPositions(initLaserPositions);
        laser.SetWidth(0.01f, 0.001f);
    }

    void LateUpdate()
    {
        //Query controller rotation
        Quaternion ori = GvrController.Orientation;
        this.transform.localRotation = ori;

        Vector3 v = ori * Vector3.forward;

        ShootLaserFromControllerPosition(this.transform.position, v, 200f);
        laser.enabled = true;

        //if (GvrController.ClickButtonUp)
        //{
        //    // teleport to location
        //    Vector3 pointerTeleportPos = new Vector3(currentTargetPos.x - 0.46f, 0.81f, currentTargetPos.z + 1.3f);
        //    gameObject.transform.position = pointerTeleportPos;
        //    Vector3 camTeleportPos = new Vector3(currentTargetPos.x, 1.6f, currentTargetPos.z);
        //    player.transform.position = camTeleportPos;
        //}
    }

    void ShootLaserFromControllerPosition( Vector3 controllerPosition, Vector3 direction, float length )
	{
		Ray ray = new Ray(controllerPosition, direction );
		RaycastHit raycastHit;

		if( Physics.Raycast( ray, out raycastHit, length ) )
        {
            currentTargetPos = raycastHit.point;
            Vector3[] LaserPositions = new Vector3[2] { controllerPosition + new Vector3(0, 0, 0.055f), raycastHit.point };
            laser.SetPositions(LaserPositions);
            Debug.Log(raycastHit.point);
            collidedObject = raycastHit.transform.gameObject;
            //if (collidedObject.tag == "FruitTag")
            //{
            //    Destroy (raycastHit.transform.gameObject);
            //}
   //         if (collidedObject.tag == "ground") {
   //             // Show the target and follow track to the pointer
   //             currentTargetPos = raycastHit.point;
   //             reticle.transform.position = currentTargetPos;
			//}
		}
        else
        {
            currentTargetPos = controllerPosition + (direction * LaserLength);
            Vector3[] LaserPositions = new Vector3[2] { controllerPosition + (direction *  0.055f), currentTargetPos};
            laser.SetPositions(LaserPositions);
            
        }
        reticle.transform.position = currentTargetPos;


        //Vector3 endPosition = controllerPosition + ( length * direction );
        //laser.SetPosition( 0, controllerPosition);
        //laser.SetPosition( 1, endPosition );
    }
}
