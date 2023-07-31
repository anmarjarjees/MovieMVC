using System.ComponentModel.DataAnnotations; // this is needed for the  [attributes] annotation
/*
Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-7.0&tabs=visual-studio
*/
namespace MovieMVC.Models
{
    /*
    This class "Movie" contains all the properties to be displayed as the field titles
    Because they will be used as field titles (names) for our table in the database
    */ 
    public class Movie
    {
        //  Id field, which is required by the database to be the primary key.
        /*
        Remember: By Convention EF will use either Id or AnyNameId to be the primary key automatically
        without the need of adding [Key]
        */
        public int Id { get; set; }

        /*
        NOTE:
        The question mark after string indicates that the property is nullable.
        to avoid the normal warning about "Non-nullable" property
        */
        public string? Title { get; set; }

        /*
        "DataType" Attribute:	
        > Represents an enumeration of the data types associated with data fields and parameters.
        > On ReleaseDate specifies the type of the data (Date). 
        With this attribute: [DataType(DataType.Date)]

        In such case:
        > The user is NOT required to enter time information in the date field.
        > Only the date is displayed, not time information.      

        Link: https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatype?view=net-7.0

        "Display" Attribute:
        Because the property is named "ReleaseDate", it will be also displayed as one single word!
        We can use the attribute "Display" with the "name" field to assign any readable name for display only        
        */

        // The "DataType" attribute specifies the type of the data (Date),
        // so the time information stored in the field isn't displayed.
        [DataType(DataType.Date)]
        // The "Display" attribute specifies what to display for the name of a field:
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        public string? Genre { get; set; }

        /*
        "Column" Attribute:
        Using the "Column" attribute with "TypeName" field to force the numeric format for this field

        The [Column(TypeName = "decimal(18, 2)")] data annotation is required 
        so Entity Framework Core can correctly map Price to currency in the database
        */
        public decimal Price { get; set; }
    } // class
} // namespace
