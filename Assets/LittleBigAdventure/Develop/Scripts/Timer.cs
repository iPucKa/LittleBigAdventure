using System.Collections;
using UnityEngine;

public class Timer
{
	private float _timeLimit;
	private MonoBehaviour _coroutineRunner;

	private float _time;
	private Coroutine _process;

	public Timer(MonoBehaviour coroutineRunner, float timeLimit)
	{
		_coroutineRunner = coroutineRunner;
		_timeLimit = timeLimit;
	}

	public bool InProcess(out float elapsedTime)
	{
		if (_process == null)
		{
			elapsedTime = 0;
			return false;
		}

		elapsedTime = _time;
		return true;
	}

	public void StartProcess()
	{
		if (_process != null)
			_coroutineRunner.StopCoroutine(_process);

		_process = _coroutineRunner.StartCoroutine(Process());
	}

	public void StopProcess()
	{
		if (_process != null)
			_coroutineRunner.StopCoroutine(_process);

		_process = null;
	}

	private IEnumerator Process()
	{
		_time = 0;

		while (_time < _timeLimit)
		{
			_time += Time.deltaTime;

			if (_time > _timeLimit)
				_time = _timeLimit;

			yield return null;
		}

		//_process = null;
	}
}
