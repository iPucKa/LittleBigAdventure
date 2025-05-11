using UnityEngine;

public class DirectionalMover
{
	private Rigidbody2D _rigidbody;
	private DirectionalJumper _jumper;
	private GravityHandle _gravityHandle;

	private float _movementSpeed;

	private Vector2 _velocity;
	private float _horizontalVelocity;

	public DirectionalMover(Rigidbody2D rigidbody, DirectionalJumper jumper, GravityHandle gravityHandle, float movementSpeed)
	{
		_rigidbody = rigidbody;
		_jumper = jumper;
		_gravityHandle = gravityHandle;
		_movementSpeed = movementSpeed;
	}

	public Vector2 CurrentVelocity => _velocity;

	public void SetHorizontalVelocity(float xDirection) => _horizontalVelocity = xDirection * _movementSpeed;	

	public void Update(float deltaTime)
	{
		_gravityHandle.ApplyGravity(ref _velocity.y);

		SetVelocity();
	}

	private void SetVelocity()
	{
		_velocity = new Vector2(_horizontalVelocity, _jumper.CurrentVerticalVelocity);

		_rigidbody.velocity = _velocity;
	}
}
