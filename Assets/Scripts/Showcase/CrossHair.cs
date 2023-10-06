using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
	public GameObject laserStart;
	private GameObject crosshair;
	public GameObject spriteSelected;
	public LineRenderer laserLineRenderer;
	public SpriteRenderer targetRenderer;
	private bool rendered = false;
	//public DeerSpawn deerScript;

	private void Start()
    {

    }

    void Update()
	{
		if (rendered == false)
		{
			rendered = true;
			crosshair = targetRenderer.gameObject;
			UpdateCrosshair(GetMouseWorldPosition());
			//deerScript.StartSpawning();
		}
		else if (rendered == true && crosshair)
		{
			UpdateCrosshair(GetMouseWorldPosition());

			Vector2 origin = transform.position;
			Vector2 target = crosshair.transform.position;
			Vector2 direction = target - origin;
			RaycastHit2D hit = Physics2D.Raycast(origin, direction, direction.magnitude);
			if (hit.collider != null)
			{
				hit.collider.gameObject.GetComponent<onAppleHIt>().onHit();
			}
		}
	}

	Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = 0;
		return mouseWorldPos;
	}

	void UpdateCrosshair(Vector3 newCrosshairPosition)
	{
		crosshair.transform.position = newCrosshairPosition;
		laserLineRenderer.SetPosition(0, laserStart.transform.position);
		laserLineRenderer.SetPosition(1, crosshair.transform.position);
	}
}
