using UnityEngine;
using System.Collections;

public class ControllerManagerScript : MonoBehaviour {

	public LineRenderer laser;
	public GameObject redTarget;
	//public GameObject pointerObject;
	public Camera mainCam;

	Vector3 currentTargetPos;

	void Start () {
		Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
		laser.SetPositions( initLaserPositions );
		laser.SetWidth( 0.01f, 0.01f );
	}
	
	void Update () {
		Quaternion ori = GvrController.Orientation;
		gameObject.transform.localRotation = ori;

		Vector3 v = GvrController.Orientation * Vector3.forward;

		ShootLaserFromTargetPosition( transform.position, v, 200f );
		laser.enabled = true;

		if (GvrController.ClickButtonUp) {
			// teleport to location
			Vector3 pointerTeleportPos = new Vector3 (currentTargetPos.x - 0.46f, 0.81f, currentTargetPos.z + 1.3f);
			gameObject.transform.position = pointerTeleportPos;
			Vector3 camTeleportPos = new Vector3 (currentTargetPos.x , 1.6f, currentTargetPos.z);
			mainCam.transform.position = camTeleportPos;
		}
	}

	void ShootLaserFromTargetPosition( Vector3 targetPosition, Vector3 direction, float length )
	{
		Ray ray = new Ray( targetPosition, direction );
		RaycastHit raycastHit;

		if( Physics.Raycast( ray, out raycastHit, length ) ) {
			GameObject gameObj = raycastHit.transform.gameObject;
			if (gameObj.tag == "FruitTag") {
				Destroy (raycastHit.transform.gameObject);
			} else if (gameObj.tag == "GroundTag") {
				// Show the target and follow track to the pointer
				currentTargetPos = new Vector3 (raycastHit.point.x,
					redTarget.transform.localPosition.y,
					raycastHit.point.z);
				redTarget.transform.localPosition = currentTargetPos;
			}
		}

		Vector3 endPosition = targetPosition + ( length * direction );
		laser.SetPosition( 0, targetPosition );
		laser.SetPosition( 1, endPosition );
	}
}
