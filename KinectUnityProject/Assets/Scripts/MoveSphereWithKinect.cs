using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Windows.Kinect;

public class MoveSphereWithKinect : MonoBehaviour
{

    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    private float t;
    public Camera camera1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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
                float handx = body.Joints[JointType.HandRight].Position.X;
                float handy = body.Joints[JointType.HandRight].Position.Y;
                this.transform.position = (new Vector3(handx * 15, handy * 15, 0.0f));

            }
        }
    }

    void OnCollisionEnter()
    {
        t = Time.time;
    }

    void OnCollisionStay(Collision collision)
    {
        if(Time.time > t + 2)
        {
            SceneManager.LoadScene(collision.gameObject.name);
        }
    }
}