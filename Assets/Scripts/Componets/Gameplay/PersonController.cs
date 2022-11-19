

using UnityEngine;
using DG.Tweening;

public class PersonController : MonoBehaviour
{

    public float Speed = 0.1f;
    public float SpeedRotate = 0.1f;
    public bool InvertY = false;
    public bool IsLookSomething = false;


    private CharacterController characterController;




    void Start()
    {
        characterController = GetComponent<CharacterController>();
        var player_place = GameObject.FindGameObjectWithTag("Player");
        if(player_place)
        {
            this.transform.position = player_place.transform.position;
            this.transform.rotation = player_place.transform.rotation;
        }
    }

    private void FixedUpdate()
    {
       /* ray.origin = transform.position;
        ray.direction = transform.forward;
        if (Physics.Raycast(ray, out hit, 10))
        {
            if(hit.collider)
            {
                Debug.Log("C" + hit.collider.name);
            }

        }*/
    }

    void  Update()
    {
        if (IsLookSomething == false)
        {
            Movment();
            LookAround();
        }

    }

    private void Movment()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * Speed, Space.Self);
            characterController.Move(transform.forward * Speed);

        }
        if (Input.GetKey(KeyCode.S))
        {
            // transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * Speed, Space.Self);
            characterController.Move(-transform.forward * Speed);

        }
        if (Input.GetKey(KeyCode.A))
        {

            // transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * Speed, Space.Self);
            characterController.Move(-transform.right * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * Speed, Space.Self);
            characterController.Move(transform.right * Speed);

        }
        
       transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
    private void LookAround()
    {

        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Mouse Y");

      //// var current_rot = transform.eulerAngles;

        if (InvertY == false)
        {
            transform.eulerAngles += new Vector3((vertical), (horizontal), 0) * SpeedRotate;
        }
        else
        {
            transform.eulerAngles += new Vector3((-vertical), (horizontal), 0) * SpeedRotate;
        }


    }
    private void LookAtTarget(Vector3 gotoPlace, Vector3 looktoTarget)
    {

    }
}
