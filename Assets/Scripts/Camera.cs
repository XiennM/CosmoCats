using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // ��������� ������, �� ������� ����� ��������� ������
    public Transform target;

    void Update()
    {
        UpdateCameraPosition();
    }

    // �������� ������� ������ �� ������
    void UpdateCameraPosition()
    {
        transform.position = new Vector3(0, target.position.y + 2, -1);
    }
}
