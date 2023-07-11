public class LinqQueries
{

    private List<Book> librosCollection =  new List<Book>();

    public LinqQueries()
    {

        using(StreamReader reader = new StreamReader("books.json"))
        {

            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});

        }

    }

    public IEnumerable<Book> AllCollection()
    {
        return librosCollection;
    }

    //Todos los libros que se hayan publicado despues del 2000
    public IEnumerable<Book> BooksReto1()
    {
        //entension method
        //return librosCollection.Where(p=>p.PublishedDate.Year > 2000); 

        //query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;

    }

    //Libros que tenga mas de 250 paginas y el titulo contenga las palabras in Action
    public IEnumerable<Book> BooksReto2()
    {
        //entension method
        //return librosCollection.Where(p=>p.PageCount > 250 && p.Title.Contains("in Action")); 

        //query expresion
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;

    }

    //Todos los estados del libro tengan estado
    public bool BooksReto3()
    {
        //entension method
        return librosCollection.All(p=> p.Status != string.Empty);

    }

    //Verificar si alguno de los libros fue publicado en 2005
    public bool BooksReto4()
    {
        //entension method
        return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    //Libros que pertenezcan a la categoria de Python
    public IEnumerable<Book> BooksReto5()
    {
        //entension method
        //return librosCollection.Where(p=>p.Categories.Contains("Python")); 

        //query expresion
        return from l in librosCollection where l.Categories.Contains("Python") select l;

    }

    //Retornar todos los libros de la categoria de Java ordernado por nombre
    public IEnumerable<Book> BooksReto6()
    {
        //entension method
        return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title); 

    }

    //Retornar todos los libros que tengan mas de 450 paginas y ordernar de manera descendente
    public IEnumerable<Book> BooksReto7()
    {
        //entension method
        return librosCollection.Where(p=>p.PageCount > 450).OrderByDescending(p=>p.PageCount); 

    }

    //Retornar los primeros 3 libros con fecha de publicación mas reciente que estén categorizados en JAVA, utilizando TAKE
    public IEnumerable<Book> BooksReto8()
    {
        //entension method
        return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.PublishedDate).TakeLast(3); 

    }

    //Retornar el tercer y cuarto libro que tengan más de 400 páginas
    public IEnumerable<Book> BooksReto9()
    {
        //entension method
        return librosCollection.Where(p=>p.PageCount > 400).Take(4).Skip(2);

    }

    //Retornar el título y el número de paginas de los primeros 3 libros de la colección, utilizando select
    public IEnumerable<Book> BooksReto10()
    {
        //entension method
        return librosCollection
        .Take(3)
        .Select(p=>new Book(){Title = p.Title, PageCount = p.PageCount});

    }

    //Retornar la cantidad de libros que tengan entre 200 y 500 paginas
    public long BooksReto11()
    {
        //entension method
        return librosCollection.Count(p=>p.PageCount>=200 && p.PageCount<=500);

    }

    //Retornar la menor fecha de publicación de la lista de libros, usando Min
    public DateTime BooksReto12()
    {
        //entension method
        return librosCollection.Min(p=>p.PublishedDate);

    }

    //Retornar la cantidad de paginas del libro con mayor numero de paginas en la colección, usan Max
    public int BooksReto13()
    {
        //entension method
        return librosCollection.Max(p=>p.PageCount);

    }

    //Retornar todo el libro que tenga la menor cantidad de paginas mayor a 0
    public Book BooksReto14()
    {
        //entension method
        return librosCollection.Where(p=>p.PageCount > 0).MinBy(p=>p.PageCount);

    }

    //Retornar todo el libro que tenga la fecha de publicación mas reciente
    public Book BooksReto15()
    {
        //entension method
        return librosCollection.Where(p=>p.PageCount > 0).MaxBy(p=>p.PublishedDate);

    }

    //Retornar la suma de la cantidad de paginas, de todos los libros que tengan entre 0 y 500
    public int BooksReto16()
    {
        //entension method
        return librosCollection.Where(p=>p.PageCount >= 0 && p.PageCount <=500).Sum(p=>p.PageCount);

    }

    //Retornar el titulo de los libros que tienen fecha de publicación  posterior a 2015
    public string BooksReto17()
    {
        //entension method
        return librosCollection
                .Where(p=>p.PublishedDate.Year > 2015)
                .Aggregate("",(TitulosLibros, next) => 
                {
                    if(TitulosLibros!= string.Empty){
                        TitulosLibros += " - " + next.Title;
                    }else{
                        TitulosLibros = next.Title;
                    }

                    return TitulosLibros;
                });

    }

    //Retornar el promedio de caracteres que tienen los titulos de la colección
    public double BooksReto18()
    {
        //entension method
        return librosCollection.Average(p=>p.Title.Length);

    }

    //Retornar todos los libros que fueron publicados apartir del 2000, agrupados por año
    public IEnumerable<IGrouping<int,Book>> BooksReto19()
    {
        //entension method
        return librosCollection.Where(p=>p.PublishedDate.Year > 2000).GroupBy(p=>p.PublishedDate.Year);

    }

    //Retornar un diccionario usando lookup que permita consultar los libros de acuerdo a la letra con la que inicia el titulo del libro
    public ILookup<char,Book> BooksReto20()
    {
        //entension method
        return librosCollection.ToLookup(p=>p.Title[0], p=>p);
    }

    //Obtener una colección que tenga todos los libros con mas de 500 paginas y otra que contenga los libros publicados despues del 2005. 
    //utilizando Join retornar los libros que esten en ambas condiciones
    public IEnumerable<Book> BooksReto21()
    {
        //entension method
        var Colection1 = librosCollection.Where(p=>p.PageCount > 500);
        var Colection2 = librosCollection.Where(p=>p.PublishedDate.Year > 2005);

        return Colection1.Join(Colection2, p=>p.Title, x=>x.Title,(p,x)=>p);
    }
}