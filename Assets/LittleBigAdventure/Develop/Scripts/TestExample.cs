using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestExample : MonoBehaviour
{
	[SerializeField] private Character _character;
	
	private const float TimeToReloadScene = 1f;

	private PlayerDirectionalController _characterController;

	private Coroutine _restartCroutine;
	private float _time;

	private void Awake()
	{
		_characterController = new PlayerDirectionalController(_character);
		_characterController.Enable();
		
		_restartCroutine = null;
	}

	private void Update()
	{
		_characterController.Update(Time.deltaTime);

		if (_character.IsDead)
		{
			_characterController.Disable();

			if (_restartCroutine == null)
				_restartCroutine = StartCoroutine(RestartProcess());
		}		
	}

	private IEnumerator RestartProcess()
	{
		_time = 0;

		while (_time < TimeToReloadScene)
		{
			_time += Time.deltaTime;

			if (_time >= TimeToReloadScene)
				_time = TimeToReloadScene;

			yield return null;
		}

		RestartGame();
	}

	private void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
