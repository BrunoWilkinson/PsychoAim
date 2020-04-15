public interface IMouseLook
{
    void Move();

    void LockCursor();

    void UnlockCursor();

    void SetSensitivity(string sens);
}