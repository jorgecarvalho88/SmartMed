namespace ValidationBase
{
    public class ValidationBase
    {
        public List<string> Errors { get; set; }
        public bool IsValid => !Errors.Any();

        public ValidationBase()
        {
            Errors = new List<string>();
        }
    }
}