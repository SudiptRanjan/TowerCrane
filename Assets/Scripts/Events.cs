public static class Events 
{
	//public delegate void OnMovement(float xDirection,float yDirection);
	//public static OnMovement onPlayerMoves;

	public delegate void OnMovement( float yDirection);
	public static OnMovement onPlayerMoves;

    public delegate void OnRotate(float yDirectionRotate);
    public static OnRotate onPlayerRotate;

    public delegate void ObjectInteract();
	public static ObjectInteract onObjectInteract;

	//public delegate void ObjectIsAttached();
	//public static ObjectIsAttached objectIsAttached;

	//public delegate void ObjectIsNotAttached();
	//public static ObjectIsNotAttached objectIsNotAttached;

}
