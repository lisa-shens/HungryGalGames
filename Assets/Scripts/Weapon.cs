using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
	public GameObject laserStart;
	private GameObject crosshair;
	public GameObject spriteSelected;
	public LineRenderer laserLineRenderer;
	public SpriteRenderer targetRenderer;
	private bool rendered = false;

	private void Start()
    {

    }

    void Update()
	{

		if (Input.GetKeyDown(KeyCode.Mouse0) && rendered == false)
		{
			rendered = true;
			crosshair = targetRenderer.gameObject;
			UpdateCrosshair(GetMouseWorldPosition());

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
				hit.collider.gameObject.GetComponent<Deer>().onHit();
			}

			//Vector3 dir3D = crosshair.transform.position - transform.position;
			//transform.up = dir3D;
			//dir3D.Normalize();
			//float angle = Mathf.Atan2(dir3D.y, dir3D.x) * Mathf.Rad2Deg;
			//angle -= 90;
			//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
