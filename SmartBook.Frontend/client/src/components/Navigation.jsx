import React from "react";
import { Link } from "react-router-dom";
import "./Navigation.css";

const Navigation = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light mb-3 retro-navbar">
      <div className="container-fluid">
        <Link className="navbar-brand retro-navbar-brand" to="/">
          My Bookstore
        </Link>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon retro-navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item retro-nav-item">
              <Link className="nav-link retro-nav-link" to="/">
                Home
              </Link>
            </li>
            <li className="nav-item retro-nav-item">
              <Link className="nav-link retro-nav-link" to="/books">
                Books
              </Link>
            </li>
            <li className="nav-item retro-nav-item">
              <Link className="nav-link retro-nav-link" to="/about">
                About
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navigation;
