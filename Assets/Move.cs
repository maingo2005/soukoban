using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Move : MonoBehaviour
{
    /// <summary>�ړ��܂łɂ����鎞��</summary>
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

    /// <summary>�I�u�W�F�N�g�����炩�Ɉړ�������</summary>
    /// <param name="destination">�ړI�n�̍��W</summary>
    public void MoveTo(Vector3 destination)
    {
        elapsedlTime = 0;
        origin = this.destination;
        //�ړ����������ꍇ�̓L�����Z�����ĖړI�n�Ƀ��[�v����
        transform.position = origin;
        this.destination = destination;

        //transform.position = destination;
    }
}
