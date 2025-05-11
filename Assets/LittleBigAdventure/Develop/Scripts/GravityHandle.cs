using UnityEngine;

public class GravityHandle
{
	private float _gravity;
	private ObstacleChecker _groundChecker;

	public GravityHandle(ObstacleChecker groundChecker, float gravity)
	{
		_groundChecker = groundChecker;
		_gravity = gravity;
	}

	public void ApplyGravity(ref float verticalVelocity)
	{
		if (_groundChecker.IsTouches() && verticalVelocity <= 0)
			verticalVelocity = 0;
		
		else
			verticalVelocity -= _gravity * Time.deltaTime;
	}
}
