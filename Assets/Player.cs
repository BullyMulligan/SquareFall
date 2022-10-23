
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _right;
    [SerializeField] private Transform _left;
    [SerializeField] private float _speed = 1;

    private float _duration;//время, за которое объект проходит от точки до точки
    private float _currentTime;
    private bool _isMovingRight;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//если мы жмем пробел
        {
            _isMovingRight = !_isMovingRight;//мы идем влево
        }
        _currentTime += _isMovingRight ? Time.deltaTime:-Time.deltaTime;//тут уже делая время негативным значением, мы направляем шарик в другую сторону
        _duration = Vector3.Distance(_right.position,_left.position ) / _speed;
        var progress = Mathf.PingPong(_currentTime, _duration)/_duration;
        transform.position = Vector3.Lerp(_left.position, _right.position, progress);

    }
}
