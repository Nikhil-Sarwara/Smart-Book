import React from "react";
import "./About.css"; // Import the custom CSS file

const About = () => {
  return (
    <div className="about-container">
      <h2 className="about-title">About Our Bookstore</h2>
      <div className="about-content">
        <p className="about-paragraph">
          Welcome to our humble online bookstore! We are passionate about
          bringing the joy of reading to everyone. Our collection features a
          wide variety of books, from timeless classics to exciting new
          releases.
        </p>
        <p className="about-paragraph">
          Created with love using modern web technologies like Vite and React,
          and styled with the elegant simplicity of Bootstrap, this application
          aims to provide a seamless and enjoyable Browse experience.
        </p>
        <p className="about-paragraph">
          We believe in the power of stories and strive to be your trusted
          source for discovering your next favorite read. Thank you for
          visiting!
        </p>
        {/* You can add more information about your bookstore here */}
      </div>
    </div>
  );
};

export default About;
