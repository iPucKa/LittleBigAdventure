using UnityEngine;

public class PlayerCheckerEnemy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Character character))
			character.Dead();
	}
}
