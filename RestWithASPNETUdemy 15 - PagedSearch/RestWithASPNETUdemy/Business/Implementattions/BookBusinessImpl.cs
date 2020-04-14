using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IPersonRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImpl(IPersonRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        // Método responsável por retornar uma pessoa
        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        // Método responsável por atualizar uma pessoa
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }

    
}
