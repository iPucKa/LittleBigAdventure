using UnityEngine;

public class VelocityManager
{
	private GravityHandle _gravityHandle;
	private WindHandle _windHandle;

	private Vector2 _velocity;
	private float _yVelocity;
	private float _xVelocity;

	public VelocityManager(GravityHandle gravityHandle, WindHandle windHandle)
	{
		_gravityHandle = gravityHandle;
		_windHandle = windHandle;
	}

	public Vector2 CurrentVelocity => _velocity;

	public void Update(float deltaTime)
	{
		_gravityHandle.ApplyGravity(ref _yVelocity);
		_windHandle.ApplyWind(ref _xVelocity);
		
		SetVelocity(_xVelocity, _yVelocity);		
	}

	private void SetVelocity(float horizontal, float vertical) => _velocity = new Vector2(horizontal, vertical);

	public void SetHorizontalVelocity(float xVelocity) => _xVelocity = xVelocity;
	
	public void SetVerticalVelocity(float yVelocity) => _yVelocity = yVelocity;
}
