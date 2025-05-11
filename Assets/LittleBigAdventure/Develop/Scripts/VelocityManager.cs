using UnityEngine;

public class VelocityManager
{
	private GravityHandle _gravityHandle;
	private DirectionalJumper _jumper;
	private DirectionalMover _mover;

	private Vector2 _velocity;
	private float _yVelocity;
	private float _xVelocity;

	public VelocityManager(
		GravityHandle gravityHandle,
		DirectionalJumper jumper,
		DirectionalMover mover)
	{
		_gravityHandle = gravityHandle;
		_jumper = jumper;
		_mover = mover;
	}

	public Vector2 CurrentVelocity => _velocity;

	public void Update(float deltaTime)
	{
		_jumper.Update(Time.deltaTime);	

		_xVelocity = _mover.CurrentHorizontalVelocity;
		_yVelocity = _jumper.CurrentVerticalVelocity;

		_gravityHandle.ApplyGravity(ref _yVelocity);
		
		SetVelocity(_xVelocity, _yVelocity);		
	}

	private void SetVelocity(float horizontal, float vertical) => _velocity = new Vector2(horizontal, vertical);
}
