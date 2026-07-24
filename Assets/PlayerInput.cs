using System.Runtime.CompilerServices;
using UnityEngine;

using UnityEngine.InputSystem;
//El scenemanager es por lo de reset y salir del juego por eso todavia no lo borre
using UnityEngine.SceneManagement;



// Esto es por que me tengo que asegurar de que se llame primero este awake asi ya se guarda el input en el game manager
[DefaultExecutionOrder(-1)]
public class PlayerInput : MonoBehaviour
{
    
    private InputAction _useAction, _useItemAction, _movementAction, _lookAction, _attackAction, _interactAction, _blockAction, _jumpAtion, _rightClickAction;
    private InputAction _parryAction;
    
    Vector2 _dir = Vector2.zero;
    private bool CanInputActions = true;
    private Vector3 currentWorldPosition;


    public delegate void AttacksDelegate(Vector3 Objective);

    public delegate void JumpPress();
    public delegate void UseAction();
    public delegate void Parry();

    public AttacksDelegate OnAttackPressed = delegate { };
    public AttacksDelegate OnAttackReleased = delegate { };
    public JumpPress OnJumpPress = delegate { };

    public UseAction OnUsePressed = delegate { };
    public UseAction OnUseItemPressed = delegate { };


    public Parry OnParryPressed = delegate { };

    [SerializeField] private MovementComponent _movement;

    // Este todavia no se usa pero ya queda aca
    // public UseAction OnUseReleased = delegate { };

    private void Awake()
    {

        _movementAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _attackAction = InputSystem.actions.FindAction("Attack");
        _interactAction = InputSystem.actions.FindAction("Interact");

        _useAction = InputSystem.actions.FindAction("Use");
        _jumpAtion = InputSystem.actions.FindAction("Jump");
        _rightClickAction = InputSystem.actions.FindAction("SecondClick");

       



    }


    private void Update()
    {
            



        currentWorldPosition = GetMouseWorldPosition();
        GeneralHandler.MouseWorldPosition = currentWorldPosition;
        Debug.DrawLine(Camera.main.transform.position, currentWorldPosition, Color.green);
    

        _dir = _movementAction.ReadValue<Vector2>();



        if (CanInputActions)
        {
            if (_attackAction.WasPressedThisFrame())
            {

                OnAttackPressed?.Invoke(currentWorldPosition);
            }
            if (_attackAction.WasReleasedThisFrame())
            {
                OnAttackReleased?.Invoke(currentWorldPosition);
            }

            if (_useAction.WasPressedThisFrame())
            {
                OnUsePressed?.Invoke();
            }
            if (_rightClickAction.WasPressedThisFrame())
            {

            }

        }
        if (_jumpAtion.WasPressedThisFrame())
        {
            OnJumpPress?.Invoke();
        }

        /*
         * si metemos inventario usamos esto para la hotbar
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {

            for (int i = 1; i <= 4; i++)
            {

                Key tecla = (Key)System.Enum.Parse(typeof(Key), "Digit" + i);

                if (Keyboard.current[tecla].wasPressedThisFrame)
                {
                    _inventory.ChangeSelection(i - 1);
                    break;
                }
            }
        }
        */


    }

    private void FixedUpdate()
    {

       _movement.Move(_dir);
    }

    public void DeactivateActions()
    {
        CanInputActions = false;
    }

    public void ActivateActions()
    {
        CanInputActions = true;
    }

    public void DeactivateMovement()
    {

    }

    public void ActivateMovement()
    {

    }




    #region Mouse


    public Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        Plane worldPlane = new Plane(Vector3.up, new Vector3(0, 0, 0));

        if (worldPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(currentWorldPosition, 0.2f);
    }

    #endregion




}



