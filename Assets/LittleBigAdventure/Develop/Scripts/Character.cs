using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rigidbody;
	[SerializeField] private ObstacleChecker _groundChecker;
	[SerializeField] private ObstacleChecker _ceilChecker;
	[SerializeField] private List<ObstacleChecker> _wallCheckers;

	[SerializeField] private float _yVelocityForJump;
	[SerializeField] private float _gravity;
	[SerializeField] private float _wind;

	[SerializeField] private float _speed;

	private GravityHandle _gravityHandle;
	private WindHandle _windHandle;
	private DirectionalJumper _jumper;
	private DirectionalMover _mover;

	private VelocityManager _velocityManager;

	private DirectionalRotator _rotator;

	private bool _isDead;

	public Vector2 Velocity => _rigidbody.velocity;

	public bool IsDead => _isDead;

	private void Awake()
	{
		_windHandle = new WindHandle(_groundChecker, _wind);
		_gravityHandle = new GravityHandle(_groundChecker, _gravity);
		_velocityManager = new VelocityManager(_gravityHandle, _windHandle);

		_jumper = new DirectionalJumper(_groundChecker, _ceilChecker, _wallCheckers, _velocityManager, _yVelocityForJump);
		_mover = new DirectionalMover(_velocityManager, _speed);


		_rotator = new DirectionalRotator(_rigidbody, transform);
	}

	private void Update()
	{
		_jumper.Update(Time.deltaTime);
		_velocityManager.Update(Time.deltaTime);

		_rotator.Update(Time.deltaTime);

		_rigidbody.velocity = _velocityManager.CurrentVelocity;
	}

	public bool IsGrounded() => _jumper.IsGrounded();

	public void SetHorizontalVelocity(float xDirection) => _mover.SetHorizontalVelocity(xDirection);

	public void SetJumpCondition(bool IsJumpPressed) => _jumper.SetJumpCondition(IsJumpPressed);

	public void Dead() => _isDead = true;
}
