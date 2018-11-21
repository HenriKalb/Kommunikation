using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindnessOnMotion : MonoBehaviour
{
    Vector3 _camMovement;
    Vector3 _camRotation;

    public bool _manual = false;
    public bool _updater;
    public int _fps = 90;
    private System.DateTime _nextUpdate;
    private System.DateTime _currentTime;
    public GameObject _imagePlane;

    private bool _updateImageNextFrame = false;

    public Vector3 _offset = Vector3.zero;

    List<Vector3> _positions;
    List<Quaternion> _rotations;

    Vector3 _currentPosition;
    Quaternion _currentRotation;

    public Ovrvision _ovr;

    public int _framesDelay = 3;
    public bool _stutterPosition = true;
    // Use this for initialization
    void Start()
    {
        _positions = new List<Vector3>();
        _rotations = new List<Quaternion>();
    }

    public void Restart(int framesDelay, int fps, bool stutterPosition)
    {
        if (!_manual)
        {
            _framesDelay = framesDelay;
            _fps = fps;
            _stutterPosition = stutterPosition;

            _positions = new List<Vector3>();
            _rotations = new List<Quaternion>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateImageNextFrame)
        {
            _updateImageNextFrame = false;
            _ovr.UpdateImage();

        }
        _currentTime = System.DateTime.Now;

        _positions.Add(transform.position + transform.TransformDirection(new Vector3(_offset.x, _offset.y, _offset.z)));
        _rotations.Add(transform.rotation);

        if(_fps == 90)
        {
            _stutterPosition = false;
        }
        if (_positions.Count > _framesDelay)
        {
            if (!_stutterPosition)
            {
                _currentPosition = _positions[0];
                _currentRotation = _rotations[0];
            }

            if (_currentTime >= _nextUpdate || _fps == 90)
            {
                // print(_currentTime.ToString("mmssffffff") + " / " + _nextUpdate.ToString("mmssffffff"));
                if (_stutterPosition)
                {
                    _currentPosition = _positions[0];
                    _currentRotation = _rotations[0];
                }

                _nextUpdate = _currentTime;
                _nextUpdate = _nextUpdate.AddMilliseconds((1 / (float)_fps) * 1000);
                if (_updater)
                {
                    _ovr.UpdateImage();
                   // _updateImageNextFrame = true;
                }
            }

            _imagePlane.transform.position = _currentPosition;
            _imagePlane.transform.rotation = _currentRotation;


           // _imagePlane.transform.position = Vector3.Slerp(_imagePlane.transform.position, _currentPosition, 0.01f);
           // _imagePlane.transform.rotation = Quaternion.Slerp(_imagePlane.transform.rotation, _currentRotation, 0.01f);


            _positions.RemoveAt(0);
            _rotations.RemoveAt(0);

        }
    }
}
