using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class NewBehaviourScript : MonoBehaviour {
	private KinectSensor _Sensor;
	private BodyFrameReader _Reader;
	private Body[] _Data = null;
	BodyFrame frame;
	Vector3 lastPlayerPos;
	Vector3 curPlayerPos;
	static Vector3 zeroPos = new Vector3((float)0, (float)0, (float)0);
	
	void UpdateData() {
		if (frame != null) {
			frame.Dispose ();
		}
		frame = null;
		frame = _Reader.AcquireLatestFrame ();
		
		if (frame != null) {
			if (_Data == null) {
				_Data = new Body[_Sensor.BodyFrameSource.BodyCount];
			}
			
			frame.GetAndRefreshBodyData (_Data);
			
			frame.Dispose ();
			frame = null;
		}
	}
	
	int PlayerIndex (){
		this.UpdateData ();
		int idx = -1;
		if (_Data != null) {
			for (int i = 0; i < _Sensor.BodyFrameSource.BodyCount; i++) {
				if (_Data [i].IsTracked) {
					idx = i;
				}
			}
		}
		return idx;
	}
	
	void UpdatePlayerLastPos(){
		
	}
	
	// Use this for initialization
	void Start () {
		_Sensor = KinectSensor.GetDefault();
		
		if (_Sensor != null)
		{
			_Reader = _Sensor.BodyFrameSource.OpenReader();
			
			if (!_Sensor.IsOpen)
			{
				_Sensor.Open();
			}
		} 
		int idx = this.PlayerIndex ();
		if (idx > -1) {
			lastPlayerPos = new Vector3 (
				(float)(_Data [idx].Joints [JointType.SpineMid].Position.X),
				//(float)(_Data [idx].Joints [JointType.SpineMid].Position.Y),
				(float) 0,
				(float)(_Data [idx].Joints [JointType.SpineMid].Position.Z)
				);
		} else {
			lastPlayerPos = zeroPos;
		}	}
	
	// Update is called once per frame
	void Update()
	{
		if (_Reader != null)
		{
			int idx = this.PlayerIndex();
			if (idx>-1) {
				curPlayerPos = new Vector3(
					(float)((_Data [idx].Joints [JointType.SpineMid].Position.X )* -1),
					(float)0,
					(float)(_Data [idx].Joints [JointType.SpineMid].Position.Z )
					);
				if (lastPlayerPos != zeroPos) {
					var delta = curPlayerPos - lastPlayerPos;
					lastPlayerPos = curPlayerPos;
					var objectPos = this.gameObject.transform.position;
					this.gameObject.transform.position = objectPos + (delta * 5);
				} else{
					lastPlayerPos = curPlayerPos;
				}
			}
		}
	}
	
	
	void OnApplicationQuit()
	{
		if (_Reader != null)
		{
			_Reader.Dispose();
			_Reader = null;
		}
		
		if (_Sensor != null)
		{
			if (_Sensor.IsOpen)
			{
				_Sensor.Close();
			}
			_Sensor = null;
		}
	}
}
