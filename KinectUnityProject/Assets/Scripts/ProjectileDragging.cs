using UnityEngine;

public class ProjectileDragging : MonoBehaviour {
	
	public float maxStretch = 5.0f;
	public LineRenderer slingshotLineFront;
	public LineRenderer slingshotLineBack;  

	private SpringJoint2D spring;
	private Transform slingshot;
	private Ray rayToMouse;
	private Ray leftSlingshotToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private bool clickedOn;
	private Vector2 prevVelocity;


	void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		slingshot = spring.connectedBody.transform;
	}

	void Start () {
		LineRendererSetup ();
		rayToMouse = new Ray(slingshot.position, Vector3.zero);
		leftSlingshotToProjectile = new Ray(slingshotLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
		circleRadius = circle.radius;
	}

	void Update () {
		if (clickedOn)
			Dragging ();

		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy (spring);
				GetComponent<Rigidbody2D>().velocity = prevVelocity;
			}

			if (!clickedOn)
				prevVelocity = GetComponent<Rigidbody2D>().velocity;

			LineRendererUpdate ();

		} else {
			slingshotLineFront.enabled = false;
			slingshotLineBack.enabled = false;
		}
	}

	void LineRendererSetup () {
		slingshotLineFront.SetPosition(0, slingshotLineFront.transform.position);
		slingshotLineBack.SetPosition(0, slingshotLineBack.transform.position);

	}

	void OnMouseDown () {
		spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp () {
		spring.enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		clickedOn = false;
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 slingshotToMouse = mouseWorldPoint - slingshot.position;

		if (slingshotToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = slingshotToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		Vector2 slingshotToProjectile = transform.position - slingshotLineFront.transform.position;
		leftSlingshotToProjectile.direction = slingshotToProjectile;
		Vector3 holdPoint = leftSlingshotToProjectile.GetPoint(slingshotToProjectile.magnitude + circleRadius);
		slingshotLineFront.SetPosition(1, holdPoint);
		slingshotLineBack.SetPosition(1, holdPoint);
	}
}