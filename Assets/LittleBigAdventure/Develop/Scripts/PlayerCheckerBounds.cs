using UnityEngine;

public class PlayerCheckerBounds : MonoBehaviour
{
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Character character))
			character.Dead();
	}
}
