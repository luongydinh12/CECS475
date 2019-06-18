// JoiningTableData.cs
// Using LINQ to perform a join and aggregate data across tables.
using System;
using System.Linq;
using System.Windows.Forms;

namespace JoinQueries
{
    public partial class JoiningTableData : Form
    {
        public JoiningTableData()
        {
            InitializeComponent();
        } // end constructor

        private void JoiningTableData_Load(object sender, EventArgs e)
        {
            // Entity Framework DBContext
            BooksEntities dbcontext =
               new BooksEntities();
            //A . Get a list of all the titles and the authors who wrote them. Sort the result by title.
            var titleAuthor = from author in dbcontext.Authors
                              from book in author.Titles
                              orderby book.Title1
                              select new { book.Title1, author.FirstName, author.LastName };

            outputTextBox.AppendText("Titles and Authors :");

            // display titles and authors
            foreach (var element in titleAuthor)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,0} {1,0} {2,0}",
                       element.Title1, element.FirstName, element.LastName));
            } // end foreach


            //B . Get a list of all the titles and the authors who wrote them. Sort the result by title. For each title sort the authors alphabetically by last name, then first name.
            var allTitleAuthors = from author in dbcontext.Authors
                                  from book in author.Titles
                                  orderby book.Title1, author.LastName, author.FirstName
                                  select new { book.Title1, author.LastName, author.FirstName };
            outputTextBox.AppendText("\r\n\r\nAuthors and titles with authors sorted for each title:");
            foreach (var element in allTitleAuthors)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,0} {1,0} {2,0}",
                       element.Title1, element.FirstName, element.LastName));
            } // end foreach


            //C . Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name first then first name
            var allAuthors = from book in dbcontext.Titles
                             orderby book.Title1
                             select new
                             {
                                 Title = book.Title1,
                                 Authors = from author in book.Authors

                                           orderby author.LastName, author.FirstName
                                           select new
                                           {
                                               author.FirstName,
                                               author.LastName
                                           }
                             };
            outputTextBox.AppendText("\r\n\r\nTitles grouped by author:");
            foreach (var element in allAuthors)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,0}", element.Title));
                foreach (var authors in element.Authors)
                {
                    outputTextBox.AppendText(
                        String.Format("\r\n\t\t{0,0} {1,0} ",
                        authors.FirstName, authors.LastName));
                }
            } // end foreach


        } // end method JoiningTableData_Load
    } // end class JoiningTableData
} // end namespace JoinQueries

