using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputSystemActions;
    
    public Vector3 MoveDirection {get; private set;}

    private void Update()
    {
        MoveDirection = SetMoveDirection();
    }

    private void Awake() { _inputSystemActions = new InputSystem_Actions(); }

    private void OnEnable() { _inputSystemActions.Enable(); }

    private void OnDisable() { _inputSystemActions.Disable(); }
    
    #region 8 DIR MOVEMENT

    private bool[] _DIR8 = { false, false, false, false, false, false, false, false };
    private readonly Vector3[] _moveDirection = {new Vector3(-1, 0, 0),  new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(0, 0, 1), new Vector3(.7f, 0, -.7f),  new Vector3(-.7f, 0, -.7f), new Vector3(-.7f, 0, .7f),  new Vector3(.7f, 0, .7f) };

    [SerializeField] private List<Vector3> directions;

    private readonly float _stickDeadzone = 0.625f;

    private Vector3 SetMoveDirection()
    {
        _DIR8[0] = _inputSystemActions.Player.Move.ReadValue<Vector3>().x < -_stickDeadzone || _inputSystemActions.Player.Left.IsPressed();
        _DIR8[1] = _inputSystemActions.Player.Move.ReadValue<Vector3>().x > _stickDeadzone || _inputSystemActions.Player.Right.IsPressed();
        _DIR8[2] = _inputSystemActions.Player.Move.ReadValue<Vector3>().y > _stickDeadzone || _inputSystemActions.Player.Forwards.IsPressed();
        _DIR8[3] = _inputSystemActions.Player.Move.ReadValue<Vector3>().y < -_stickDeadzone || _inputSystemActions.Player.Backwards.IsPressed();
        
        _DIR8[5] = _inputSystemActions.Player.Move.ReadValue<Vector3>().x < -_stickDeadzone 
        && _inputSystemActions.Player.Move.ReadValue<Vector3>().y > _stickDeadzone 
        || _inputSystemActions.Player.Left.IsPressed() 
        && _inputSystemActions.Player.Forwards.IsPressed();
        
        _DIR8[4] = _inputSystemActions.Player.Move.ReadValue<Vector3>().x > _stickDeadzone 
        && _inputSystemActions.Player.Move.ReadValue<Vector3>().y > _stickDeadzone 
        || _inputSystemActions.Player.Right.IsPressed()
         && _inputSystemActions.Player.Forwards.IsPressed();
        
         _DIR8[6] = _inputSystemActions.Player.Move.ReadValue<Vector3>().x < -_stickDeadzone 
        && _inputSystemActions.Player.Move.ReadValue<Vector3>().y < -_stickDeadzone 
        || _inputSystemActions.Player.Left.IsPressed() 
        && _inputSystemActions.Player.Backwards.IsPressed();
        
        _DIR8[7] = _inputSystemActions.Player.Move.ReadValue<Vector3>().x > _stickDeadzone 
        && _inputSystemActions.Player.Move.ReadValue<Vector3>().y < -_stickDeadzone 
        || _inputSystemActions.Player.Right.IsPressed()
         && _inputSystemActions.Player.Backwards.IsPressed();
          
        
        for (int i = 0; i < _DIR8.Length; i++)
        {
            if (_DIR8[i] && !directions.Contains(_moveDirection[i]))
            {
                directions.Add(_moveDirection[i]); 
            }
            else if (_DIR8[i]  == false)
            {
                directions.Remove(_moveDirection[i]);
            }
        }
        return directions.Count > 0 ? directions.Last() : Vector3.zero;
    }
    #endregion
}
