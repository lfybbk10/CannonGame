using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RandomMove : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _maxDistance;
    
    private CharacterController _characterController;

    private float _currSpeed;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _currSpeed = _startSpeed;
    }

    private void OnEnable()
    {
        StartCoroutine(MoveCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            float velocityX = Random.Range(-1f, 1f);
            float velocityZ = Random.Range(-1f, 1f);

            
            Vector3 dist = new Vector3(velocityX, 0, velocityZ) * _maxDistance;

            Vector3 startPoint = transform.position;
            Vector3 destination = RandomFieldPoint.instance.Get();
            //Vector3 destination = transform.position + dist;

            float timer = 0;
            float movementTime = _maxDistance / _currSpeed;

            while (timer < movementTime)
            {
                transform.position = Vector3.Lerp(startPoint, destination, timer / movementTime);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
