import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import "./Authentication.css"; // Import the custom CSS file

const Authentication = () => {
  const [activeTab, setActiveTab] = useState("login");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("/api/auth/login", {
        username,
        password,
      });
      localStorage.setItem("token", response.data.token);
      navigate("/");
    } catch (error) {
      console.error(error);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("/api/auth/register", {
        username,
        password,
        firstName,
        lastName,
      });
      localStorage.setItem("token", response.data.token);
      navigate("/");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="auth-container">
      <h1 className="auth-title text-center">Login or Register</h1>
      <ul className="nav nav-tabs auth-tabs" role="tablist">
        <li className="nav-item" role="presentation">
          <button
            className={`nav-link ${activeTab === "login" ? "active" : ""}`}
            onClick={() => setActiveTab("login")}
            data-bs-toggle="tab"
            data-bs-target="#login-tab"
            type="button"
            role="tab"
          >
            Login
          </button>
        </li>
        <li className="nav-item" role="presentation">
          <button
            className={`nav-link ${activeTab === "register" ? "active" : ""}`}
            onClick={() => setActiveTab("register")}
            data-bs-toggle="tab"
            data-bs-target="#register-tab"
            type="button"
            role="tab"
          >
            Register
          </button>
        </li>
      </ul>
      <div className="tab-content auth-tab-content">
        <div
          className={`tab-pane fade ${
            activeTab === "login" ? "show active" : ""
          }`}
          id="login-tab"
          role="tabpanel"
        >
          <form onSubmit={handleLogin} className="auth-form mt-3">
            <div className="mb-3">
              <label className="form-label">Username</label>
              <input
                type="text"
                className="form-control"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
            </div>
            <div className="mb-3">
              <label className="form-label">Password</label>
              <input
                type="password"
                className="form-control"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
            <button type="submit" className="btn btn-primary w-100 auth-button">
              Login
            </button>
          </form>
        </div>
        <div
          className={`tab-pane fade ${
            activeTab === "register" ? "show active" : ""
          }`}
          id="register-tab"
          role="tabpanel"
        >
          <form onSubmit={handleRegister} className="auth-form mt-3">
            <div className="mb-3">
              <label className="form-label">First Name</label>
              <input
                type="text"
                className="form-control"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
              />
            </div>
            <div className="mb-3">
              <label className="form-label">Last Name</label>
              <input
                type="text"
                className="form-control"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
              />
            </div>
            <div className="mb-3">
              <label className="form-label">Username</label>
              <input
                type="text"
                className="form-control"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
            </div>
            <div className="mb-3">
              <label className="form-label">Password</label>
              <input
                type="password"
                className="form-control"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
            <button type="submit" className="btn btn-primary w-100 auth-button">
              Register
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Authentication;
