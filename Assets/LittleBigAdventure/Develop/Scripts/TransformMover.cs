using UnityEngine;

public class TransformMover
{
	private Transform _transform;
	private float _speed;

	public TransformMover(Transform transform, float speed)
	{
		_transform = transform;
		_speed = speed;
	}

	public void Update(float deltaTime)
	{
		_transform.Translate(Vector2.down * _speed * Time.deltaTime);
	}
}
