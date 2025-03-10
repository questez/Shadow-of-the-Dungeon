using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float _speed;
    

    // Update is called once per frame
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
    }
}
