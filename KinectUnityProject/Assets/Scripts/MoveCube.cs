using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class MoveCube : MonoBehaviour {

	public Windows.Kinect.JointType _jointType;
	public GameObject _bodySourceManager;
	private BodySourceManager _bodyManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_bodySourceManager == null)
		{
			return;
		}

		_bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
		if (_bodyManager == null)
		{
			return;
		}

		Body[] data = _bodyManager.GetData();
		if (data == null)
		{
			return;
		}

		// get the first tracked body…
		foreach (var body in data)
		{
			if (body == null)
			{
				continue;
			}

			if (body.IsTracked)
			{
				if (body.HandRightState == HandState.Open) {
					this.gameObject.transform.position = new Vector3 (1.0f, 0.0f, 0.0f);
				}
				if (body.HandLeftState == HandState.Open) {
					this.gameObject.transform.position = new Vector3 (-1.0f, 0.0f, 0.0f);
				}
				if (body.HandLeftState == HandState.Lasso || body.HandRightState == HandState.Lasso) {
					this.gameObject.transform.position = new Vector3 (0.0f, 2.0f, 0.0f);
				}
//				var pos = body.Joints[_jointType].Position;
//				this.gameObject.transform.position = new Vector3(pos.X, pos.Y, pos.Z);
//				break;
			}
		}
	}
}
