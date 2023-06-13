using System.ComponentModel.DataAnnotations;
/*
Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-7.0&tabs=visual-studio
*/
namespace MovieMVC.Models
{
    public class Movie
    {
        //  Id field, which is required by the database for the primary key.
        public int Id { get; set; }

        /*
        NOTE:
        The question mark after string indicates that the property is nullable.
        to avoid the normal warning about "Non-nullable" property
        */
        public string? Title { get; set; }

        /*
        DataType Attribute:	
        > Represents an enumeration of the data types associated with data fields and parameters.
        > On ReleaseDate specifies the type of the data (Date). 
        With this attribute: [DataType(DataType.Date)]

        In such case:
        > The user isn't required to enter time information in the date field.
        > Only the date is displayed, not time information.

        Link: https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatype?view=net-7.0
         */
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        public string? Genre { get; set; }
        
        public decimal Price { get; set; }
    } // class
} // namespace
