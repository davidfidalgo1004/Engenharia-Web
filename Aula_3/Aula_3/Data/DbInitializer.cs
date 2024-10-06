using Aula_3.Models;

namespace Aula_3.Data
{
    public class DbInitializer
    {
        private readonly Aula_3Context _context; //CLASSE->NOME PROJETO

        public DbInitializer(Aula_3Context context)
        {
            _context = context;
        }   

        public void Run()
        {
            _context.Database.EnsureCreated();
            if (_context.Category.Any()) //Vai verificar se existe dados na base dados, caso exista, não adiciona as informações abaxixo do if
            {
                return;
            }
            var category = new Category[]
            {
                new Category{Name="Programming", Description="Algoritms and programming area courses"},
                new Category{Name="Administration", Description="Public administration and business management course"},
                new Category{Name="Communication", Description="Business  and institutional communication course"}

            };
            _context.Category.AddRange(category);
            _context.SaveChanges();
            //foreach(var c in category)  Aqui caso queiramos introduzir um a um
        }



    }


}
