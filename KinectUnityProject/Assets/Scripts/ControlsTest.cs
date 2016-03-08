using UnityEngine;
using System.Collections;

public class ControlsTest : MonoBehaviour 
{

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public LineRenderer lineRenderer;

	private GameObject lineGO;
	private int i = 0;


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

		if(Input.GetKey( KeyCode.Mouse0 ))
		{
			lineRenderer.SetVertexCount(i+1);
			Vector3 mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mPosition += new Vector3 (0, 0, 10);
			lineRenderer.SetPosition(i, mPosition);
			i++;
				
				
				
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
