using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Добавляем объект, за которым будет двигаться камера
    public Transform target;

    void Update()
    {
        UpdateCameraPosition();
    }

    // Изменяем позицию камеры на экране
    void UpdateCameraPosition()
    {
        transform.position = new Vector3(0, target.position.y + 2, -1);
    }
}
