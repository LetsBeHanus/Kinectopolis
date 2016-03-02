using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class MoveCube : MonoBehaviour {
    
	public GameObject _bodySourceManager;
    public float speed;
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
				
                if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0.0f, speed, 0.0f, ForceMode.Force);
                }
                else if (body.Joints[JointType.HandRight].Position.Y <= body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddTorque(0.0f, 0.0f, -1.5f);
                }
				
                if (body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0.0f, speed, 0.0f, ForceMode.Force);
                }
                else if (body.Joints[JointType.HandLeft].Position.Y <= body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddTorque(0.0f, 0.0f, 1.5f);
                }
			}
		}
	}

    void OnCollisionEnter()
    {
        this.gameObject.transform.position = new Vector3(0.0f, 1.0f, -0.3f);
    }
}
