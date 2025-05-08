using System.Collections.Generic;
using UnityEngine;

public class DirectionalJumper
{
	private ObstacleChecker _groundChecker;
	private ObstacleChecker _ceilChecker;
	private List<ObstacleChecker> _wallCheckers;

	private float _yVelocityForJump;
	private float _yVelocityForWallJump;
	private float _gravity;

	private float _yVelocity;
	private bool _jumpPressed;

	public DirectionalJumper(
		ObstacleChecker groundChecker, 
		ObstacleChecker ceilChecker, 
		List<ObstacleChecker> wallCheckers, 
		float yVelocityForJump, 
		float gravity)
	{
		_groundChecker = groundChecker;
		_ceilChecker = ceilChecker;
		_wallCheckers = wallCheckers;
		_yVelocityForJump = yVelocityForJump;
		_yVelocityForWallJump = yVelocityForJump / 1.5f;
		_gravity = gravity;
	}

	public float CurrentVerticalVelocity => _yVelocity;

	public void SetJumpCondition(bool isJumpPressed) => _jumpPressed = isJumpPressed;

	public void Update(float deltaTime)
	{
		HandleGravity();
		HandleGroundJump();
		HandWallJump();
		HandleCeil();
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

	private void HandWallJump()
	{
		if (_jumpPressed)
			for (int i = 0; i < _wallCheckers.Count; i++)
			{
				if (_wallCheckers[i].IsTouches())
					_yVelocity = _yVelocityForWallJump;
			}			
	}

	private void HandleGravity()
	{
		if (_groundChecker.IsTouches() && _yVelocity <= 0)
			_yVelocity = 0f;
		else
			_yVelocity -= _gravity * Time.deltaTime;
	}
}
