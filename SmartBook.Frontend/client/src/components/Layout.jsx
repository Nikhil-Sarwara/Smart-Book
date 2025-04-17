import React from "react";
import { Outlet } from "react-router-dom";
import Navigation from "./Navigation";
import "bootstrap/dist/css/bootstrap.min.css"; // Import Bootstrap CSS

const SmartBookStore = () => {
  return (
    <div className="d-flex flex-column min-vh-100">
      <Navigation />
      <div className="container flex-grow-1">
        <Outlet /> {/* This is where child routes will be rendered */}
      </div>
      <footer className="mt-auto text-center">
        <p>&copy; {new Date().getFullYear()} My Bookstore</p>
      </footer>
    </div>
  );
};

export default SmartBookStore;
