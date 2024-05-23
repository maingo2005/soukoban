using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Move : MonoBehaviour
{
    /// <summary>移動までにかかる時間</summary>
    public float duration = 0.2f;
    float elapsedlTime;
    Vector3 destination;
    Vector3 origin;

    void Start()
    {
        destination = transform.position;
        origin = destination;
    }

    void Update()
    {
        if (transform.position == destination)
        {
            return;
        }

        elapsedlTime += Time.deltaTime;
        float timeRatio = elapsedlTime / duration;

        if (timeRatio > 1)
        {
            timeRatio = 1;
        }

        float easing = timeRatio;

        Vector3 currentPosition = Vector3.Lerp(origin, destination, easing);
        transform.position = currentPosition;
    }

    /// <summary>オブジェクトを滑らかに移動させる</summary>
    /// <param name="destination">目的地の座標</summary>
    public void MoveTo(Vector3 destination)
    {
        elapsedlTime = 0;
        origin = this.destination;
        //移動中だった場合はキャンセルして目的地にワープする
        transform.position = origin;
        this.destination = destination;

        //transform.position = destination;
    }
}
