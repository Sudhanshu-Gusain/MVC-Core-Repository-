using VasuBookStore.Models;
namespace VasuBookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookByID( int ID) 
        {
            return DataSource().Where(x => x.Id.Equals(ID)).FirstOrDefault(); //FirstorDefault - If there is no data it return null else return data
        }
        public List<BookModel> SearchBooks(string title, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorname)).ToList();
            // **Contain()** - if we search MV only, it will return the matching records from the table. 
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id=1,Title="MVC",Author="Vasu"},
                new BookModel(){Id=2,Title="Maheet",Author="Naina"},
                new BookModel(){Id=3,Title="Vibhorshok",Author="kaali"},
                new BookModel(){Id=4,Title="Palakchor",Author="dhriti"}
            };
        }
    }
}
