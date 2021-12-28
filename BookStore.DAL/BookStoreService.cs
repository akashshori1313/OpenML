using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.EFModels.Context;
using BookStore.EFModels.Model;
using BookStore.Interface;
using BookStore.Models;

namespace BookStore.DAL
{
    public class BookStoreService : IBookStoreInterface
    {
        private BookContext _context;

        public BookStoreService(BookContext BookDbContext)
        {
            _context = BookDbContext;
        }

        public ReturnDataStore<BookDetailModel> AddUpdateBook(BookDetailInsertModel bookdetils)
        {
            ReturnDataStore<BookDetailModel> myObjectreturn = new ReturnDataStore<BookDetailModel>();
            BookDetailModel myBookDetails = new BookDetailModel();
            try
            {
                 if(bookdetils.book_id != 0)
                {
                    BookDetails myBookUpdate = new BookDetails();
                    myBookUpdate.author_name = bookdetils.author_name;
                    myBookUpdate.book_count = bookdetils.book_count;
                    myBookUpdate.book_name = bookdetils.book_name;
                    myBookUpdate.publisher_name = bookdetils.publisher_name;
                    _context.Books.Update(myBookUpdate);
                    _context.SaveChanges();
                }
                else
                {
                    BookDetails myBook = new BookDetails();
                    myBook.author_name = bookdetils.author_name;
                    myBook.book_count = bookdetils.book_count;
                    myBook.book_name = bookdetils.book_name;
                    myBook.publisher_name = bookdetils.publisher_name;
                    _context.Books.Add(myBook);
                    _context.SaveChanges();

                    myBookDetails = new BookDetailModel
                    {
                        author_name = myBook.author_name,
                        book_count = myBook.book_count,
                        book_id = myBook.book_id
                        ,
                        publisher_name = myBook.publisher_name,
                        book_name = myBook.book_name
                    };

                    myObjectreturn.Data = myBookDetails;
                    myObjectreturn.Status = "Success";
                    myObjectreturn.ErrorCode = "0";
                }

                
                


            }
            catch (Exception Ex)
            {
                myObjectreturn.Data = myBookDetails;
                myObjectreturn.Status = "Error";
                myObjectreturn.ErrorCode = "101";
            }

            return myObjectreturn;
        }
        public ReturnDataStore<List<BookDetailModel>> GetBooks()
        {
            ReturnDataStore<List<BookDetailModel>> myListBooks = new ReturnDataStore<List<BookDetailModel>>();

            try
            {

                var BookdetailList = _context.Books.Select(x => new BookDetailModel
                {
                    book_count = x.book_count,
                    author_name = x.author_name,
                    book_id = x.book_id,
                    publisher_name = x.publisher_name,
                    book_name = x.book_name

                }).ToList();

                myListBooks.Data = BookdetailList;
                myListBooks.Status = "Success";
                myListBooks.ErrorCode = "0";

            }
            catch (Exception ex)
            {
                myListBooks.Data = null;
                myListBooks.Status = "Error";
                myListBooks.ErrorCode = "101";
            }


            return myListBooks;
        }

        public ReturnDataStore<List<BuyerDetailModel>> GetBuyers()
        {
            ReturnDataStore<List<BuyerDetailModel>> myBuyerDetails = new ReturnDataStore<List<BuyerDetailModel>>();

            try
            {
                var BuyerList = (from books in _context.Books
                                 from buyer in _context.Buyer
                                 where books.book_id == buyer.book_id
                                 select new BuyerDetailModel
                                 {

                                     book_id = books.book_id,
                                     buyer_address = buyer.buyer_address,
                                     book_name = books.book_name,
                                     buyer_name = buyer.buyer_name

                                 }).ToList();

                myBuyerDetails.Data = BuyerList;
                myBuyerDetails.ErrorCode = "101";
                myBuyerDetails.Status = "Error";
            }
            catch (Exception Ex)
            {
                myBuyerDetails.Data = null;
                myBuyerDetails.ErrorCode = "101";
                myBuyerDetails.Status = "Error";

            }

            return myBuyerDetails;


        }
        
        public ReturnDataStore<BuyerInsertModel> InsertBuyer(BuyerInsertModel BuyerModel)
        {
            ReturnDataStore<BuyerInsertModel> myReturnModel = new ReturnDataStore<BuyerInsertModel>();
            try
            {
                BuyerDetails myBuyer = new BuyerDetails();
                myBuyer.book_id = BuyerModel.book_id;
                myBuyer.buyer_address = BuyerModel.buyer_address;
                myBuyer.buyer_name = BuyerModel.buyer_name;

                _context.Buyer.Add(myBuyer);
                _context.SaveChanges();

                myReturnModel.Data = BuyerModel;
                myReturnModel.Status = "Success";
                myReturnModel.ErrorCode = "0";
            }
            catch (Exception Ex)
            {
                myReturnModel.Data = null;
                myReturnModel.Status = "Error";
                myReturnModel.ErrorCode = "101";
            }

            return myReturnModel;
        }

        public ReturnDataStore<List<BookDetailModel>> SearchBook(string searchKeyword)
        {
            ReturnDataStore<List<BookDetailModel>> myListBooks = new ReturnDataStore<List<BookDetailModel>>();

            try
            {
                if (String.IsNullOrEmpty(searchKeyword))
                {
                    var BookdetailList = _context.Books.Select(x => new BookDetailModel
                    {
                        book_count = x.book_count,
                        author_name = x.author_name,
                        book_id = x.book_id,
                        publisher_name = x.publisher_name,
                        book_name = x.book_name

                    }).ToList();

                    myListBooks.Data = BookdetailList;
                    myListBooks.Status = "Success";
                    myListBooks.ErrorCode = "0";
                }
                else
                {
                    var BookdetailList = _context.Books.Select(x => new BookDetailModel
                    {
                        book_count = x.book_count,
                        author_name = x.author_name,
                        book_id = x.book_id,
                        publisher_name = x.publisher_name,
                        book_name = x.book_name

                    }).Where(y => y.author_name.ToLower().Contains(searchKeyword.ToLower()) || y.book_name.ToLower().Contains(searchKeyword.ToLower())
                                                                                           || y.publisher_name.ToLower().Contains(searchKeyword.ToLower())).ToList();

                    myListBooks.Data = BookdetailList;
                    myListBooks.Status = "Success";
                    myListBooks.ErrorCode = "0";

                }
                

            }
            catch (Exception ex)
            {
                myListBooks.Data = null;
                myListBooks.Status = "Error";
                myListBooks.ErrorCode = "101";
            }


            return myListBooks;
        }

        public ReturnDataStore<List<BookDetailModel>> SearchBookByAuther(string searchKeyword)
        {
            ReturnDataStore<List<BookDetailModel>> myListBooks = new ReturnDataStore<List<BookDetailModel>>();

            try
            {
                if (String.IsNullOrEmpty(searchKeyword))
                {
                    var BookdetailList = _context.Books.Select(x => new BookDetailModel
                    {
                        book_count = x.book_count,
                        author_name = x.author_name,
                        book_id = x.book_id,
                        publisher_name = x.publisher_name,
                        book_name = x.book_name

                    }).ToList();

                    myListBooks.Data = BookdetailList;
                    myListBooks.Status = "Success";
                    myListBooks.ErrorCode = "0";
                }
                else
                {
                    var BookdetailList = _context.Books.Select(x => new BookDetailModel
                    {
                        book_count = x.book_count,
                        author_name = x.author_name,
                        book_id = x.book_id,
                        publisher_name = x.publisher_name,
                        book_name = x.book_name

                    }).Where(y => y.author_name.ToLower().Contains(searchKeyword.ToLower())).ToList();

                    myListBooks.Data = BookdetailList;
                    myListBooks.Status = "Success";
                    myListBooks.ErrorCode = "0";
                }

               

            }
            catch (Exception ex)
            {
                myListBooks.Data = null;
                myListBooks.Status = "Error";
                myListBooks.ErrorCode = "101";
            }


            return myListBooks;
        }
    }
}
