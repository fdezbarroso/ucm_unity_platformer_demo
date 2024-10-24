using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private const float _speed = 3.0f;
    private const float _time = 2.0f;
    private const float _timeStopped = 4.0f;

    private Coroutine _coroutine;

    void Start()
    {
        _coroutine = StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            yield return MovePart(Vector3.right);
            yield return MovePart(Vector3.down);
            yield return MovePart(Vector3.left);
            yield return MovePart(Vector3.up);
        }
    }

    private IEnumerator MovePart(Vector3 dir)
    {
        float time = 0.0f;
        do
        {
            time += Time.deltaTime;
            transform.position += dir * _speed * Time.deltaTime;
            yield return null;
        }
        while (time < _time);
        yield return new WaitForSeconds(_timeStopped);
    }
}
