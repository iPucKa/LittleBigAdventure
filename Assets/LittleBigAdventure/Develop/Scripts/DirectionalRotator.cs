using UnityEngine;

public class DirectionalRotator
{
	private Rigidbody2D _rigidbody;	
	private Transform _transform;

	public DirectionalRotator(Rigidbody2D rigidbody, Transform transform)
	{
		_rigidbody = rigidbody;
		_transform = transform;
	}

	private Quaternion TurnRight => Quaternion.identity;

	private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

	private Vector2 CurrentVelocity => _rigidbody.velocity;

	public void Update(float deltaTime)
	{
		if (CurrentVelocity.magnitude < 0.05f)
			return;

		ApplyRotation(CurrentVelocity);
	}

	private void ApplyRotation(Vector2 velocity) => _transform.rotation = GetRotationFrom(velocity);

	private Quaternion GetRotationFrom(Vector2 velocity)
	{
		if (velocity.x > 0f)
			return TurnRight;

		if (velocity.x < 0f)
			return TurnLeft;

		return _transform.rotation;
	}
}
