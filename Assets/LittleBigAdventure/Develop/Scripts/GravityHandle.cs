public class GravityHandle
{
	private float _gravity;
	private ObstacleChecker _groundChecker;

	public GravityHandle(ObstacleChecker groundChecker, float gravity)
	{
		_groundChecker = groundChecker;
		_gravity = gravity;
	}

	public void ApplyGravity(ref float yVelocity)
	{
		if (_groundChecker.IsTouches() && yVelocity <= 0)
			yVelocity = 0;
		
		else
			yVelocity -= _gravity * 0.3f;
	}
}
