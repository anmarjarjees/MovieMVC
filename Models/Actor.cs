namespace MovieMVC.Models
{
    public class Actor
    {
        /*
        Any table in a database needs an ID column
         */
        public int Id { get; set; }

        /*
         We used VS Fix to generate these two methods:
         */
        internal string GetName()
        {
            return "James Dean"; // Just hard coding for demo
        }

        internal int GetNumTimes()
        {
            return 5; // Just hard coding for demo
        }
    }
}
