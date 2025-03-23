using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;
    private float _oldmousePos, _eulerY;


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += _speed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= _speed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _speed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= _speed * transform.right * Time.deltaTime;
        }
        float deltaX = Input.mousePosition.x - _oldmousePos;
        _oldmousePos = Input.mousePosition.x;

        _eulerY += deltaX * _sensitivity;
        transform.eulerAngles = new Vector3(0, _eulerY, 0);
    }
}
