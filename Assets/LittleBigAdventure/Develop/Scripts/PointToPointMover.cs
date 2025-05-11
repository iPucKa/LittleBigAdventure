using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMover : MonoBehaviour
{
	[SerializeField] private List<Transform> _points;
	[SerializeField] private float _timeBetweenMoves;
	[SerializeField] private float _speed;

	private PathForMovingCalculator _pathHandle;
	private Mover _mover;

	private Queue<Vector3> _pointsPositions;
	private Vector3 _currentTarget;
	private Vector3 _oldPosition;

	private void Awake()
	{
		_pointsPositions = new Queue<Vector3>();

		foreach (Transform point in _points)
			_pointsPositions.Enqueue(point.position);

		_mover = new Mover(transform, _speed);
		_pathHandle = new PathForMovingCalculator(this);

		StartCoroutine(ProcessMove());
	}

	private IEnumerator ProcessMove()
	{
		while (true)
		{
			SwitchPoint();

			Vector3 startPosition = transform.position;
			Vector3 endPosition = _currentTarget;

			float timeForMovement = (endPosition - startPosition).magnitude / _speed;

			float progress = 0;
			float xNewPosition = 0;

			while (progress < timeForMovement)
			{
				_oldPosition = transform.position;

				xNewPosition = Vector3.Lerp(startPosition, endPosition, progress / timeForMovement).x;
				progress += Time.deltaTime;

				_pathHandle.FindDirection(_oldPosition, xNewPosition, progress);

				yield return null;
			}

			yield return new WaitForSeconds(_timeBetweenMoves);
		}
	}

	private void Update()
	{
		_mover.Update(Time.deltaTime);
	}

	private void SwitchPoint()
	{
		_currentTarget = _pointsPositions.Dequeue();
		_pointsPositions.Enqueue(_currentTarget);
	}

	public void SetDirection(Vector3 direction) => _mover.SetDirection(direction);
}
