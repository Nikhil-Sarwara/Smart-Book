import React from "react";
import "./Home.css"; // Import the custom CSS file
import BookStackImage from "../assets/images/book_stack.png"; // Example image import
import OpenBookImage from "../assets/images/open_book.jpg"; // Example image import

const Home = () => {
  return (
    <div className="home-container">
      <header className="home-header">
        <div className="header-content">
          <h1 className="home-title">Welcome to SmartBook!</h1>
          <p className="home-subtitle">Discover Your Next Favorite Read.</p>
          <button className="home-button">Explore Our Books</button>
        </div>
        <div className="header-image">
          <img
            src={BookStackImage}
            alt="Stack of Books"
            className="book-stack-img"
          />
        </div>
      </header>

      <section className="featured-section">
        <h2 className="section-title">Featured Books</h2>
        <div className="featured-books-grid">
          {/* Replace these with actual featured book data */}
          <div className="featured-book-card">
            <img
              src="https://via.placeholder.com/150/808080/FFFFFF?Text=Book+Cover"
              alt="Featured Book 1"
            />
            <h3>Book Title 1</h3>
            <p>Author Name</p>
            <button className="view-button">View Details</button>
          </div>
          <div className="featured-book-card">
            <img
              src="https://via.placeholder.com/150/808080/FFFFFF?Text=Book+Cover"
              alt="Featured Book 2"
            />
            <h3>Book Title 2</h3>
            <p>Author Name</p>
            <button className="view-button">View Details</button>
          </div>
          <div className="featured-book-card">
            <img
              src="https://via.placeholder.com/150/808080/FFFFFF?Text=Book+Cover"
              alt="Featured Book 3"
            />
            <h3>Book Title 3</h3>
            <p>Author Name</p>
            <button className="view-button">View Details</button>
          </div>
        </div>
      </section>

      <section className="about-section">
        <div className="about-content-wrapper">
          <div className="about-image">
            <img
              src={OpenBookImage}
              alt="Open Book"
              className="open-book-img"
            />
          </div>
          <div className="about-text">
            <h2 className="section-title">About Us</h2>
            <p>
              At SmartBook, we believe that books have the power to transform
              lives. Our mission is to connect readers with the stories they'll
              love. Explore our extensive collection, discover new authors, and
              embark on literary adventures.
            </p>
            <p>
              We are passionate about books and dedicated to providing a
              seamless and enjoyable online bookstore experience.
            </p>
            <button className="learn-more-button">Learn More</button>
          </div>
        </div>
      </section>

      <footer className="home-footer">
        <p>
          &copy; {new Date().getFullYear()} SmartBook - Your Online Bookstore
        </p>
      </footer>
    </div>
  );
};

export default Home;
