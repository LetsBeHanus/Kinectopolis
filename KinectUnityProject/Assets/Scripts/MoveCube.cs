using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class MoveCube : MonoBehaviour {
    
	public GameObject _bodySourceManager;
    public float speed;
	private BodySourceManager _bodyManager;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
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
                animator.SetBool("righthigh", false);
                animator.SetBool("rightlow", false);
                animator.SetBool("lefthigh", false);
                animator.SetBool("leftlow", false);

                if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0.0f, speed, 0.0f, ForceMode.Force);
                    animator.SetBool("righthigh", true);
                }
                else if (body.Joints[JointType.HandRight].Position.Y <= body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddTorque(0.0f, 0.0f, -1.5f);
                    animator.SetBool("rightlow", true);
                }
				
                if (body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0.0f, speed, 0.0f, ForceMode.Force);
                    animator.SetBool("lefthigh", true);
                }
                else if (body.Joints[JointType.HandLeft].Position.Y <= body.Joints[JointType.SpineShoulder].Position.Y)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddTorque(0.0f, 0.0f, 1.5f);
                    animator.SetBool("leftlow", true);
                }
			}
		}
	}

    void OnCollisionEnter()
    {
        this.gameObject.transform.position = new Vector3(0.0f, 7.47f, -0.3f);
    }
}
