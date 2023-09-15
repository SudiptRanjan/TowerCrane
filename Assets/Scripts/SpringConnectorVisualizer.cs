using UnityEngine;

public class SpringConnectorVisualizer : MonoBehaviour
{
	public SpringJoint joint;
	public LineRenderer lineRenderer;
	public Vector3 offset;

	private void Start()
	{
		joint = GetComponent<SpringJoint>();
	}

	private void Update()
	{
		lineRenderer.SetPosition(0,transform.position);
		lineRenderer.SetPosition(1, offset + joint.connectedBody.transform.position);
	}

}
