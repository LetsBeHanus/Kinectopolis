using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Windows.Kinect;

public class SlingshotKinectTest : MonoBehaviour {

	// Necessary variables for Kinect implementation
	public GameObject _bodySourceManager;
	private BodySourceManager _bodyManager;
	private bool sizeScreen;
	private float t;
	private float armLength;

	//Necessary variables from ProjectileDragging
	public float maxStretch = 6.0f;
	public LineRenderer slingshotLineFront;
	public LineRenderer slingshotLineBack;  
	private SpringJoint2D spring;
	private Transform slingshot;

	//private Ray rayToMouse;
	private Ray rayToOrb;

	private Ray leftSlingshotToProjectile;
	private float maxStretchSqr;
	private float circleRadius;


	//private bool clickedOn;
	private bool triggerOn;

	private Vector2 prevVelocity;


	void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		slingshot = spring.connectedBody.transform;
	}


	// Use this for initialization
	void Start () {
		sizeScreen = false;


		LineRendererSetup ();
		rayToOrb = new Ray(slingshot.position, Vector3.zero);
		leftSlingshotToProjectile = new Ray(slingshotLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
		circleRadius = circle.radius;
	}
	
	// Update is called once per frame
	void Update () {
		if (_bodySourceManager == null) {
			return;
		}

		_bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();

		if (_bodyManager == null) {
			return;
		}

		Body[] data = _bodyManager.GetData();

		if (data == null) {
			return;
		}

		// get the first tracked body…
		foreach (var body in data) {
			if (body == null) {
				continue;
			}

			if (body.IsTracked) {
				if (!sizeScreen) {
					armLength = (Mathf.Abs(body.Joints[JointType.ShoulderLeft].Position.X) + Mathf.Abs(body.Joints[JointType.ShoulderRight].Position.X)) * 2;
					sizeScreen = true;
				}
				else {
					float xPosition = ((body.Joints[JointType.HandRight].Position.X - body.Joints[JointType.ShoulderRight].Position.X) / armLength) * 9.0f;
					float yPosition = (body.Joints[JointType.HandRight].Position.Y / armLength) * 5.0f;
					gameObject.transform.position = new Vector3(xPosition, yPosition, 0.0f);
				}

			}
		}



		if (triggerOn)
			Dragging ();

		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy (spring);
				GetComponent<Rigidbody2D>().velocity = prevVelocity;
			}

			if (!triggerOn)
				prevVelocity = GetComponent<Rigidbody2D>().velocity;

			LineRendererUpdate ();

		} else {
			slingshotLineFront.enabled = false;
			slingshotLineBack.enabled = false;
		}
	}

	void OnMouseDown () {
		spring.enabled = false;
		triggerOn = true;
	}

	void OnMouseUp () {
		spring.enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		triggerOn = false;
	}

	void OnTriggerEnter() {
		t = Time.time;
	}

	void LineRendererSetup () {
		slingshotLineFront.SetPosition(0, slingshotLineFront.transform.position);
		slingshotLineBack.SetPosition(0, slingshotLineBack.transform.position);

	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 slingshotToMouse = mouseWorldPoint - slingshot.position;

		if (slingshotToMouse.sqrMagnitude > maxStretchSqr) {
			rayToOrb.direction = slingshotToMouse;
			mouseWorldPoint = rayToOrb.GetPoint(maxStretch);
		}

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void OnTriggerStay(Collider collision) {
		if(Time.time > t + 2) {
			Dragging ();



		}
	}

	void LineRendererUpdate () {
		Vector2 slingshotToProjectile = transform.position - slingshotLineFront.transform.position;
		leftSlingshotToProjectile.direction = slingshotToProjectile;
		Vector3 holdPoint = leftSlingshotToProjectile.GetPoint(slingshotToProjectile.magnitude + circleRadius);
		slingshotLineFront.SetPosition(1, holdPoint);
		slingshotLineBack.SetPosition(1, holdPoint);
	}

	void onTriggerExit(Collider other) {
		
	}

}