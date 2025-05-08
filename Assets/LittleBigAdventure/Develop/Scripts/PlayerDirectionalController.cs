using UnityEngine;

public class PlayerDirectionalController
{
	private const string HorizontalAxisName = "Horizontal";

	private Character _character;

	private float _xDirection;
	private bool _jumpPressed;

	private bool _isEnabled;

	public PlayerDirectionalController(Character character)
	{
		_character = character;
	}

	public void Enable() => _isEnabled = true;

	public void Disable()
	{
		SetCharacterBehaviour(0, false);
		_isEnabled = false;
	}

	public void Update(float deltatime)
    {
		if (_isEnabled == false)
			return;

		_xDirection = Input.GetAxisRaw(HorizontalAxisName);

		_jumpPressed = Input.GetKeyDown(KeyCode.Space);

		SetCharacterBehaviour(_xDirection, _jumpPressed);
	}

	private void SetCharacterBehaviour(float xDirection, bool IsJumped)
	{
		_character.SetHorizontalVelocity(xDirection);
		_character.SetJumpCondition(IsJumped);
	}
}
