using UnityEngine;

public class Mover
{
	private Transform _transform;
	private float _speed;

	private Vector2 _direction;

	public Mover(Transform transform, float speed)
	{
		_transform = transform;
		_speed = speed;
	}

	public void Update(float deltaTime)
	{
		Move();
	}

	public void SetDirection(Vector3 direction)
	{
		_direction = direction;
	}

	private void Move()
	{
		_transform.Translate(_direction * _speed * Time.deltaTime);
	}
}
