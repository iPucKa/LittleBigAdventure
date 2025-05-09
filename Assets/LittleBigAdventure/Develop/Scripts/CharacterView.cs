using UnityEngine;

public class CharacterView : MonoBehaviour
{
	private readonly int VelocityXKey = Animator.StringToHash("VelocityX");
	private readonly int VelocityYKey = Animator.StringToHash("VelocityY");
	private readonly int IsGroundedKey = Animator.StringToHash("IsGrounded");
	private readonly int DeadKey = Animator.StringToHash("Dead");

	[SerializeField] private Character _character;
	[SerializeField] private Animator _animator;
	[SerializeField] private AudioSource _explosionSound;

	private bool _isDeathAnimated;

	private void Update()
	{
		_animator.SetFloat(VelocityXKey, Mathf.Abs(_character.Velocity.x));
		_animator.SetFloat(VelocityYKey, _character.Velocity.y);
		_animator.SetBool(IsGroundedKey, _character.IsGrounded());

		if (_character.IsDead && _isDeathAnimated == false)
		{ 
			_animator.SetTrigger(DeadKey); 
			_isDeathAnimated = true;
			_explosionSound.Play();
		}
	}
}
