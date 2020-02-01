using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Speed of Character")]
    public float m_Speed = 5f;
    public float m_MaxDistanceToObject = 2f;

    public float MaxDistanceSquare => m_MaxDistanceToObject * m_MaxDistanceToObject;

#pragma warning disable CS0108
    private Camera camera;
#pragma warning restore CS0108

    private bool isWalking = false;
    RaycastHit toMove;

    [HideInInspector]
    public Inventory inventory = new Inventory();

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Here are [Input.GetKeyDown] Functions", this);

        // get main Camera
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Player is not walking
        if (!isWalking) AcceptClick();

        // player is currently walking to a destination
        else
        {
            bool withDistance = toMove.collider.gameObject.tag == "Interactable" ? true : false;
            WalkTo(toMove, withDistance);
        }


        if (Input.GetKeyDown(KeyCode.I))
            inventory.InventoryItems();
        else if (Input.GetKeyDown(KeyCode.H))
            Crafting.CraftHammer(inventory);
        else if (Input.GetKeyDown(KeyCode.T))
            Crafting.CraftTongs(inventory);
        else if (Input.GetKeyDown(KeyCode.R))
            Crafting.CraftRocket(inventory);
    }

    private void AcceptClick()
    {
        // check if left click
        if (Input.GetMouseButtonDown(0))
        {
            // do screen to ray
            Ray r = camera.ScreenPointToRay(Input.mousePosition);

            // check if ray hit something
            if (Physics.Raycast(r, out RaycastHit hit))
            {
                string tag = hit.collider.gameObject.tag;

                // check if hit object was wall
                if (tag == "Wall")
                {
                    // Do something when wall was clicked
                }

                else if (tag == "Player")
                {
                    // do something when Player was clicked
                }

                else if (tag == "Ground")
                {
                    // do something when ground was clicked
                    // walk to destination
                    isWalking = true;
                    toMove = hit;

                    // Rotate Player
                    Rotate(hit.point);
                }

                else if (tag == "Interactable")
                {
                    // do something when something interactable was clicked

                    // check if object is already in Range
                    if (InRange(hit.collider.transform.position))
                    {
                        // get interactable and check if component is not null
                        if (!GetInteractable(hit.collider.gameObject, out Interactable interact))
                        {
                            Debug.LogWarning("Object with Interactable tag has no Interactable-Component!", hit.collider.gameObject);
                            return;
                        }
                        else
                        {
                            interact.Interact();
                        }

                    }

                    else
                    {
                        // get interactable and check if component is not null
                        if (!GetInteractable(hit.collider.gameObject, out Interactable interact))
                        {
                            Debug.LogWarning("Object with Interactable tag has no Interactable-Component!", hit.collider.gameObject);
                            return;
                        }
                        else
                        {
                            interact.Click();
                        }


                        isWalking = true;
                        toMove = hit;

                        // Rotate Player
                        Rotate(hit.point);
                    }
                }
            }

        }

    }

    /// <summary>
    /// Get Interactable class from object
    /// </summary>
    /// <param name="_other">other object</param>
    /// <param name="_interactable">interactable class</param>
    /// <returns>true if component could be found, else false</returns>
    private bool GetInteractable(GameObject _other, out Interactable _interactable)
    {
        _interactable = _other.GetComponent<Interactable>();

        if (_interactable == null) return false;
        else return true;
    }

    private void WalkTo(RaycastHit _hitObject, bool _withDistance = false)
    {
        // move object without distance check
        if (!_withDistance)
        {

            // check if player has same x and z position as the point
            if (this.transform.position.x == _hitObject.point.x
                && this.transform.position.z == _hitObject.point.z)
            {
                // end movement
                toMove = new RaycastHit();
                isWalking = false;
            }

            else
            {
                // move
                Move(_hitObject.point);
            }
        }

        // move object with distance check
        else
        {

            // get square distance of player position and gameobject position [NOT POINT!]
            float distanceSqr = Vector3.SqrMagnitude(this.transform.position - _hitObject.collider.gameObject.transform.position);

            // check distance
            if (InRange(distanceSqr, MaxDistanceSquare))
            {
                // end movement
                toMove = new RaycastHit();
                isWalking = false;
            }
            else
            {
                // move
                Move(_hitObject.collider.gameObject.transform.position);
            }
        }

    }

    private bool InRange(float _distanceSquare)
        => (_distanceSquare < MaxDistanceSquare);
    private bool InRange(float _distance, float _maxDistanceSquare)
        => (_distance < _maxDistanceSquare);
    private bool InRange(Vector3 _other)
    => InRange(Vector3.SqrMagnitude(this.transform.position - _other), MaxDistanceSquare);
    private bool InRange(Vector3 _other, float _maxDistance)
        => InRange(Vector3.SqrMagnitude(this.transform.position - _other), _maxDistance);

    private void Move(Vector3 _destination)
    {
        // movement
        transform.position = Vector3.MoveTowards(
            this.transform.position,
            new Vector3(
                _destination.x,
                this.transform.position.y,
                _destination.z
                ),
            m_Speed * Time.deltaTime
            );
    }

    private void Rotate(Vector3 _destination)
    {
        Vector3 tolook = new Vector3(
            _destination.x,
            transform.position.y,
            _destination.z
            );

        transform.LookAt(tolook);

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y - 90,
            transform.rotation.eulerAngles.z
            );

        Debug.Log(transform.rotation.eulerAngles);
    }
}
