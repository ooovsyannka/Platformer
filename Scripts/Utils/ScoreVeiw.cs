using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreVeiw : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _durationChange;

    private int _currentCount = 0;
    private TextMeshProUGUI _scoreText;
    private Coroutine _scoreCoroutine;

    private void OnEnable()
    {
        _wallet.ChangeValue += IncreaseScore;
    }

    private void OnDisable()
    {
        _wallet.ChangeValue -= IncreaseScore;
    }

    private void Start()
    {
        _scoreText = transform.GetComponent<TextMeshProUGUI>();
        _scoreText.text = _currentCount.ToString("");
    }

    private void IncreaseScore(int count)
    {
        _currentCount = count;

        if (_scoreCoroutine != null)
            StopCoroutine(_scoreCoroutine);

        _scoreCoroutine = StartCoroutine(ChangeTextSmoothly(_currentCount));
    }

    private IEnumerator ChangeTextSmoothly(float target)
    {
        float elapsedTime = 0f;
        float previousValue = float.Parse(_scoreText.text);

        while (elapsedTime < _durationChange)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _durationChange;
            float intermediateValue = Mathf.Lerp(previousValue, target, normalizedPosition);
            _scoreText.text = ((int)intermediateValue).ToString("");

            yield return null;
        }
    }
}
