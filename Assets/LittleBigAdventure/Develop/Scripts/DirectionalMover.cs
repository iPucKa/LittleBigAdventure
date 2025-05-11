public class DirectionalMover
{
	private VelocityManager _velocityManager;
	private float _movementSpeed;

	private float _horizontalVelocity;

	public DirectionalMover(VelocityManager velocityManager, float movementSpeed)
	{
		_velocityManager = velocityManager;
		_movementSpeed = movementSpeed;
	}

	public float CurrentHorizontalVelocity => _horizontalVelocity;
	
	public void SetHorizontalVelocity(float xDirection) => _velocityManager.SetHorizontalVelocity(xDirection * _movementSpeed);
}

