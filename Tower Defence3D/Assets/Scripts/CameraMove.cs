using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 5f;
    public float horizontalSens = 2f;

    private float moveX;
    private float moveZ;
    private float rotation;
    private Vector3 movement; // вектор для хранения направления движения камеры

    void Start()
    {
        
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal"); //полчить значение по оси X (стрелки влево и вправо или A и D)
        moveZ = Input.GetAxis("Vertical"); //получить значение по оси Z (стрелки вверх и вниз или W и S)

        movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime; // создать вектор движения на основе входных данных
        
        movement = transform.TransformDirection(movement); // переместить камеру в направлении, в котором она смотрит
        movement.y = 0; // сохранить высоту камеры, чтобы она не поднималась или опускалась
        movement.z *= 1.5f;
        transform.position += movement;
        

        if (Input.GetMouseButton(1)) // если правая кнопка мыши нажата
        {
            rotation += Input.GetAxis("Mouse X") * horizontalSens; // получить значение вращения по оси X на основе движения мыши
            transform.rotation = Quaternion.Euler(45, rotation, 0); // применить вращение к камере
        }
    }
}
