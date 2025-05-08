using System.Collections;
using UnityEngine;

public class Timer
{
	private float _timeLimit;
	private float _fallTime;

	private MonoBehaviour _coroutineRunner;

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

		elapsedTime = _fallTime;
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
		_fallTime = 0;

		while (_fallTime < _timeLimit)
		{
			_fallTime += Time.deltaTime;

			if (_fallTime > _timeLimit)
				_fallTime = _timeLimit;

			yield return null;
		}

		//_process = null;
	}
}
