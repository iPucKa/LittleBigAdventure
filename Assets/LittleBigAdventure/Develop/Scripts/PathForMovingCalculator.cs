using UnityEngine;

public class PathForMovingCalculator
{
	private const float Frequency = 10f;
	private const float Amplitude = 0.3f;

	private PointToPointMover _pointMover;
	private float _startYPosition;

	private Vector3 _newPosition;

	public PathForMovingCalculator(PointToPointMover mover)
	{
		_pointMover = mover;
		_startYPosition = mover.transform.position.y;
	}
	
	public void FindDirection(Vector3 oldPosition, float xPosition, float progress)
	{
		float yPosition = _startYPosition + Amplitude * Mathf.Sin(progress * Frequency);

		_newPosition = new Vector3(xPosition, yPosition, 0);

		Vector3 direction = (_newPosition - oldPosition).normalized;
		
		_pointMover.SetDirection(direction);
	}
}
