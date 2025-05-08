using UnityEngine;

public class PlatformView : MonoBehaviour
{
    private readonly int OnOffKey = Animator.StringToHash("IsOff");

    [SerializeField] private Platform _platform;
    [SerializeField] private Animator _animator;

	private void Update()
	{
		_animator.SetBool(OnOffKey, _platform.IsActivated);
	}
}
