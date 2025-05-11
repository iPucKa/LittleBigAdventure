using UnityEngine;

public class WindHandle
{
	private ObstacleChecker _groundChecker;
	private float _windSpeed;

	public WindHandle(ObstacleChecker groundChecker, float windSpeed)
	{
		_groundChecker = groundChecker;
		_windSpeed = windSpeed;
	}

	public void ApplyWind(ref float xVelocity)
	{
		if (_groundChecker.IsTouches() == false && Mathf.Abs(xVelocity) > 0)			
			xVelocity -= _windSpeed * Time.deltaTime;
	}
}
