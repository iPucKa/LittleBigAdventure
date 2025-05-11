using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] private SwitchHandler _handler;
	[SerializeField] private float _timeToFall;
	[SerializeField] private float _fallingSpeed;

	private Mover _mover;
	private Timer _timer;

	private bool _isFalling;

	public bool IsActivated => _handler.IsOn;

	private bool IsFalling => _isFalling;

	private void Awake()
	{
		_mover = new Mover(transform, _fallingSpeed);
		_timer = new Timer(this, _timeToFall);
	}

	private void Update()
	{
		if (IsActivated == false)
		{
			if (_timer.InProcess(out float elapsedTime))
				_timer.StopProcess();
			
			if (_isFalling == false)
				return;
		}

		if (IsActivated == true)
			TimerProcess();

		if (IsFalling == true)
			_mover.Update(Time.deltaTime);
	}

	private void TimerProcess()
	{
		if (_timer.InProcess(out float time) == false)
		{
			_timer.StartProcess();
			return;
		}

		if (_timer.InProcess(out float elapsedTime) && elapsedTime >= _timeToFall)
		{
			_isFalling = true;
			_mover.SetDirection(Vector2.down);
		}
	}
}
