import React from "react";

const Books = () => {
  // TODO: Fetch or define your book data here
  const books = [
    { id: 1, title: "The Lord of the Rings", author: "J.R.R. Tolkien" },
    { id: 2, title: "Pride and Prejudice", author: "Jane Austen" },
    { id: 3, title: "To Kill a Mockingbird", author: "Harper Lee" },
  ];

  return (
    <div>
      <h2>Our Books</h2>
      <div className="row row-cols-1 row-cols-md-3 g-4">
        {books.map((book) => (
          <div className="col" key={book.id}>
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">{book.title}</h5>
                <p className="card-text">By {book.author}</p>
                <button className="btn btn-primary">View Details</button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Books;
