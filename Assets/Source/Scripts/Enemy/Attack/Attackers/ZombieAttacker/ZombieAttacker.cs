using UnityEngine;

public class ZombieAttacker : EnemyAttacker
{
    [Min(0)]
    [SerializeField] private float _shotAngle;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private BloodBall _bloodBallTempalte;

    private readonly int _waypointsCount = 100;
    private readonly float _timeStep = 0.1f;

    protected override void Attack(ITarget target)
    {
        BloodBall bloodBall = Instantiate(_bloodBallTempalte, _shotPoint.position, Quaternion.identity);
        StartCoroutine(bloodBall.Move(GetPath(GetVector(GetSquareVelocity(target.CurrentPosition)))));
    }

    protected override bool ConditionBeforeAttack()
    {
        return ElapsedTime > SecondsBetweenAttack;
    }

    private Vector3 GetVector(float squareVelocity)
        => _shotPoint.forward * squareVelocity;

    private float GetSquareVelocity(Vector3 targetPosition)
    {
        Vector2 direction = GetDiraction(targetPosition);
        float angleInRadians = _shotAngle * Mathf.Deg2Rad;
        float velocity = Physics.gravity.y * Mathf.Pow(direction.x, 2) / (2 * (direction.y - Mathf.Tan(angleInRadians) * direction.x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float squareVelocity = Mathf.Sqrt(Mathf.Abs(velocity));
        return squareVelocity;
    }

    private Vector2 GetDiraction(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        Vector3 directionXZ = new Vector3(direction.x, 0f, direction.z);
        transform.rotation = Quaternion.LookRotation(directionXZ, Vector3.up);
        _shotPoint.localEulerAngles = new Vector3(-_shotAngle, 0f, 0f);
        return new Vector2(directionXZ.magnitude, direction.y);
    }

    private Vector3[] GetPath(Vector3 vector)
    {
        Vector3[] path = new Vector3[_waypointsCount];
        float elapsedTime;

        for (var i = 0; i < path.Length; i++)
        {
            elapsedTime = i * _timeStep;
            path[i] = GetWaypoint(vector, elapsedTime);
        }

        return path;
    }

    private Vector3 GetWaypoint(Vector3 vector, float elapsedTime)
    {
        return _shotPoint.position + vector * elapsedTime + Physics.gravity * Mathf.Pow(elapsedTime, 2) / 2f;
    }
}