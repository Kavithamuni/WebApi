using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FBWebAPI;

namespace FBWebAPI.Controllers
{
    public class FriendBookController : ApiController
    {
        FriendBookDBEntities fbentities = new FriendBookDBEntities();
        
        // To get book details by id
        [HttpGet]
        public BooksList GetBookById(int BookId)
        {
            BooksList list = fbentities.BooksLists.Find(BookId);
            return list;
        }

        // To get all book details
        [HttpGet]
        public IEnumerable<BooksList> GetBookList()
        {
            return fbentities.BooksLists;
        }
      
        // To Add book details
        [HttpPost]
        public IHttpActionResult AddBookList([FromBody]BooksList bList)
        {
            fbentities.BooksLists.Add(bList);
            fbentities.SaveChanges();
            return Ok(bList.BookID);
        }

        // To update book details
        [HttpPut]
        public IHttpActionResult EditBookList([FromBody]BooksList bList)
        {
            var edititem = fbentities.BooksLists.FirstOrDefault(x => x.BookID == bList.BookID);
            edititem.BookName = bList.BookName;
            fbentities.SaveChanges();
            return Ok(bList.BookID);
        }

        // To Delete book details
        [HttpDelete]
        public IHttpActionResult DeleteBooks(int BookId)
        {
            BooksList list = fbentities.BooksLists.Find(BookId);
            fbentities.BooksLists.Remove(list);
            fbentities.SaveChanges();
            return Ok(list);
        }
    }
}