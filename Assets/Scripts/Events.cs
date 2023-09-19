public static class Events 
{
	

	public delegate void OnMovement( float yDirection);
	public static OnMovement onPlayerMoves;

    public delegate void OnRotate(float yDirectionRotate);
    public static OnRotate onPlayerRotate;

    public delegate void OnRopeLengthChange(float ropeValue);
	public static OnRopeLengthChange onRopeValueChange;

	public delegate void OnHookAttach(float attached);
	public static OnHookAttach onHookAttachToObject;

	public delegate void OnHookDetached(float detached);
	public static OnHookDetached onHookDetachedToObject;

}
