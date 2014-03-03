using UnityEngine;
using System.Collections;

public enum State{raised,
	raising,
	lowered,
	lowering,
	waiting}

public interface PlatformState {

	// Use this for initialization
	State CheckState();

	bool ChangeState();

}
