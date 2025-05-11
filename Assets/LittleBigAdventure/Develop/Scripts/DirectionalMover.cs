public class DirectionalMover
{
	private float _movementSpeed;

	private float _horizontalVelocity;

	public DirectionalMover(float movementSpeed)
	{
		_movementSpeed = movementSpeed;
	}

	public float CurrentHorizontalVelocity => _horizontalVelocity;

	public void SetHorizontalVelocity(float xDirection) => _horizontalVelocity = xDirection * _movementSpeed;
}

