LinqQueries queries = new LinqQueries();

//ALL COLLECTION
//PrintValues(queries.AllCollection());

//Todos los libros que se hayan publicado despues del 2000
//PrintValues(queries.BooksReto1());

//Libros que tenga mas de 250 paginas y el titulo contenga las palabras in Action
//PrintValues(queries.BooksReto2());

//Todos los libros tienen status
//Console.WriteLine($" Todos los libros tienen status? {queries.BooksReto3()}");

//Alguno de los libros fue publicado en 2005?
//Console.WriteLine($" Alguno de los libros fue publicado en 2005? {queries.BooksReto4()}");

//Libros que pertenezcan a la categoria de Python
//PrintValues(queries.BooksReto5());

//Todos los libros de la categoria de Java ordernado por nombre
//PrintValues(queries.BooksReto6());

//Todos los libros que tengan mas de 450 paginas y ordernar de manera descendente
//PrintValues(queries.BooksReto7());

//Retornar los primeros 3 libros con fecha de publicación mas reciente que estén categorizados en JAVA, utilizando TAKE
//PrintValues(queries.BooksReto8());

//Retornar el tercer y cuarto libro que tengan más de 400 páginas
//PrintValues(queries.BooksReto9());

//Retornar el título y el número de paginas de los primeros 3 libros de la colección, utilizando select
//PrintValues(queries.BooksReto10());

//Retorna la cantidad de libros que tengan entre 200 y 500 paginas
//Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500: {queries.BooksReto11()}");

//Retornar la menor fecha de publicación de la lista de libros
//Console.WriteLine($"Fecha de publicación menor: {queries.BooksReto12()}");

//Retornar la cantidad de paginas del libro con mayor numero de paginas en la colección
//Console.WriteLine($"Cantidad de paginas del libro con mayor número de paginas: {queries.BooksReto13()} paginas.");

//Retornar todo el libro que tenga la menor cantidad de paginas mayor a 0
//PrintValuesBook(queries.BooksReto14());

//Retornar todo el libro que tenga la fecha de publicación mas reciente
//PrintValuesBook(queries.BooksReto15());

//Retornar la suma de la cantidad de paginas, de todos los libros que tengan entre 0 y 500
//Console.WriteLine($"Cantidad de paginas, de todos los libros que tengan entre 0 y 500: {queries.BooksReto16()} paginas.");

//Retorna los titulo de los libros que tienen fecha de publicación  posterior a 2015
//Console.WriteLine($"Titulos de libros que tienen fecha de publicación posterior a 2015: {queries.BooksReto17()}");

//Retorna el promedio de caracteres que tienen los titulos de la colección
//Console.WriteLine($"promedio de caracteres que tienen los titulos de la colección: {queries.BooksReto18()}");

//--OPERADORES DE AGUPAMIENTO-----------------------

//Retorna todos los libros que fueron publicados apartir del 2000, agrupados por año
//PrintValuesGroup(queries.BooksReto19());

//Retorna un diccionario usando lookup que permita consultar los libros de acuerdo a la letra con la que inicia el titulo del libro
//PrintDictionary(queries.BooksReto20(), 'J');

//Obtener una colección que tenga todos los libros con mas de 500 paginas y otra que contenga los libros publicados despues del 2005. 
//utilizando Join retornar los libros que esten en ambas condiciones

PrintValues(queries.BooksReto21());

void PrintValuesBook(Book book)
{
    Console.WriteLine("{0,-60}{1,15}{2,15}\n","Titulo", "N. Paginas", "Fecha publicación");
    
    Console.WriteLine("{0,-60}{1,15}{2,15}",book.Title, book.PageCount, book.PublishedDate.ToShortDateString());

}

void PrintValues(IEnumerable<Book> listBooks)
{
    Console.WriteLine("{0,-60}{1,15}{2,15}\n","Titulo", "N. Paginas", "Fecha publicación");
    foreach(var item in listBooks)
    {
        Console.WriteLine("{0,-60}{1,15}{2,15}",item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

}

void PrintValuesGroup(IEnumerable<IGrouping<int,Book>> listBooks)
{
    
    foreach(var grupo in listBooks)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60}{1,15}{2,15}\n","Titulo", "N. Paginas", "Fecha publicación");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60}{1,15}{2,15}",item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }

}

void PrintDictionary(ILookup<char, Book> listBooks, char letra)
{
    Console.WriteLine("{0,-60}{1,15}{2,15}\n","Titulo", "N. Paginas", "Fecha publicación");
    foreach(var item in listBooks[letra])
    {
        Console.WriteLine("{0,-60}{1,15}{2,15}",item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

}
