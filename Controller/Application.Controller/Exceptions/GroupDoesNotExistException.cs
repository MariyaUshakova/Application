namespace Application.Controller.Exceptions
{

	[System.Serializable]
	public class GroupDoesNotExistException : System.Exception
	{
		public GroupDoesNotExistException() { }
		public GroupDoesNotExistException(string message) : base(message) { }
		public GroupDoesNotExistException(string message, System.Exception inner) : base(message, inner) { }
		protected GroupDoesNotExistException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
