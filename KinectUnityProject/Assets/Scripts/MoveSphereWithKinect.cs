using UnityEngine;
using UnityEngine.SceneManagement;
using Windows.Kinect;

public class MoveSphereWithKinect : MonoBehaviour
{

    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    private bool sizeScreen;
    private float t;
    private float armLength;

    // Use this for initialization
    void Start()
    {
        sizeScreen = false;
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
                if (!sizeScreen)
                {
                    armLength = (Mathf.Abs(body.Joints[JointType.ShoulderLeft].Position.X) + Mathf.Abs(body.Joints[JointType.ShoulderRight].Position.X)) * 2;
                    sizeScreen = true;
                }
                else
                {
                    float xPosition = ((body.Joints[JointType.HandRight].Position.X - body.Joints[JointType.ShoulderRight].Position.X) / armLength) * 9.0f;
                    float yPosition = (body.Joints[JointType.HandRight].Position.Y / armLength) * 5.0f;
                    gameObject.transform.position = new Vector3(xPosition, yPosition, 0.0f);
                }

            }
        }
    }

    void OnTriggerEnter()
    {
        t = Time.time;
    }

    void OnTriggerStay(Collider collision)
    {
        if(Time.time > t + 2)
        {
            SceneManager.LoadScene(collision.gameObject.name);
        }
    }
}