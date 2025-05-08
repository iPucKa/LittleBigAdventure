using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMover : MonoBehaviour
{
	[SerializeField] private List<Transform> _points;
	[SerializeField] private float _timeBetweenMoves;
	[SerializeField] private float _speed;

	private Queue<Vector3> _pointsPositions;
	private Vector3 _currentTarget;

	private float _startYPosition;

	private void Awake()
	{
		_pointsPositions = new Queue<Vector3>();

		foreach (Transform point in _points)
			_pointsPositions.Enqueue(point.position);

		_startYPosition = transform.position.y;

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
			float xPosition = 0;

			while (progress < timeForMovement)
			{
				xPosition = Vector3.Lerp(startPosition, endPosition, progress / timeForMovement).x;
				progress += Time.deltaTime;

				transform.position = SetPosition(xPosition, progress);

				yield return null;
			}

			yield return new WaitForSeconds(_timeBetweenMoves);
		}
	}

	private void SwitchPoint()
	{
		_currentTarget = _pointsPositions.Dequeue();
		_pointsPositions.Enqueue(_currentTarget);
	}

	private Vector3 SetPosition(float xPosition, float progress)
	{
		float yPosition = _startYPosition + 0.3f * Mathf.Sin(progress * 10f);

		return new Vector3(xPosition, yPosition, transform.position.z);
	}
}
