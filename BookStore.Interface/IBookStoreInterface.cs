using BookStore.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Interface
{
    public interface IBookStoreInterface
    {
        public ReturnDataStore<BookDetailModel> AddUpdateBook(BookDetailInsertModel bookdetils);
        public ReturnDataStore<List<BookDetailModel>> GetBooks();
        public ReturnDataStore<List<BuyerDetailModel>> GetBuyers();
        public ReturnDataStore<BuyerInsertModel> InsertBuyer(BuyerInsertModel BuyerModel);
        public ReturnDataStore<List<BookDetailModel>> SearchBookByAuther(string searchKeyword);
        public ReturnDataStore<List<BookDetailModel>> SearchBook(string searchKeyword);
    }
}
