using UnityEngine;

public class SwitchHandler : MonoBehaviour
{
	private bool _isOnSwitched;

	public bool IsOn => _isOnSwitched;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Character character))		
			_isOnSwitched = true;		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Character character))
			_isOnSwitched = false;
	}
}
