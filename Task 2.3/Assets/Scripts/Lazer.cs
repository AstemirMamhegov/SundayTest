using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float timeFly;
    public float lifeTime;

    public void SetPoint(Vector3 point)
    {
        StartCoroutine(LazerMove(point));
    }

    IEnumerator LazerMove(Vector3 shootPoint)
    {
        Vector3 _startPoint = transform.position;
        float t = 0, a;
        while (t < timeFly)
        {
            a = Mathf.Clamp01(t / timeFly);
            transform.position = Vector3.Lerp(_startPoint, shootPoint, a);
            yield return null;
            t += Time.deltaTime;
        }

        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
