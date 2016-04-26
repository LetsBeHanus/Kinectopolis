using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Windows.Kinect;

public class ControlsTest : MonoBehaviour 
{

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public LineRenderer lineRenderer;

	private GameObject lineGO;
	private int i = 0;
	public GameObject _bodySourceManager;
	private BodySourceManager _bodyManager;
	private bool sizeScreen;
	private float t;
	private float armLength;



	void Start()
	{
		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineRenderer = lineGO.GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.3F, 0);
		lineRenderer.SetVertexCount(0);
	}

	void Update()
	{
//		if (_bodySourceManager == null)
//		{
//			return;
//		}
//
//		_bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
//		if (_bodyManager == null)
//		{
//			return;
//		}
//
//		Body[] data = _bodyManager.GetData();
//		if (data == null)
//		{
//			return;
//		}
//
//		// get the first tracked body…
//		foreach (var body in data)
//		{
//			if (body == null)
//			{
//				continue;
//			}
//
//			if (body.IsTracked)
//			{
//				if (!sizeScreen)
//				{
//					armLength = (Mathf.Abs(body.Joints[JointType.ShoulderLeft].Position.X) + Mathf.Abs(body.Joints[JointType.ShoulderRight].Position.X)) * 2;
//					sizeScreen = true;
//				}
//				else
//				{
//					float xPosition = ((body.Joints[JointType.HandRight].Position.X - body.Joints[JointType.ShoulderRight].Position.X) / armLength) * 9.0f;
//					float yPosition = (body.Joints[JointType.HandRight].Position.Y / armLength) * 5.0f;
//					//gameObject.transform.position = new Vector3(xPosition, yPosition, 0.0f);
//					lineRenderer.SetVertexCount(i+1);
//					//	Vector3 mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//					Vector3 mPosition = new Vector3 (xPosition, yPosition, 10);
//					lineRenderer.SetPosition(i, mPosition);
//					i++;
//
//
//
//					/* Add Collider */
//
//						BoxCollider bc = lineGO.AddComponent<BoxCollider>();
//						bc.transform.position = mPosition;
//						bc.size = new Vector3(0.1f, 0.1f,0.1f);
//				}
//
//			}
//		}

		if(Input.GetKey( KeyCode.Mouse0 ))
		{
			lineRenderer.SetVertexCount(i+1);
			Vector3 mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mPosition += new Vector3 (0, 0, 10);
			lineRenderer.SetPosition(i, mPosition);
			//i++;
				
				
				
				/* Add Collider */

			BoxCollider bc = lineGO.AddComponent<BoxCollider>();
			bc.transform.position = mPosition;
			bc.size = new Vector3(0.1f, 0.1f,0.1f);
				
				
		}
		else

		{
			/* Remove Line */

			lineRenderer.SetVertexCount(i);
			i = 0;

			/* Remove Line Colliders */

			BoxCollider[] lineColliders = lineGO.GetComponents<BoxCollider>();

			foreach(BoxCollider b in lineColliders)
			{
				Destroy(b);
			}
		}

	}


}
