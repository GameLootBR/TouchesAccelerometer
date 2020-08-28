using UnityEngine;

public class AccelerationManager : MonoBehaviour
{
    private Vector3 accel;
    private Vector3 prev;
    private const float kFilterFactor = 0.05f;
    private Matrix4x4 calibrationMatrix;
    private Vector3 accelerationSnapshot;
     
    public Vector2 acceleration;

    //--------------------------------------------------------------------------
    public void Start()
    {
        Calibrate();
    }

    //--------------------------------------------------------------------------
    public void Update()
    {
        accel = Input.acceleration.normalized * kFilterFactor + (1.0f - kFilterFactor) * prev;
        prev = accel;
        acceleration.x = accel.x;
        acceleration.y = calibrationMatrix.MultiplyVector(accel).y;
    }

    //--------------------------------------------------------------------------
    public void Calibrate()
    {
        accel = Input.acceleration.normalized;
        accelerationSnapshot = accel;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1.0f, 1.0f, 1.0f));
        calibrationMatrix = matrix.inverse;
    }
}
