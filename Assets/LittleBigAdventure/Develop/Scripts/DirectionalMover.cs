using UnityEngine;

public class DirectionalMover
{
	private Rigidbody2D _rigidbody;
	private DirectionalJumper _jumper;

	private float _movementSpeed;

	private Vector2 _velocity;

	public DirectionalMover(Rigidbody2D rigidbody, DirectionalJumper jumper, float movementSpeed)
	{
		_rigidbody = rigidbody;
		_jumper = jumper;
		_movementSpeed = movementSpeed;
	}

	public Vector2 CurrentVelocity => _velocity;

	public void SetHorizontalVelocity(float xDirection)
	{
		float horizontalVelocity = xDirection * _movementSpeed;

		_velocity = new Vector2(horizontalVelocity, _jumper.CurrentVerticalVelocity);
	}

	public void Update(float deltaTime) 
	{
		_rigidbody.velocity = CurrentVelocity; 
	}
}
