using System.Collections.Generic;
using UnityEngine;

public class DirectionalJumper
{
	private ObstacleChecker _groundChecker;
	private ObstacleChecker _ceilChecker;
	private List<ObstacleChecker> _wallCheckers;
	private GravityHandle _gravityHandle;

	private float _yVelocityForJump;
	private float _yVelocityForWallJump;

	private float _yVelocity;
	private bool _jumpPressed;

	public DirectionalJumper(
		ObstacleChecker groundChecker,
		ObstacleChecker ceilChecker,
		List<ObstacleChecker> wallCheckers,
		GravityHandle gravityHandle,
		float yVelocityForJump)
	{
		_groundChecker = groundChecker;
		_ceilChecker = ceilChecker;
		_wallCheckers = wallCheckers;
		_gravityHandle = gravityHandle;
		_yVelocityForJump = yVelocityForJump;
		_yVelocityForWallJump = yVelocityForJump / 1.5f;		
	}

	public float CurrentVerticalVelocity => _yVelocity;
	public bool IsJumping => _jumpPressed;

	public void SetJumpCondition(bool isJumpPressed) => _jumpPressed = isJumpPressed;

	public void Update(float deltaTime)
	{
		_gravityHandle.ApplyGravity(ref _yVelocity);

		HandleCeil();
		HandleGroundJump();
		HandleWallJump();
	}

	public bool IsGrounded() => _groundChecker.IsTouches();

	private void HandleCeil()
	{
		if (_ceilChecker.IsTouches())
			_yVelocity = Mathf.Min(0, _yVelocity);
	}

	private void HandleGroundJump()
	{
		if (_jumpPressed && _groundChecker.IsTouches())		
			_yVelocity = _yVelocityForJump;
	}

	private void HandleWallJump()
	{
		if (_jumpPressed)
			for (int i = 0; i < _wallCheckers.Count; i++)
			{
				if (_wallCheckers[i].IsTouches())
					_yVelocity = _yVelocityForWallJump;
			}			
	}
}
