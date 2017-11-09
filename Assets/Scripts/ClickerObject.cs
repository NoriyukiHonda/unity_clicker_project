using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerObject : MonoBehaviour
{
	public void Initialize(float direction, float speed)
	{
		var rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
		Vector2 v = new Vector2();
		v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
		v.y = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
		rigidBody.velocity = v;
	}

	void Update()
	{
		if((0 > this.gameObject.transform.position.x || this.gameObject.transform.position.x > Screen.width) ||
		   (0 > this.gameObject.transform.position.y || this.gameObject.transform.position.y > Screen.height))
		{
			Destroy(this.gameObject);
		}
	}
}
