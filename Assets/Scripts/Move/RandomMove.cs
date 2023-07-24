using System.Collections;
using UnityEngine;


public class RandomMove : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private float _currSpeed;

    private float _speedStep = 1.3f;

    private void Awake()
    {
        _currSpeed = _startSpeed;
    }

    private void OnEnable()
    {
        GameProgressEvents.OnDifficultyIncreased.Add(IncreaseSpeed);
        StartCoroutine(MoveCoroutine());
    }

    private void OnDisable()
    {
        GameProgressEvents.OnDifficultyIncreased.Remove(IncreaseSpeed);
        StopAllCoroutines();
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            
            Vector3 startPoint = transform.position;
            Vector3 destination = RandomFieldPoint.instance.Get();

            float distance = Vector3.Distance(startPoint, destination);

            float timer = 0;
            float movementTime = distance / _currSpeed;
            
            transform.LookAt(destination);

            while (timer < movementTime)
            {
                transform.position = Vector3.Lerp(startPoint, destination, timer / movementTime);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void IncreaseSpeed()
    {
        _currSpeed *= _speedStep;
    }
}
