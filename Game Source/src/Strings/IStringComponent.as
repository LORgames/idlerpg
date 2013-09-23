package Strings 
{
	
	/**
	 * ...
	 * @author Paul
	 */
	public interface IStringComponent {
		function Build():String;
		function RequiresRebuild():Boolean;
	}
	
}