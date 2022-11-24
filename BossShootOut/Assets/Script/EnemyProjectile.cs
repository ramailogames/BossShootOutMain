using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	Transform target;
	Rigidbody2D rigidBody;
	public float angleChangingSpeed;
	public float movementSpeed;
	private float angle;
	private Vector2 lastPosition;
	[SerializeField] GameObject explosion;
	private void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}
	private void Start()
	{
		GameManager.instance.SelectAShootPoint();
		target = GameManager.instance.currentShootPoint;
	}

	void FixedUpdate()
	{
		Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
		angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.Euler(0f, 0f, angle);
		lastPosition = transform.position;
		if (Vector2.Distance(((Vector2)target.position), rigidBody.position) >= 10.0f)
		{
			//			Vector2 direction = (Vector2)target.position - rigidBody.position;
			//			direction.Normalize ();
			//			float rotateAmount = Vector3.Cross (direction, transform.up).z;
			//			rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
			rigidBody.velocity = transform.up * movementSpeed;
		}
		else
		{
			rigidBody.velocity = 1 * transform.up * movementSpeed;
		}

		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerHealth>().TakeHealth(10f);
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (collision.CompareTag("Ground"))
		{

			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}


	}

}
